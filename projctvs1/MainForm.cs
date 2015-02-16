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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///Student///
            label6.Text = DateTime.Now.ToLongTimeString();
            label7.Text = DateTime.Now.ToLongDateString();
            ///Home//
            label9.Text = DateTime.Now.ToLongTimeString();
            label8.Text = DateTime.Now.ToLongDateString();
            ///Setting//
            label11.Text = DateTime.Now.ToLongTimeString();
            label10.Text = DateTime.Now.ToLongDateString();
            ///Report//
            label13.Text = DateTime.Now.ToLongTimeString();
            label12.Text = DateTime.Now.ToLongDateString();
            ///Librarian//
            label15.Text = DateTime.Now.ToLongTimeString();
            label14.Text = DateTime.Now.ToLongDateString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button5.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AddStud adstud = new AddStud();
            adstud.ShowDialog();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            EditStud edstud = new EditStud();
            edstud.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DelStud delStude = new DelStud();
            delStude.ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            SearchBook searbook = new SearchBook();

            searbook.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Notifier a = new Notifier();
            a.Show();
        }

        
    }
}
