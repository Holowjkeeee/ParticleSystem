namespace ParticleSystem;

/**
 * Класс частицы
 */
public class Particle
{
    /** Радиус частицы */
    public float Radius;
    
    /** X координата положения частицы в пространстве */
    public float X;
    
    /** Y координата положения частицы в пространстве */
    public float Y;
    
    /** Направление движения */
    public double Direction;
    
    /** Скорость перемещения по оси X */
    public float SpeedX;
    
    /** Скорость перемещения по оси Y */
    public float SpeedY;
    
    /** Продолжительность жизни частицы в условных единицах */
    public float Life;

    /** Генератор случайных чисел */
    public static readonly Random Rand = new();

    private float GetRandomFloat(float min, float max)
    {
        if (min < 0)
        {
            return (float)(min + Rand.NextDouble() * (max + Double.Abs(min)));
        }
        return (float)(min + Rand.NextDouble() * (max - min));
    }

    private double GetRandomDouble(double min, double max)
    {
        if (min < 0)
        {
            return min + Rand.NextDouble() * (max + Double.Abs(min));
        }
        return min + Rand.NextDouble() * (max - min);
    }
    
    protected Particle()
    {
        Direction = Rand.Next(360);
        var speed = 1 + Rand.Next(10);

        // вектор скорости
        SpeedX = (float)(Math.Cos(Direction / 180 * Math.PI) * speed);
        SpeedY = -(float)(Math.Sin(Direction / 180 * Math.PI) * speed);
        
        Radius = GetRandomFloat(2f, 10f);
        Life = GetRandomFloat(20f, 120f); // Исходный запас здоровья от 20 до 120
    }

    public virtual void Draw(Graphics g)
    {
        // коэффициент прозрачности от 0 до 1.0
        float alphaCoefficient = Math.Min(1f, Life / 100);
        // альфа канал от 0 до 255
        int alpha = (int)(alphaCoefficient * 255);
        
        // остальное все так же
        g.FillEllipse(
            new SolidBrush(
                    Color.FromArgb(alpha, Color.Black)
                ), 
            X - Radius, 
            Y - Radius, 
            Radius * 2, 
            Radius * 2);
    }
}

