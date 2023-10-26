namespace ParticleSystem;

/**
 * Точка притяжения
 */
public class GravityPoint : IImpactPoint
{
    /** Cила притяжения */
    public float Power = 100;
    

    public override void ImpactParticle(Particle particle)
    {
        // расстояние от центра точки до центра частицы
        float gX = X - particle.X;
        float gY = Y - particle.Y;
        double r =  Math.Sqrt(gX * gX + gY * gY);
        
        // не интересует, если частица не внутри точки
        if (!(r + particle.Radius < Power / 2)) return; 

        // если частица внутри окружности, то притягиваем ее
        float r2 = (float)Math.Max(100, gX * gX + gY * gY);
        particle.SpeedX += gX * Power / r2;
        particle.SpeedY += gY * Power / r2;
    }

    public override void Render(Graphics g)
    {
        g.DrawEllipse(
            new Pen(Color),
            x: X - Power / 2,
            y: Y - Power / 2,
            width: Power,
            height: Power
        );

        var stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        var text = $"Я гравитон\nc силой {Power}";
        var font = new Font("Verdana", 10);

        // померить размеры текста
        var size = g.MeasureString(text, font);

        // подложнка под текст
        g.FillRectangle(
            new SolidBrush(Color.Red),
            X - size.Width / 2,
            Y - size.Height / 2,
            size.Width,
            size.Height
        );

        // текст
        g.DrawString(
            text,
            font,
            new SolidBrush(Color.White),
            X,
            Y,
            stringFormat
        );
    }

}
