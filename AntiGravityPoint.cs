﻿namespace ParticleSystem;

public class AntiGravityPoint : IImpactPoint
{
    public float Power = 100; // сила отторжения

    public override void ImpactParticle(Particle particle)
    {
        float gX = X - particle.X;
        float gY = Y - particle.Y;
        float r2 = Math.Max(100, gX * gX + gY * gY);

        particle.SpeedX -= gX * Power / r2;
        particle.SpeedY -= gY * Power / r2;
    }
}