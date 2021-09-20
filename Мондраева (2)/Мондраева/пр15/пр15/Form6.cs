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
    public partial class Form6 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form6()
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Opacity = Properties.Settings.Default.Prozr;

            if (Properties.Settings.Default.BackImage == "NULL")
            {

            }
            else
            {
                BackgroundImage = Image.FromFile(Properties.Settings.Default.BackImage);
            }

            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Введите число");

            ToolTip y = new ToolTip();
            y.SetToolTip(textBox2, "Введите число");

            ToolTip i = new ToolTip();
            i.SetToolTip(textBox3, "Результат");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Получение исходных данных из TextBox
            double x = Convert.ToDouble(textBox1.Text);
            double m = Convert.ToDouble(textBox2.Text);

            // Ввод исходных данных в окно результатов
            textBox3.Text += "При X = " + textBox1.Text + Environment.NewLine;
            textBox3.Text += "При M = " + textBox2.Text + Environment.NewLine;

            // Определение номера выбранной функции
            int n = 0;
            if (radioButton2.Checked) n = 1;
            else if (radioButton3.Checked) n = 2;

            double j;
            switch (n)
            {
                case 0:
                    if ((m > -1) | (m < x)) j = Math.Sin(5 * Math.Exp(x) - Math.Exp(-x)) / 2 + 3 * m * Math.Abs((Math.Exp(x) - Math.Exp(-x)) / 2);
                    else if (x < m) j = Math.Cos(3 * Math.Exp(x) - Math.Exp(-x)) / 2 + 5 * m * Math.Abs((Math.Exp(x) - Math.Exp(-x)) / 2);
                    else j = (Math.Exp(x) - Math.Exp(-x)) / 2 + m * (Math.Exp(x) - Math.Exp(-x)) / 2 + m;
                    textBox3.Text += "j = " + Convert.ToString(j) + Environment.NewLine;
                    break;
                case 1:
                    if ((m > -1) | (m < x)) j = Math.Sin(5 * x * x + 3 * m * Math.Abs(x * x));
                    else if (x < m) j = Math.Cos(3 * x * x + 5 * m * Math.Abs(x * x));
                    else j = (x * x + m) * (x * x + m);
                    textBox3.Text += " j = " + Convert.ToString(j) + Environment.NewLine;
                    break;
                case 2:
                    if ((m > -1) | (m < x)) j = Math.Sin(5 * Math.Exp(x) + 3 * m * Math.Abs(Math.Exp(x)));
                    else if (x < m) j = Math.Cos(3 * Math.Exp(x) + 5 * m * Math.Abs(Math.Exp(x)));
                    else j = (Math.Exp(x) + m) * (Math.Exp(x) + m); ;
                    textBox3.Text += "j = " + Convert.ToString(j) + Environment.NewLine;
                    break;
                default:
                    textBox3.Text += "Решение не найдено" + Environment.NewLine;
                    break;
            }

         


        }
    }
}
