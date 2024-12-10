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
        // Constructor to initialize the form components
        public adminlogin()
        {
            InitializeComponent();
        }

        // Event handler for when the exit button is clicked
        private void exitbutton2_Click(object sender, EventArgs e)
        {
            // Opens the main form and closes the admin login form
            mainform mainform = new mainform();
            mainform.Show();
            this.Close();
        }

        // Event handler for when the username textbox is clicked
        private void adminnametextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // If the username textbox contains the default text ("Username"), clear it
            if (adminnametextbox.Text == "Username")
            {
                adminnametextbox.Clear();
            }
        }

        // Event handler for when the password textbox is clicked
        private void adminpasstextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // If the password textbox contains the default text ("Password"), clear it and use password masking
            if (adminpasstextbox.Text == "Password")
            {
                adminpasstextbox.Clear();
                adminpasstextbox.UseSystemPasswordChar = true;
            }
        }

        // Event handler for when the "Show Password" checkbox state changes
        private void adminpassshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // If the checkbox is checked, show the password; otherwise, hide it
            if (adminpassshowcheckbox.Checked == true)
            {
                adminpasstextbox.UseSystemPasswordChar = false;
            }
            else
            {
                adminpasstextbox.UseSystemPasswordChar = true;
            }
        }

        // Event handler for when the admin login button is clicked
        private void adminloginbutton_Click(object sender, EventArgs e)
        {
            // Establish connection to the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local ; database = Certificategenerator; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // SQL query to validate the username and password from the admin table
            cmd.CommandText = "select * from admintable where username = '" + adminnametextbox.Text + "' and pass ='" + adminpasstextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);   
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Check if any record matches the entered username and password
            if (ds.Tables[0].Rows.Count != 0)
            {
                // If credentials are correct, show a success message and open the admin dashboard
                MessageBox.Show("Username and Password is correct", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);

                admindashboard admindashboard = new admindashboard();
                admindashboard.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                // If credentials are incorrect, show an error message and clear the input fields
                MessageBox.Show("Wrong Username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                adminnametextbox.Clear();
                adminpasstextbox.Clear();
                adminnametextbox.Focus(); // Focus back to the username field
            }
        }

        // Event handler for the exit button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }
    }
}
