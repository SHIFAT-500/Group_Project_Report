using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Certificate_Generator
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            userlogin userlogin = new userlogin();
            userlogin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userlogin userlogin = new userlogin();
            userlogin.Show();
            this.Hide();
        }

        private void showpasscheakbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showpasscheakbox1.Checked == true)
            {
                passtextbox.UseSystemPasswordChar = false;
            }
            else
            {
                passtextbox.UseSystemPasswordChar = true;
            }
        }

        private void showpasscheakbox2_CheckedChanged(object sender, EventArgs e)
        {
            if (showpasscheakbox2.Checked == true)
            {
                confirmpasstextbox.UseSystemPasswordChar = false;
            }
            else
            {
                confirmpasstextbox.UseSystemPasswordChar = true;
            }
        }

        private void Useremailtextbox_TextChanged(object sender, EventArgs e)
        {
            useremailtextbox.BackColor = Color.White;
        }

        private void passtextbox_TextChanged(object sender, EventArgs e)
        {
            passtextbox.BackColor = Color.White;
        }

        private void confirmpasstextbox_TextChanged(object sender, EventArgs e)
        {
            confirmpasstextbox.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (useremailtextbox.Text == "")
            {
                useremailtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Email", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                useremailtextbox.Focus();
                return;
            }

            if (passtextbox.Text == "")
            {
                passtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passtextbox.Focus();
                return;
            }

            if (confirmpasstextbox.Text == "")
            {
                confirmpasstextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter Confirm Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmpasstextbox.Focus();
                return;
            }


            String username = useremailtextbox.Text;
            String password = passtextbox.Text;

            int n = username.Length;
            if (!(username == username.ToLower()))
            {
                MessageBox.Show("Invalid Email!! all alphabet will be in lower case", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                useremailtextbox.Focus();
                return;
            }

            if (!(username[n - 1] == 'm' && username[n - 2] == 'o' && username[n - 3] == 'c' && username[n - 4] == '.' && username[n - 5] == 'l' && username[n - 6] == 'i' && username[n - 7] == 'a' && username[n - 8] == 'm' && username[n - 9] == 'g' && username[n - 10] == '@'))
            {
                MessageBox.Show("Invalid Email", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                useremailtextbox.Focus();
                return;
            }


            // cheaking if email exists in database

            int count;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from usertable where username = '" + username + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                MessageBox.Show("Student Email aleady exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                useremailtextbox.Focus();
                return;
            }


            //inserting username and password in database

            if (password == confirmpasstextbox.Text)
            {
                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con2;

                con2.Open();
                cmd2.CommandText = " insert into usertable (username,pass) values ('" + username + "','" + password + "')";
                cmd2.ExecuteNonQuery();
                con2.Close();

                MessageBox.Show("Successfully Signed up!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else 
            {
                MessageBox.Show("Password and Confirm Password Does Not Matches", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmpasstextbox.Focus();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(tccheakbox.Checked == false)
            {
                signupbutton.Enabled = false;
            }
            else
            {
                signupbutton.Enabled = true;
            }
        }
    }
}
