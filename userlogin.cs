using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate_Generator
{
    public partial class userlogin : Form
    {
        public static string semail;
        public userlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local ; database = Certificategenerator; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from usertable where username = '" + usernametextbox.Text + "' and pass ='" + userpasstextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count != 0)
            {
                semail = usernametextbox.Text;

                MessageBox.Show("Username and Password is correct", "Correct", MessageBoxButtons.OK,MessageBoxIcon.Information);

                userdashboard userdashboard = new userdashboard();
                userdashboard.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                usernametextbox.Clear();
                userpasstextbox.Clear();
                usernametextbox.Focus();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernametextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (usernametextbox.Text == "Enter E-mail")
            {
                usernametextbox.Clear();
            }
        }

        private void userpasstextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (userpasstextbox.Text == "Password")
            {
                userpasstextbox.Clear();
                userpasstextbox.UseSystemPasswordChar = true;
            }
        }

        private void userpassshowcheakbox_CheckedChanged(object sender, EventArgs e)
        {
            if (userpassshowcheakbox.Checked == true)
            {
                userpasstextbox.UseSystemPasswordChar = false;
            }
            else
            {
                userpasstextbox.UseSystemPasswordChar = true;
            }
        }

        private void usersignupbutton_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }
    }
}
