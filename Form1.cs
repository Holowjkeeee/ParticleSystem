namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // �������� �����������
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }
        int counter = 0; // ������� ������� ����� ������� ������ �������
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++; // ���������� �������� �������� ������ �����
            using var g = Graphics.FromImage(picDisplay.Image);
            // ����� �� ����������� ������� ��������
            g.Clear(Color.White); // ������� �������
            g.DrawString(
                counter.ToString(), // �������� �������� � ���� ������
                new Font("Arial", 12), // �����
                new SolidBrush(Color.Black), // ����
                new PointF
                { // �� ������ ������
                    X = picDisplay.Image.Width / 2,
                    Y = picDisplay.Image.Height / 2
                }
            );

            // �������� picDisplay
            picDisplay.Invalidate();
        }
    }
}