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
    public partial class AddStud : Form
    {
        public AddStud()
        {
            InitializeComponent();
        }

      
        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
           panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           panel3.Visible = false;
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

    }
}
