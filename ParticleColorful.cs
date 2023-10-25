
namespace ParticleSystem;

class ParticleColorful : Particle
{
    public Color FromColor;
    public Color ToColor;

    public static Color MixColor(Color color1, Color color2, float k)
    {
        return Color.FromArgb(
            Math.Max(0, (int)(color2.A * k + color1.A * (1 - k))),
            Math.Max(0, (int)(color2.R * k + color1.R * (1 - k))),
            Math.Max(0, (int)(color2.G * k + color1.G * (1 - k))),
            Math.Max(0, (int)(color2.B * k + color1.B * (1 - k)))
        );
    }

    public override void Draw(Graphics g)
    {
        float k = Math.Min(1f, Life / 100);

        // k уменьшается от 1 до 0, то порядок цветов обратный
        Console.WriteLine("k: " + k.ToString());
        var color = MixColor(ToColor, FromColor, k);
        var b = new SolidBrush(color);

        g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

        b.Dispose();
    }
}

