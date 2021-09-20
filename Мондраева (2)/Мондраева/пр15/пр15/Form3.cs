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
    public partial class Form3 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public Form3()
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

        int h1 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            switch (rnd.Next(0, 5))
            {
                case 0:
                    Button bt = new Button();
                    bt.Width = rnd.Next(70, 300);
                    bt.Text = "кнопочка";
                    bt.Location = new Point(10, 20 + 40 * h1);
                    bt.Visible = true;
                    bt.BringToFront();
                    Controls.Add(bt);
                    break;
                case 1:
                    Label lb = new Label();
                    lb.AutoSize = false;
                    lb.Width = rnd.Next(70, 300);
                    lb.BorderStyle = BorderStyle.FixedSingle;
                    lb.Text = "Label";
                    lb.Location = new Point(10, 20 + 40 * h1);
                    lb.Visible = true;
                  
                    Controls.Add(lb);
                    break;
                case 2:
                    TextBox tb = new TextBox();
                    tb.Width = rnd.Next(70, 300);
                    tb.Text = "TextBox";
                    tb.Location = new Point(10, 20 + 40 * h1);
                    tb.Visible = true;               
                    Controls.Add(tb);
                    break;
                case 3:
                    CheckBox cb = new CheckBox();
                    cb.Width = rnd.Next(70, 300);
                    cb.Text = "ComboBox";
                    cb.Location = new Point(10, 20 + 40 * h1);
                    cb.Visible = true;
                    Controls.Add(cb);
                    break;
            }
            h1 += 1;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
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
    }
}
