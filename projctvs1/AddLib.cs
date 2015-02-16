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


namespace projctvs1
{
    public partial class AddLib : Form
    {
       

        public AddLib()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand cmd = new MySqlCommand(@"Insert into tbl_librarianprofile (librarianID, librarianIDCard, librarianPass, 
                    librarianLname, librarianFname, librarianMname, librarianAddress, librarianContactNo, librarianEmail, 
                    librarianPhoto) values (null, @libidcard, @libpass, @liblname, @libfname, @libmname, @libaddress,
                    @libcontact, @libemail, @libphoto)", conn);

                conn.Open();

                cmd.Parameters.Add("@libidcard", MySqlDbType.VarChar, 7).Value = librarianLname.Text;
                cmd.Parameters.Add("@libpass", MySqlDbType.VarChar, 75).Value = SaltHash.getHash(confirmPass.Text, "SHA256", null);
                cmd.Parameters.Add("@liblname", MySqlDbType.VarChar, 45).Value = librarianLname.Text;
                cmd.Parameters.Add("@libfname", MySqlDbType.VarChar, 45).Value = librarianFname.Text;
                cmd.Parameters.Add("@libmname", MySqlDbType.VarChar, 45).Value = librarianMname.Text;
                cmd.Parameters.Add("@libaddress", MySqlDbType.VarChar, 55).Value = address.Text;
                cmd.Parameters.Add("@libcontact", MySqlDbType.VarChar, 11).Value = contact.Text;
                cmd.Parameters.Add("@libemail", MySqlDbType.VarChar, 45).Value = email.Text;
                cmd.Parameters.Add("@libphoto", MySqlDbType.VarChar, 55).Value = null;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                MessageBox.Show("Registration Successful!");


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Registration failed." + ex);
            }
            
        }
 


            

        
    }
}
