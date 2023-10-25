namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // �������� �����������
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

        this.emitter = new ParticleEmitter() // ������ ������� � ���������� ��� � ���� emitter
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

        emitters.Add(this.emitter); // ��� ����� �������� � ������ emitters, ����� �� ���������� � ����������

        //// ��������
        //emitter.impactPoints.Add(new GravityPoint
        //{
        //    X = (float)(picDisplay.Width * 0.25),
        //    Y = picDisplay.Height / 2
        //});

        //// � ������ ������������
        //emitter.impactPoints.Add(new AntiGravityPoint
        //{
        //    X = picDisplay.Width / 2,
        //    Y = picDisplay.Height / 2
        //});

        //// ����� ��������
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
        // ����� �� ����������� ������� ��������
        g.Clear(Color.Black); // ������� �������
        emitter.Render(g); // � ��� ������ �������� ����� �������


        picDisplay.Invalidate();// �������� picDisplay
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        emitter.MousePositionX = e.X;
        emitter.MousePositionY = e.Y;
    }

    private void tbDirection_Scroll(object sender, EventArgs e)
    {
        emitter.Direction = tbDirection.Value;
        lblDirection.Text = $"{tbDirection.Value}�"; // ������� ����� ��������
    }
}
