namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // привязал изображение
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        // гравитон
        emitter.impactPoints.Add(new GravityPoint
        {
            X = (float)(picDisplay.Width * 0.25),
            Y = picDisplay.Height / 2
        });

        // в центре антигравитон
        emitter.impactPoints.Add(new AntiGravityPoint
        {
            X = picDisplay.Width / 2,
            Y = picDisplay.Height / 2
        });

        // снова гравитон
        emitter.impactPoints.Add(new GravityPoint
        {
            X = (float)(picDisplay.Width * 0.75),
            Y = picDisplay.Height / 2
        });
    }

    ParticleEmitter emitter = new(); // добавили эмиттер


    private void timer1_Tick(object sender, EventArgs e)
    {
        emitter.UpdateState(); // тут теперь обновляем эмиттер

        using var g = Graphics.FromImage(picDisplay.Image);
        // рисую на изображении сколько насчитал
        g.Clear(Color.Black); // добавил очистку
        emitter.Render(g); // а тут теперь рендерим через эмиттер

        // обновить picDisplay
        picDisplay.Invalidate();
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        // а тут в эмиттер передаем положение мыфки
        emitter.MousePositionX = e.X;
        emitter.MousePositionY = e.Y;
    }
}
