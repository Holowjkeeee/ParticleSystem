namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }
        int counter = 0; // добавлю счетчик чтобы считать вызовы функции
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++; // увеличиваю значение счетчика каждый вызов
            using var g = Graphics.FromImage(picDisplay.Image);
            // рисую на изображении сколько насчитал
            g.Clear(Color.White); // добавил очистку
            g.DrawString(
                counter.ToString(), // значения счетчика в виде строки
                new Font("Arial", 12), // шрифт
                new SolidBrush(Color.Black), // цвет
                new PointF
                { // по центру экрана
                    X = picDisplay.Image.Width / 2,
                    Y = picDisplay.Image.Height / 2
                }
            );

            // обновить picDisplay
            picDisplay.Invalidate();
        }
    }
}