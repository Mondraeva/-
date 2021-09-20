using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace пр15
{
    public partial class Form4 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;


        public Form4()
        {
            InitializeComponent();

            button3.Click += button3_Click;

            colorDialog1.FullOpen = true;

            colorDialog1.Color = this.BackColor;

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

            button8.Click += button8_Click;
            // добавляем возможность выбора цвета шрифта
            fontDialog1.ShowColor = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            this.BackColor = colorDialog1.Color;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            secondForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
                Application.Exit();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
         

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Width = Int32.Parse(textBox1.Text); // берет число с текстбоса1 и записывает в "а"
            this.Height = Int32.Parse(textBox2.Text); //берет число с текстбоса2 и записывает в "в"



        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            button8.Font = fontDialog1.Font;
            // установка цвета шрифта
            button8.ForeColor = fontDialog1.Color;

        }




        private void button5_Click(object sender, EventArgs e)
        {
            int r = 0; int o = 0;
            r = Int32.Parse(textBox3.Text); // берет число с текстбоса1 и записывает в "а"
            o = Int32.Parse(textBox4.Text); //берет число с текстбоса2 и записывает в "в"

            Location = new Point(r, o);

        }



        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.Prozr = ((double)(trackBar1.Value) / 10.0);
            this.Opacity = Properties.Settings.Default.Prozr;
            Properties.Settings.Default.Save();
            label1.Text = "процент прозрачности: " + trackBar1.Value * 10 + " %";
        }


        private void button7_Click(object sender, EventArgs e)
        {
            var IMG = new System.Windows.Forms.OpenFileDialog();
            IMG.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (IMG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = IMG.FileName;
                Properties.Settings.Default.BackImage = IMG.FileName;
                Properties.Settings.Default.Save();
                BackgroundImage = Image.FromFile(Properties.Settings.Default.BackImage);
                System.IO.FileInfo File = new System.IO.FileInfo(Properties.Settings.Default.BackImage);
                BackgroundImage = Image.FromFile(Properties.Settings.Default.BackImage);
            }

        }
    }
}

