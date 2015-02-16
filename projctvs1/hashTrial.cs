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
    public partial class hashTrial : Form
    {
        string password;
  
        public hashTrial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password = textBox1.Text;
            textBox2.Text = SaltHash.getHash(password, "SHA256", null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a;
            password = textBox1.Text;
            a = SaltHash.compareHash(textBox4.Text, "SHA256", textBox2.Text);

            if (a == true)
                textBox3.Text = "True";
            else
                textBox3.Text = "False";
            

        }
    }
}
