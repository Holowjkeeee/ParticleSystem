using System.Text.RegularExpressions;

namespace ParticleSystem;

record Defaults
{
    public static int CurrentFps = 60;
    public static int MaxFps = 60;
    public const int ONE_SECOND = 1000;
    public static bool ShowSpeedVectors = false;
}

public partial class CanvasForm : Form
{
    public Color BackgroundColor = Color.Black;
    public int CurrentFps = Defaults.CurrentFps;
    public int MaxFps = Defaults.MaxFps;
    public bool ShowVectorSpeed = Defaults.ShowSpeedVectors;

    GravityPoint point1;
    GravityPoint point2;

    public ParticleEmitter Emitter;
    public List<ParticleEmitter> Emitters = new();
    public bool IsDebugEnabled = false;
    public DebugForm DebugForm;

    public System.Windows.Forms.Timer GetTimer()
    {
        return timer1;
    }

    public PictureBox GetCanvas()
    {
        return picDisplay;
    }

    public CanvasForm()
    {
        InitializeComponent();
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        Emitter = new ParticleEmitter()
        {
            Direction = 2,
            Spreading = 170,
            LifeMax = 100,
            LifeMin = 100,
            SpeedMin = 5,
            SpeedMax = 12,
            ColorFrom = Color.Gold,
            ColorTo = Color.FromArgb(0, Color.Red),
            X = picDisplay.Width / 3,
            Y = picDisplay.Height / 2,
        };

        Emitters.Add(Emitter);

        point1 = new GravityPoint
        {
            X = (float)picDisplay.Width / 2 + 100,
            Y = (float)picDisplay.Height / 2,
        };
        point2 = new GravityPoint
        {
            X = (float)picDisplay.Width / 2 - 100,
            Y = (float)picDisplay.Height / 2,
        };

        //Emitter.impactPoints.Add(point1);
        //Emitter.impactPoints.Add(point2);

        //Emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.25),
        //    Y = picDisplay.Height / 2
        //});

        //Emitter.impactPoints.Add(new AntiGravityPoint
        //{
        //    X = picDisplay.Width / 2,
        //    Y = picDisplay.Height / 2
        //});

        //Emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.75),
        //    Y = picDisplay.Height / 2
        //});
    }


    public void timer1_Tick(object sender, EventArgs e)
    {
        Emitter.UpdateState();
        Emitter.SaveState();

        using var g = Graphics.FromImage(picDisplay.Image);
        ClearCanvas(g, BackgroundColor);

        foreach (var emitter in Emitters)
        {
            emitter.Render(g);
        }

        UpdateCanvas();
    }


    public void ClearCanvas(Graphics g, Color color)
    {
        g.Clear(color);
    }

    /** Обновить picDisplay
     * 
     */
    public void UpdateCanvas()
    {
        picDisplay.Invalidate();
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        //if ()
        //foreach (var _emitter in Emitters)
        //{
        //    _emitter.X = e.X;
        //    _emitter.Y = e.Y;
        //}
        if (IsDebugEnabled)
        {
            bool infoDrawn = false;
            using var g = Graphics.FromImage(picDisplay.Image);
            foreach (var particle in Emitter.particles)
            {
                var dx = Math.Abs(Math.Abs(particle.X) - Math.Abs(e.X));
                var dy = Math.Abs(Math.Abs(particle.Y) - Math.Abs(e.Y));
                var distance = Math.Sqrt(dx * dx + dy * dy);
                if (distance <= particle.Radius / 2)
                {
                    picDisplay.Cursor = Cursors.Hand;
                    particle.DrawDebugInfo(g);
                    UpdateCanvas();
                    infoDrawn = true;
                    break;
                }
                else
                {
                    picDisplay.Cursor = Cursors.Default;
                }
            }

            if (!infoDrawn)
            {
                ClearCanvas(g, BackgroundColor);
                Emitter.Render(g);
                UpdateCanvas();
            }
            DebugForm.UpdateMousePositionIndication(e.X, e.Y);
        }
        else
        {
            foreach (var particle in Emitter.particles)
            {
                particle.ShowDebugInfo = false;
            }
        }
    }


    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        picDisplay.Image = new Bitmap(ActiveForm!.Size.Width, ActiveForm!.Size.Height);
    }

    private void debugToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(IsDebugEnabled) return;
        DebugForm = new DebugForm(this);
        DebugForm.Show();
    }

    private void picDisplay_MouseClick(object sender, MouseEventArgs e)
    {
        if (IsDebugEnabled)
        {
            foreach (var particle in Emitter.particles)
            {
                var dx = Math.Abs(Math.Abs(particle.X) - Math.Abs(e.X));
                var dy = Math.Abs(Math.Abs(particle.Y) - Math.Abs(e.Y));
                var distance = Math.Sqrt(dx * dx + dy * dy);
                if (distance <= particle.Radius / 2)
                {
                    using var g = Graphics.FromImage(picDisplay.Image);
                    particle.ShowDebugInfo = !particle.ShowDebugInfo;
                    particle.DrawDebugInfo(g);
                    UpdateCanvas();
                    return;
                }
            }
        }
    }
}