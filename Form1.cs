namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // привязал изображение
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        //for (int i = 0; i < 100; i++)
        //{
        //    particles.Add(new Particle(picDisplay.Image.Width / 2, picDisplay.Image.Height / 2));
        //}
    }

    private List<Particle> particles = new();
    // добавляем переменные для хранения положения мыши
    private int MousePositionX = 0;
    private int MousePositionY = 0;


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
                //particle.X = picDisplay.Image.Width / 2;
                //particle.Y = picDisplay.Image.Height / 2;
                // новое начальное расположение частицы — это то, куда указывает курсор
                particle.X = MousePositionX;
                particle.Y = MousePositionY;
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
        g.Clear(Color.Black); // добавил очистку
        Render(g);

        // обновить picDisplay
        picDisplay.Invalidate();
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        // в обработчике заносим положение мыши в переменные для хранения положения мыши
        MousePositionX = e.X;
        MousePositionY = e.Y;
    }
}
