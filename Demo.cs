using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asset_Mng
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }
        public static int counter = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                timer1.Stop();

                counter = 3;

                textBox1.Text = "Kimia Hasazadeh";
                timer2.Start();
            }
            counter--;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (counter == 0)
            {

                timer2.Stop();
                textBox1.Text = "University of Science and Culture";
                counter = 5;

                timer3.Start();
            }
            counter--;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            if (counter == 0)
            {

                timer3.Stop();
                this.Hide();
                Main frm = new Main();
                frm.ShowDialog();

            }
            counter--;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
        }

        private void Demo_Load(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            counter = 3;

            timer1.Start();
            textBox1.Text = "Produced by :";
        }
    }
}