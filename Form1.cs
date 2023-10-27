using System.Text.RegularExpressions;

namespace ParticleSystem;

public partial class Form1 : Form
{
    public Color BackgroundColor = Color.Black;

    public Form1()
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
            X = picDisplay.Width / 2 + 100,
            Y = picDisplay.Height / 2,
        };
        point2 = new GravityPoint
        {
            X = picDisplay.Width / 2 - 100,
            Y = picDisplay.Height / 2,
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
    }

    GravityPoint point1;
    GravityPoint point2;

    private ParticleEmitter emitter;
    List<ParticleEmitter> emitters = new();

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

        point2.X = e.X;
        point2.Y = e.Y;
    }


    private void tbDirection_Scroll(object sender, EventArgs e)
    {
        emitter.Direction = tbDirection.Value;
        lblDirection.Text = $"{tbDirection.Value}°";
    }

    private void tbGraviton_Scroll(object sender, EventArgs e)
    {
        point1.Power = tbGraviton1.Value;
    }

    private void tbGraviton2_Scroll(object sender, EventArgs e)
    {
        point2.Power = tbGraviton2.Value;
    }

    private void DebugMode_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        Debug_Group.Visible = DebugMode_CheckBox.Checked;
        // todo reset all debug changes on debug off
    }


    private void DebugSpeed_TrackBar_Scroll(object sender, EventArgs e)
    {
        DebugNextStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        DebugPreviousStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        if (DebugSpeed_TrackBar.Value != 0)
        {
            float maxFPS = int.Parse(DebugMaxFPS_TextBox.Text);
            int currentFPS = (int)(DebugSpeed_TrackBar.Value / 100f * maxFPS);
            try
            {
                timer1.Interval = 1000 / currentFPS;
                CurrentFPS_Label.Text = currentFPS.ToString();
                timer1.Enabled = true;
            }
            catch (DivideByZeroException) { }
        }
        else
        {
            CurrentFPS_Label.Text = "0";
            timer1.Enabled = false;
        }
    }

    private void ShowSpeedVectors_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        foreach (var emitter in emitters)
        {
            emitter.IsSpeedVectorVisible = ShowSpeedVectors_CheckBox.Checked;
        }
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
        picDisplay.Width = ActiveForm!.Size.Width;
        picDisplay.Image = new Bitmap(ActiveForm.Size.Width, picDisplay.Height);
    }

    private void DebugNextStep_Button_Click(object sender, EventArgs e)
    {
        if (emitter.CurrentRestoredState < emitter.StorageSize && emitter.CurrentRestoredState < emitter.StatesStorage.Count)
        {
            emitter.RestoreNextState();
            UpdatePreviousStateButton();
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

    private void UpdatePreviousStateButton()
    {
        DebugPreviousStep_Button.Text = Regex.Replace(DebugPreviousStep_Button.Text, @"\d+", emitter.CurrentRestoredState.ToString());
        DebugPreviousStep_Button.Enabled = emitter.CurrentRestoredState != 0;
    }

    private void DebugPreviousStep_Button_Click(object sender, EventArgs e)
    {
        emitter.RestorePreviousState();
        UpdatePreviousStateButton();

        using var g = Graphics.FromImage(picDisplay.Image);
        ClearScreen(g, BackgroundColor);
        emitter.Render(g);
        picDisplay.Invalidate(); // обновить picDisplay
    }
}