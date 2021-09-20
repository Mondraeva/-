using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пр15
{
    public partial class Form7 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form7()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
                Application.Exit();
            Properties.Settings.Default.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            secondForm.Show();
            this.Hide();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Opacity = Properties.Settings.Default.Prozr;

            if (Properties.Settings.Default.BackImage == "NULL")
            {

            }
            else
            {
                BackgroundImage = Image.FromFile(Properties.Settings.Default.BackImage);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    // Считывание начальных данных
            //    double x0 = Convert.ToDouble(textBox1.Text); double xk = Convert.ToDouble(textBox2.Text); double dx = Convert.ToDouble(textBox3.Text);
            //    if ((textBox1.Text == "") | (textBox2.Text == "") | (textBox3.Text == "")) MessageBox.Show("Есть не заполненое поле!", "Сообщение");
            //    else
            //        textBox4.Text += "Работу выполнил ст. Мондраева Д.И." + Environment.NewLine;
            //    double x = x0;
            //    // Цикл для табулирования функции
            //    while (x <= (xk + dx / 2))
            //    {
            //        double y = 9 * Math.Pow(x, 4) + Math.Sin(57.2 + x);
            //        textBox4.Text += "x=" + Convert.ToString(x) + Environment.NewLine + 
            //            ";y=" + Convert.ToString(y) + Environment.NewLine;
            //        x = x + dx;
            //    }
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("Введено не число!", "Сообщение");
            //}

            double dx = 0.2;
            double xmin = -2.05;
            double xmax = -0.75;
            int count = (int)Math.Ceiling((xmax - xmin) / dx) + 1;

            double[] x = new double[count];
            double[] y = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = xmin + dx * i;
                y[i] = 9 * Math.Pow(x[i], 4) + Math.Sin(57.2+x[i]);
                textBox4.Text += $"x[{i}]=" + x[i].ToString() + 
                    $"\t\t y[{i}]=" + Math.Round(y[i], 4).ToString() + Environment.NewLine;
            }
            textBox4.Text = textBox4.Text.Trim();
            textBox4.Visible = true;
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            chart1.Series[0].Points.DataBindXY(x, y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
