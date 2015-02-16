using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projctvs1
{
    public partial class LogSplash : Form
    {
        public LogSplash()
        {
            InitializeComponent();
        }
        Timer t1 = new Timer();
        private void LogSplash_Load(object sender, EventArgs e)
        {
            Opacity = 0;

            t1.Interval = 100;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }
        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                t1.Stop();
                timer1.Start();
            }
            else
                Opacity += 0.05;

        }
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            t1.Tick += new EventHandler(fadeOut);
            t1.Start();

            if (Opacity == 0)
                e.Cancel = false;

        }
        void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                t1.Stop();
                timer1.Stop();
                Close();
            }
            else
                Opacity -= 0.05;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MainForm d = new MainForm();

            this.progressBar1.Increment(5);
            if (progressBar1.Value == 100)
            {
                t1.Stop();
                timer1.Stop();
                progressBar1.Value = 0;
                this.Hide();
                d.Show();
            }


        }
    }
}