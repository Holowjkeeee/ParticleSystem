using System.Text.RegularExpressions;

namespace ParticleSystem;

record Defaults
{
    public static int CurrentFPS = 60;
    public static int MaxFPS = 60;
    public const int ONE_SECOND = 1000;
    public static bool ShowSpeedVectors = false;
}

public partial class CanvasForm : Form
{
    public Color BackgroundColor = Color.Black;
    public int CurrentFPS = Defaults.CurrentFPS;
    public int MaxFPS = Defaults.MaxFPS;
    public bool ShowVectorSpeed = Defaults.ShowSpeedVectors;

    GravityPoint point1;
    GravityPoint point2;

    private ParticleEmitter emitter;
    List<ParticleEmitter> emitters = new();


    public CanvasForm()
    {
        InitializeComponent();
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        emitter = new ParticleEmitter()
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

        emitters.Add(emitter);

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

        //emitter.impactPoints.Add(point1);
        //emitter.impactPoints.Add(point2);

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

        ResetDebugControls();
    }


    private void timer1_Tick(object sender, EventArgs e)
    {
        emitter.UpdateState();
        emitter.SaveState();

        using var g = Graphics.FromImage(picDisplay.Image);
        ClearScreen(g, BackgroundColor);

        foreach (var emitter in emitters)
        {
            emitter.Render(g);
        }

        picDisplay.Invalidate(); // обновить picDisplay
    }

    private void ResetDebugControls()
    {
        DebugMaxFPS_NumericUpDown.Value = MaxFPS;
        CurrentFPS_TextBox.Text = CurrentFPS.ToString();
        DebugSpeed_TrackBar.Value = 100;
        timer1.Interval = Defaults.ONE_SECOND / Defaults.CurrentFPS;
        timer1.Enabled = true;
        ShowSpeedVectors_CheckBox.Checked = Defaults.ShowSpeedVectors;
        DebugNextStep_Button.Visible = false;
        DebugPreviousStep_Button.Visible = false;
        UpdatePreviousStateButtonText();
    }

    private void ClearScreen(Graphics g, Color color)
    {
        g.Clear(color);
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        //if ()
        //foreach (var _emitter in emitters)
        //{
        //    _emitter.X = e.X;
        //    _emitter.Y = e.Y;
        //}
        if (DebugMode_CheckBox.Checked)
        {
            foreach (var particle in emitter.particles)
            {
                var dx = Math.Abs(Math.Abs(particle.X) - Math.Abs(e.X));
                var dy = Math.Abs(Math.Abs(particle.Y) - Math.Abs(e.Y));
                var distance = Math.Sqrt(dx * dx + dy * dy);
                if (particle.Radius / 2 <= distance)
                {
                    using var g = Graphics.FromImage(picDisplay.Image);
                    particle.ShowDebugInfo = true;
                }
                else
                {
                    particle.ShowDebugInfo = false;
                }
            }
        }

        DebugInfo_Label.Text = $"{e.X}\n{e.Y}";

        point2.X = e.X;
        point2.Y = e.Y;
    }


    private void DebugMode_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        Debug_Group.Visible = DebugMode_CheckBox.Checked;
        if (!DebugMode_CheckBox.Checked)
        {
            MaxFPS = Defaults.MaxFPS;
            emitter.IsSpeedVectorVisible = false;
            CurrentFPS = Defaults.CurrentFPS;
            ResetDebugControls();
        }
    }


    private void DebugSpeed_TrackBar_Scroll(object sender, EventArgs e)
    {
        DebugNextStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        DebugPreviousStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        if (DebugSpeed_TrackBar.Value != 0)
        {
            CurrentFPS = (int)(DebugSpeed_TrackBar.Value / 100f * MaxFPS);
            try
            {
                timer1.Interval = Defaults.ONE_SECOND / CurrentFPS;
                CurrentFPS_TextBox.Text = CurrentFPS.ToString();
                timer1.Enabled = true;
            }
            catch (DivideByZeroException) { }
        }
        else
        {
            CurrentFPS_TextBox.Text = "0";
            timer1.Enabled = false;
            DebugPreviousStep_Button.Text = Regex.Replace(
                    DebugPreviousStep_Button.Text,
                    @"\d+",
                    (emitter.StatesStorage.Count - 1).ToString()
            );
            emitter.CurrentStateIndex = emitter.StatesStorage.Count - 1;
        }
    }

    private void ShowSpeedVectors_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        ShowVectorSpeed = ShowSpeedVectors_CheckBox.Checked;
        foreach (var emitter in emitters)
        {
            emitter.IsSpeedVectorVisible = ShowVectorSpeed;
        }
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        picDisplay.Width = ActiveForm!.Size.Width;
        picDisplay.Image = new Bitmap(ActiveForm.Size.Width, picDisplay.Height);
    }

    public void DebugNextStep_Button_Click(object sender, EventArgs e)
    {
        if (emitter.CurrentStateIndex >= emitter.StatesStorage.Count - 1)
        {
            timer1_Tick(this, EventArgs.Empty);
            emitter.CurrentStateIndex = emitter.StatesStorage.Count - 1;
            UpdatePreviousStateButtonText();
        }
        else if (emitter.CurrentStateIndex < emitter.StorageSize - 1)
        {
            emitter.RestoreNextState();
            UpdatePreviousStateButtonText();
            using var g = Graphics.FromImage(picDisplay.Image);
            ClearScreen(g, BackgroundColor);
            emitter.Render(g);
            picDisplay.Invalidate(); // обновить picDisplay
        }
        else
        {
            timer1_Tick(this, EventArgs.Empty);
        }
    }

    private void UpdatePreviousStateButtonText()
    {
        DebugPreviousStep_Button.Text = Regex.Replace(
        DebugPreviousStep_Button.Text,
        @"\d+",
        emitter.CurrentStateIndex.ToString()
        );

        DebugPreviousStep_Button.Enabled = emitter.CurrentStateIndex != 0;
    }

    private void DebugPreviousStep_Button_Click(object sender, EventArgs e)
    {
        emitter.RestorePreviousState();
        UpdatePreviousStateButtonText();
        using var g = Graphics.FromImage(picDisplay.Image);
        ClearScreen(g, BackgroundColor);
        emitter.Render(g);
        picDisplay.Invalidate(); // обновить picDisplay
    }

    private void DebugMaxFPS_NumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        MaxFPS = (int)DebugMaxFPS_NumericUpDown.Value;
    }
}