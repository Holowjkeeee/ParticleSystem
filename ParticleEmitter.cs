using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem;

class ParticleEmitter
{
    List<Particle> particles = new();
    public int MousePositionX;
    public int MousePositionY;
    public float GravitationX = 0;
    public float GravitationY = 0; // пусть гравитация будет силой один пиксель за такт, нам хватит
    public List<IImpactPoint> impactPoints = new (); // тут буду хранится точки притяжения

    public void UpdateState()
    {
        foreach (var particle in particles)
        {
            particle.Life -= 1; // уменьшаю здоровье
            // если здоровье кончилось
            if (particle.Life < 0)
            {
                // восстанавливаю здоровье
                particle.Life = 20 + Particle.Rand.Next(100);
                // перемещаю частицу в центр
                //particle.X = picDisplay.Image.Width / 2;
                //particle.Y = picDisplay.Image.Height / 2;
                // новое начальное расположение частицы — это то, куда указывает курсор

                particle.X = MousePositionX;
                particle.Y = MousePositionY;
                /* ЭТО ДОБАВЛЯЮ, тут сброс состояния частицы */
                var direction = (double)Particle.Rand.Next(360);
                var speed = 1 + Particle.Rand.Next(10);

                particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                particle.Radius = 2 + Particle.Rand.Next(10);
            }
            else
            {
                // каждая точка по-своему воздействует на вектор скорости
                foreach (var point in impactPoints)
                {
                    point.ImpactParticle(particle);
                }

                // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                particle.SpeedX += GravitationX;
                particle.SpeedY += GravitationY;
                // и добавляем новый, собственно он даже проще становится, 
                // так как теперь мы храним вектор скорости в явном виде и его не надо пересчитывать
                particle.X += particle.SpeedX;
                particle.Y += particle.SpeedY;
            }
        }

        // добавил генерацию частиц
        // генерирую не более 10 штук за тик
        for (var i = 0; i < 10; ++i)
        {
            if (particles.Count > 500) return; // пока частиц меньше 500 генерируем новые
            var particle = new ParticleColorful();
            // ну и цвета меняем
            particle.FromColor = Color.Yellow;
            particle.ToColor = Color.FromArgb(0, Color.Magenta);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;
            particles.Add(particle);

        }
    }

    public void Render(Graphics g)
    {
        // ну тут так и быть уж сам впишу...
        // это то же самое что на форме в методе Render
        foreach (var particle in particles)
        {
            particle.Draw(g);
        }
        // рисую точки притяжения красными кружочками
        foreach (var point in impactPoints)
        {
           point.Render(g);
        }
    }
}

