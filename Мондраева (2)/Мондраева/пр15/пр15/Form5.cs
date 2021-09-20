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
    public partial class Form5 : Form
    {

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;


        public Form5()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
                Application.Exit();

            Properties.Settings.Default.Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            secondForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x, y, z, f;

            try
            {
                if ((textBox1.Text == "") | (textBox2.Text == "") | (textBox3.Text == "")) MessageBox.Show("Есть не заполненое поле!", "Сообщение");
                else
                {
                    x = Convert.ToDouble(textBox1.Text);
                    y = Convert.ToDouble(textBox2.Text);
                    z = Convert.ToDouble(textBox3.Text);
                    f = (((Math.Exp(x - y) * Math.Pow(Math.Abs(x - y), x + y)) / (Math.Atan(x) + Math.Atan(z))) + (Math.Pow(Math.Sqrt(x) + Math.Sqrt(Math.Log(y)), 1 / 3)));

                    textBox4.Text = "" + f;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено не число!", "Сообщение");
            }

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
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

            ToolTip  y= new ToolTip();
            y.SetToolTip(textBox2, "Введите число");

            ToolTip r = new ToolTip();
            r.SetToolTip(textBox3, "Введите число");

            ToolTip i = new ToolTip();
            i.SetToolTip(textBox4, "Результат");
        }
    }
}
