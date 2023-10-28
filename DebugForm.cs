using System.Text.RegularExpressions;

namespace ParticleSystem;

public partial class DebugForm : Form
{
    public CanvasForm CanvasForm;

    public DebugForm(CanvasForm canvasForm)
    {
        InitializeComponent();
        this.CanvasForm = canvasForm;
        CanvasForm.IsDebugEnabled = true;
        ResetDebugControls();
    }

    private void DebugForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        CanvasForm.IsDebugEnabled = false;
        CanvasForm.MaxFps = Defaults.MaxFps;
        CanvasForm.Emitter.IsSpeedVectorVisible = false;
        CanvasForm.CurrentFps = Defaults.CurrentFps;
        foreach (var particle in CanvasForm.Emitter.particles)
        {
            particle.ShowDebugInfo = false;
        }
        ResetDebugControls();
    }

    public void ResetDebugControls()
    {
        DebugMaxFPS_NumericUpDown.Value = CanvasForm.MaxFps;
        CurrentFPS_TextBox.Text = CanvasForm.CurrentFps.ToString();
        DebugSpeed_TrackBar.Value = 100;
        CanvasForm.GetTimer().Interval = Defaults.ONE_SECOND / Defaults.CurrentFps;
        CanvasForm.GetTimer().Enabled = true;
        ShowSpeedVectors_CheckBox.Checked = Defaults.ShowSpeedVectors;
        DebugNextStep_Button.Visible = false;
        DebugPreviousStep_Button.Visible = false;
        UpdatePreviousStateButtonText();
    }

    private void DebugMaxFPS_NumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        CanvasForm.MaxFps = (int)DebugMaxFPS_NumericUpDown.Value;
    }

    private void DebugPreviousStep_Button_Click(object sender, EventArgs e)
    {
        CanvasForm.Emitter.RestorePreviousState();
        UpdatePreviousStateButtonText();
        using var g = Graphics.FromImage(CanvasForm.GetCanvas().Image);
        CanvasForm.ClearCanvas(g, CanvasForm.BackgroundColor);
        CanvasForm.Emitter.Render(g);
        CanvasForm.UpdateCanvas();
    }

    public void UpdateMousePositionIndication(int x, int y)
    {
        MouseX_TextBox.Text = x.ToString();
        MouseY_TextBox.Text = y.ToString();
    }

    private void DebugSpeed_TrackBar_Scroll(object sender, EventArgs e)
    {
        DebugNextStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        DebugPreviousStep_Button.Visible = DebugSpeed_TrackBar.Value == 0;
        if (DebugSpeed_TrackBar.Value != 0)
        {
            CanvasForm.CurrentFps = (int)(DebugSpeed_TrackBar.Value / 100f * CanvasForm.MaxFps);
            try
            {
                CanvasForm.GetTimer().Interval = Defaults.ONE_SECOND / CanvasForm.CurrentFps;
                CurrentFPS_TextBox.Text = CanvasForm.CurrentFps.ToString();
                CanvasForm.GetTimer().Enabled = true;
            }
            catch (DivideByZeroException) { }
        }
        else
        {
            CurrentFPS_TextBox.Text = "0";
            CanvasForm.GetTimer().Enabled = false;
            DebugPreviousStep_Button.Text = Regex.Replace(
                DebugPreviousStep_Button.Text,
                @"\d+",
                (CanvasForm.Emitter.StatesStorage.Count - 1).ToString()
            );
            CanvasForm.Emitter.CurrentStateIndex = CanvasForm.Emitter.StatesStorage.Count - 1;
        }
    }

    private void ShowSpeedVectors_CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        CanvasForm.ShowVectorSpeed = ShowSpeedVectors_CheckBox.Checked;
        foreach (var emitter in CanvasForm.Emitters)
        {
            emitter.IsSpeedVectorVisible = CanvasForm.ShowVectorSpeed;
        }
    }

    public void UpdatePreviousStateButtonText()
    {
        DebugPreviousStep_Button.Text = Regex.Replace(
            DebugPreviousStep_Button.Text,
            @"\d+",
            CanvasForm.Emitter.CurrentStateIndex.ToString()
        );

        DebugPreviousStep_Button.Enabled = CanvasForm.Emitter.CurrentStateIndex != 0;
    }

    private void DebugNextStep_Button_Click(object sender, EventArgs e)
    {
        if (CanvasForm.Emitter.CurrentStateIndex >= CanvasForm.Emitter.StatesStorage.Count - 1)
        {
            CanvasForm.timer1_Tick(this, EventArgs.Empty);
            CanvasForm.Emitter.CurrentStateIndex = CanvasForm.Emitter.StatesStorage.Count - 1;
            UpdatePreviousStateButtonText();
        }
        else if (CanvasForm.Emitter.CurrentStateIndex < CanvasForm.Emitter.StorageSize - 1)
        {
            CanvasForm.Emitter.RestoreNextState();
            UpdatePreviousStateButtonText();
            using var g = Graphics.FromImage(CanvasForm.GetCanvas().Image);
            CanvasForm.ClearCanvas(g, CanvasForm.BackgroundColor);
            CanvasForm.Emitter.Render(g);
            CanvasForm.UpdateCanvas();
        }
        else
        {
            CanvasForm.timer1_Tick(this, EventArgs.Empty);
        }
    }
}
