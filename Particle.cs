using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ParticleSystem;

internal class Particle
{
    public int Radius; // радиус частицы
    public float X; // X координата положения частицы в пространстве
    public float Y; // Y координата положения частицы в пространстве

    public float Direction; // направление движения
    public float Speed; // скорость перемещения
    public float Life;

    // добавили генератор случайных чисел
    public static Random Rand = new();

    // конструктор по умолчанию будет создавать кастомную частицу
    public Particle()
    {
        // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
        Direction = Rand.Next(360);
        Speed = 1 + Rand.Next(10);
        Radius = 2 + Rand.Next(10);
        Life = 20 + Rand.Next(100); // Добавили исходный запас здоровья от 20 до 120
    }

    public void Draw(Graphics g)
    {
        // создали кисть для рисования
        var b = new SolidBrush(Color.Black);

        // нарисовали залитый кружок радиусом Radius с центром в X, Y
        g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

        // удалили кисть из памяти, вообще сборщик мусора рано или поздно это сам сделает
        // но документация рекомендует делать это самому
        b.Dispose();
    }
}

