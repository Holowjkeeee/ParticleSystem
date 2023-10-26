namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

        this.emitter = new ParticleEmitter()
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

        emitters.Add(this.emitter);

        point1 = new GravityPoint
        {
            X = picDisplay.Width / 2 + 100,
            Y = picDisplay.Height / 2,
        };
        point2 = new GravityPoint
        {
            X = picDisplay.Width / 2 - 100,
            Y = picDisplay.Height / 2,
        };

        emitter.impactPoints.Add(point1);
        emitter.impactPoints.Add(point2);

        //emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.25),
        //    Y = picDisplay.Height / 2
        //});

        //emitter.impactPoints.Add(new AntiGravityPoint
        //{
        //    X = picDisplay.Width / 2,
        //    Y = picDisplay.Height / 2
        //});

        //emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.75),
        //    Y = picDisplay.Height / 2
        //});
    }

    GravityPoint point1;
    GravityPoint point2;

    private ParticleEmitter emitter;
    List<ParticleEmitter> emitters = new();


    private void timer1_Tick(object sender, EventArgs e)
    {
        emitter.UpdateState();

        using var g = Graphics.FromImage(picDisplay.Image);
        ClearScreen(g, Color.Black);

        foreach (var emitter in emitters)
        {
            emitter.Render(g);
        }

        picDisplay.Invalidate(); // обновить picDisplay
    }

    public void ClearScreen(Graphics g, Color color)
    {
        g.Clear(color);
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        foreach (var emitter in emitters)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        point2.X = e.X;
        point2.Y = e.Y;
    }


    private void tbDirection_Scroll(object sender, EventArgs e)
    {
        emitter.Direction = tbDirection.Value;
        lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
    }

    private void tbGraviton_Scroll(object sender, EventArgs e)
    {
        point1.Power = tbGraviton1.Value;
    }

    private void tbGraviton2_Scroll(object sender, EventArgs e)
    {
        point2.Power = tbGraviton2.Value;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
