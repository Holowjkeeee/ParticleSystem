namespace ParticleSystem;

public class TopEmitter : ParticleEmitter
{
    public int Width; // длина экрана

    protected override void ResetParticle(Particle particle)
    {
        base.ResetParticle(particle);

        particle.X = Particle.Rand.Next(Width);
        particle.Y = 0;

        particle.SpeedY = 1;
        particle.SpeedX = Particle.Rand.Next(-2, 2); // разброс влево и вправо
    }
}