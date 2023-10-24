namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // прив€зал изображение
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        //for (int i = 0; i < 100; i++)
        //{
        //    particles.Add(new Particle(picDisplay.Image.Width / 2, picDisplay.Image.Height / 2));
        //}
    }

    private List<Particle> particles = new();
    // добавл€ем переменные дл€ хранени€ положени€ мыши
    private int MousePositionX = 0;
    private int MousePositionY = 0;


    // добавил функцию обновлени€ состо€ни€ системы
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
                // новое начальное расположение частицы Ч это то, куда указывает курсор

                particle.X = MousePositionX;
                particle.Y = MousePositionY;
                /* Ё“ќ ƒќЅј¬Ћяё, тут сброс состо€ни€ частицы */
                var direction = (double)Particle.Rand.Next(360);
                var speed = 1 + Particle.Rand.Next(10);

                particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                particle.Radius = 2 + Particle.Rand.Next(10);
            }
            else
            {
                // и добавл€ем новый, собственно он даже проще становитс€, 
                // так как теперь мы храним вектор скорости в €вном виде и его не надо пересчитывать
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
            // ну и цвета мен€ем
            particle.FromColor = Color.Yellow;
            particle.ToColor = Color.FromArgb(0, Color.Magenta);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;
            particles.Add(particle);
            
        }
    }

    // функци€ рендеринга
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
        // в обработчике заносим положение мыши в переменные дл€ хранени€ положени€ мыши
        MousePositionX = e.X;
        MousePositionY = e.Y;
    }
}
