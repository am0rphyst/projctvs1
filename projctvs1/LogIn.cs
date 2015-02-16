using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.Util;
using ZXing;

namespace projctvs1
{
    public partial class LogIn : Form
    {
        Capture capture;
        bool Capturing;
        private readonly IBarcodeReaderImage reader;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        string value;
        
        
        public LogIn()
        {
            InitializeComponent();
            reader = new BarcodeReaderImage();
        }
        Timer t1 = new Timer();

        private void LogIn_Load(object sender, EventArgs e)
        {
            capturedvalue.Text = "";
            Opacity = 0;

            t1.Interval = 100;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }

            



        

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {

                identify.Enabled = true;
                
                t1.Stop();
            }
            else
            {
                identify.Enabled = false;
                Opacity += 0.05;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogSplash a = new LogSplash();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (capture != null)
                capture.Dispose();
        }

        private void DoDecoding(object sender, EventArgs args)
        {
            var image = capture.QueryFrame();
            if (image != null)
            {
                try
                {
                    using (image)
                    {
                        pictureBox1.Image = image.ToBitmap();
                        var result = reader.Decode(image);
                        if (result != null)
                        {
                            capturedvalue.Text = result.Text;              
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong. Please try again.");
                }
            }
        }

        private void identify_Click_1(object sender, EventArgs e)
        {
            //Start camera
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                catch (TypeInitializationException exc)
                {
                    MessageBox.Show(
                       "Unable to capture image. Necessary libraries not found." +
                       Environment.NewLine + Environment.NewLine + exc);
                }
            }

            if (capture != null)
            {
                if (Capturing)
                {
                    identify.Text = "Scan ID";
                    Application.Idle -= DoDecoding;
                }
                else
                {
                    identify.Text = "Stop Scanning";
                    Application.Idle += DoDecoding;
                }
                Capturing = !Capturing;
            }

            if (capturedvalue.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    MySqlCommand cmd = new MySqlCommand(@"Select librarianIDCard from
                                        tbl_librarianprofile where librarianIDCard = @captval", conn);
                    MySqlDataReader dr;

                    conn.Open();

                    cmd.Parameters.Add("@captval", MySqlDbType.VarChar, 45).Value = capturedvalue.Text;

                    dr = cmd.ExecuteReader();

                    value = dr.Read() ? dr.GetString(0) : "Nothing Found";

                       if (capturedvalue.Text == value)
                       {
                           MessageBox.Show("Hi! " + value + ".Please verify your identity.");
                           panel1.Visible = false;
                           panel2.Visible = true;
                       }

                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Failed to retrieve librarian ID." + ex);
                }
            }
        }

    }

}
