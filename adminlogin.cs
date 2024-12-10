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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Certificate_Generator
{
    public partial class adminlogin : Form
    {
        
        public adminlogin()
        {
            InitializeComponent();
        }

        private void exitbutton2_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Close();
        }

        private void adminnametextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if(adminnametextbox.Text=="Username")
            {
                adminnametextbox.Clear();
            }
        }

        private void adminpasstextbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (adminpasstextbox.Text == "Password")
            {
                adminpasstextbox.Clear();
                adminpasstextbox.UseSystemPasswordChar = true;
            }
        }

        private void adminpassshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(adminpassshowcheckbox.Checked == true)
            {
                adminpasstextbox.UseSystemPasswordChar = false;
            }
            else
            {
                adminpasstextbox.UseSystemPasswordChar = true;
            }
        }

        private void adminloginbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local ; database = Certificategenerator; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from admintable where username = '" + adminnametextbox.Text + "' and pass ='"+adminpasstextbox.Text+"'";
            SqlDataAdapter da= new SqlDataAdapter(cmd);   
            DataSet ds = new DataSet();
            da.Fill(ds);

            

            if (ds.Tables[0].Rows.Count != 0 )
            {
                
                    MessageBox.Show("Username and Password is correct", "Correct", MessageBoxButtons.OK,MessageBoxIcon.Information);
             
                    admindashboard admindashboard = new admindashboard();
                    admindashboard.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Username or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
 
                adminnametextbox.Clear();
                adminpasstextbox.Clear();
                adminnametextbox.Focus();
                

            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
