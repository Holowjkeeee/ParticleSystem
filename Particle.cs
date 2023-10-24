using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem;

internal class Particle
{
    public int Radius; // радиус частицы
    public float X; // X координата положения частицы в пространстве
    public float Y; // Y координата положения частицы в пространстве

    public float Direction; // направление движения
    public float Speed; // скорость перемещения

    // добавили генератор случайных чисел
    public static Random Rand = new();

    // конструктор по умолчанию будет создавать кастомную частицу
    public Particle()
    {
        // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
        Direction = Rand.Next(360);
        Speed = 1 + Rand.Next(10);
        Radius = 2 + Rand.Next(10);
    }
}

