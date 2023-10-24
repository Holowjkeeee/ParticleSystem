namespace ParticleSystem;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        // �������� �����������
        picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        //for (int i = 0; i < 100; i++)
        //{
        //    particles.Add(new Particle(picDisplay.Image.Width / 2, picDisplay.Image.Height / 2));
        //}
    }

    private List<Particle> particles = new();
    // ��������� ���������� ��� �������� ��������� ����
    private int MousePositionX = 0;
    private int MousePositionY = 0;


    // ������� ������� ���������� ��������� �������
    private void UpdateState()
    {
        foreach (var particle in particles)
        {
            particle.Life -= 1; // �������� ��������
            // ���� �������� ���������
            if (particle.Life < 0)
            {
                // �������������� ��������
                particle.Life = 20 + Particle.Rand.Next(100);
                // ��������� ������� � �����
                //particle.X = picDisplay.Image.Width / 2;
                //particle.Y = picDisplay.Image.Height / 2;
                // ����� ��������� ������������ ������� � ��� ��, ���� ��������� ������
                particle.X = MousePositionX;
                particle.Y = MousePositionY;
                // ����� ��������� �����������, �������� � ������
                particle.Direction = Particle.Rand.Next(360);
                particle.Speed = 1 + Particle.Rand.Next(10);
                particle.Radius = 2 + Particle.Rand.Next(10);
            }
            else
            {
                // � ��� ��� ������ ���
                var directionInRadians = particle.Direction / 180 * Math.PI;
                particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
            }
        }

        // ������� ��������� ������
        // ��������� �� ����� 10 ���� �� ���
        for (var i = 0; i < 10; ++i)
        {
            if (particles.Count > 500) return; // ���� ������ ������ 500 ���������� �����
            var particle = new ParticleColorful();
            // �� � ����� ������
            particle.FromColor = Color.Yellow;
            particle.ToColor = Color.FromArgb(0, Color.Magenta);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;
            particles.Add(particle);
            
        }
    }

    // ������� ����������
    private void Render(Graphics g)
    {
        // ������� ���� ��������� ������
        foreach (var particle in particles)
        {
            particle.Draw(g);
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        UpdateState();

        using var g = Graphics.FromImage(picDisplay.Image);
        // ����� �� ����������� ������� ��������
        g.Clear(Color.Black); // ������� �������
        Render(g);

        // �������� picDisplay
        picDisplay.Invalidate();
    }

    private void picDisplay_MouseMove(object sender, MouseEventArgs e)
    {
        // � ����������� ������� ��������� ���� � ���������� ��� �������� ��������� ����
        MousePositionX = e.X;
        MousePositionY = e.Y;
    }
}
