namespace ParticleSystem;

/**
 * Базовый класс для точки
 */
public abstract class IImpactPoint
{
    /** Координата X */
    public float X;
    
    /** координата Y */
    public float Y;

    /** Ширина точки */
    public float width = 10;

    /** Высота точки */
    public float height = 10;

    /** Цвет точки */
    public Color Color = Color.Red;
    
    /**
     * Метод воздействия точки на частицу particle
     */
    public abstract void ImpactParticle(Particle particle);


    /**
     * Метод отрисовки точки
     */
    public virtual void Render(Graphics g)
    {
        g.FillEllipse(
            brush: new SolidBrush(Color),
            x: X - width/2,
            y: Y - height/2,
            width,
            height
        );
    }
}

