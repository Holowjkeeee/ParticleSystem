using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ParticleSystem;

public class Particle
{
    public int Radius; // радиус частицы
    public float X; // X координата положения частицы в пространстве
    public float Y; // Y координата положения частицы в пространстве

    public double Direction; // направление движения
    public float SpeedX; // скорость перемещения по оси X
    public float SpeedY; // скорость перемещения по оси Y
    public float Life;

    // добавили генератор случайных чисел
    public static Random Rand = new();

    // конструктор по умолчанию будет создавать кастомную частицу
    public Particle()
    {
        // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
        Direction = Rand.Next(360);
        var speed = 1 + Rand.Next(10);

        // рассчитываем вектор скорости
        SpeedX = (float)(Math.Cos(Direction / 180 * Math.PI) * speed);
        SpeedY = -(float)(Math.Sin(Direction / 180 * Math.PI) * speed);
        Radius = 2 + Rand.Next(10);
        Life = 20 + Rand.Next(100); // Добавили исходный запас здоровья от 20 до 120
    }

    // конструктор по умолчанию будет создавать кастомную частицу
    public Particle(float X, float Y) : this()
    {
        this.X = X;
        this.Y = Y;
    }

    public virtual void Draw(Graphics g)
    {
        // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
        float k = Math.Min(1f, Life / 100);
        // рассчитываем значение альфа канала в шкале от 0 до 255
        // по аналогии с RGB, он используется для задания прозрачности
        int alpha = (int)(k * 255);

        // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
        var color = Color.FromArgb(alpha, Color.Black);
        var b = new SolidBrush(color);

        // остальное все так же
        g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

        b.Dispose();
    }
}

