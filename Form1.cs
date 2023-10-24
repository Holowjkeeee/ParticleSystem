namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // �������� �����������
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
    }

    ParticleEmitter emitter = new(); // �������� �������


    private void timer1_Tick(object sender, EventArgs e)
    {
        emitter.UpdateState(); // ��� ������ ��������� �������

        using var g = Graphics.FromImage(picDisplay.Image);
        // ����� �� ����������� ������� ��������
        g.Clear(Color.Black); // ������� �������
        emitter.Render(g); // � ��� ������ �������� ����� �������

        // �������� picDisplay
        picDisplay.Invalidate();
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        // � ��� � ������� �������� ��������� �����
        emitter.MousePositionX = e.X;
        emitter.MousePositionY = e.Y;
    }
}
