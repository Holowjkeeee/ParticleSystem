namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // привязал изображение
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

        this.emitter = new ParticleEmitter() // создаю эмиттер и привязываю его к полю emitter
        {
            Direction = 0,
            Spreading = 10,
            SpeedMin = 10,
            SpeedMax = 10,
            ColorFrom = Color.Gold,
            ColorTo = Color.FromArgb(0, Color.Red),
            ParticlesPerTick = 10,
            X = picDisplay.Width / 2,
            Y = picDisplay.Height / 2,
        };

        emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

        //// гравитон
        //emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.25),
        //    Y = picDisplay.Height / 2
        //});

        //// в центре антигравитон
        //emitter.impactPoints.Add(new AntiGravityPoint
        //{
        //    X = picDisplay.Width / 2,
        //    Y = picDisplay.Height / 2
        //});

        //// снова гравитон
        //emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.75),
        //    Y = picDisplay.Height / 2
        //});
    }

    private ParticleEmitter emitter;
    List<ParticleEmitter> emitters = new List<ParticleEmitter>();


    private void timer1_Tick(object sender, EventArgs e)
    {
        emitter.UpdateState();

        using var g = Graphics.FromImage(picDisplay.Image);
        // рисую на изображении сколько насчитал
        g.Clear(Color.Black); // добавил очистку
        emitter.Render(g); // а тут теперь рендерим через эмиттер


        picDisplay.Invalidate();// обновить picDisplay
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        emitter.MousePositionX = e.X;
        emitter.MousePositionY = e.Y;
    }

    private void tbDirection_Scroll(object sender, EventArgs e)
    {
        emitter.Direction = tbDirection.Value;
        lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
    }
}
