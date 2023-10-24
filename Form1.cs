namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            for (int i = 0; i < 50; i++)
            {
                particles.Add(new Particle());
            }
        }

        private List<Particle> particles = new();

        // добавил функцию обновления состояния системы
        private void UpdateState()
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
                    particle.X = picDisplay.Image.Width / 2;
                    particle.Y = picDisplay.Image.Height / 2;
                    // делаю рандомное направление, скорость и размер
                    particle.Direction = Particle.Rand.Next(360);
                    particle.Speed = 1 + Particle.Rand.Next(10);
                    particle.Radius = 2 + Particle.Rand.Next(10);
                }
                else
                {
                    // а это наш старый код
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }
        }

        // функция рендеринга
        private void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            using var g = Graphics.FromImage(picDisplay.Image);
            // рисую на изображении сколько насчитал
            g.Clear(Color.White); // добавил очистку
            Render(g);

            // обновить picDisplay
            picDisplay.Invalidate();
        }
    }
}