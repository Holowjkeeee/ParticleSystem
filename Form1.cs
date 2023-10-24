namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // �������� �����������
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        // ������� �������
        emitter.gravityPoints.Add(new Point(
            picDisplay.Width / 2, picDisplay.Height / 2
        ));
        // ������� ��� ���        
        emitter.gravityPoints.Add(new Point(
            (int)(picDisplay.Width * 0.75), picDisplay.Height / 2
        ));

        emitter.gravityPoints.Add(new Point(
            (int)(picDisplay.Width * 0.25), picDisplay.Height / 2
        ));
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
