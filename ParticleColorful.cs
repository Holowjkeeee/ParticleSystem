namespace ParticleSystem;

class ParticleColorful : Particle
{
    public Color FromColor;
    public Color ToColor;

    public static Color MixColor(Color fromColor, Color toColor, float k)
    {
        return Color.FromArgb(
            (int)(toColor.A * (1 - k) + fromColor.A * k),
            (int)(toColor.R * (1 - k) + fromColor.R * k),
             (int)(toColor.G * (1 - k) + fromColor.G * k),
             (int)(toColor.B * (1 - k) + fromColor.B * k)
        );
    }
    
    public override void Draw(Graphics g)
    {
        float k = Math.Min(1f, Life / 100);

        // k уменьшается от 1 до 0, то порядок цветов обратный
        var color = MixColor(FromColor, ToColor, k); 
        //color = Color.FromArgb(100, Color.Blue);

        g.FillEllipse(
            new SolidBrush(color),
            X - Radius, 
            Y - Radius, 
            Radius * 2, 
            Radius * 2
        );

        DrawSpeedVector(g, (int)(255 * (Life / 100)));
        if(ShowDebugInfo) DrawDebugInfo(g);
    }
}

