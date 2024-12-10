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
        // Static variable to store the user's email after successful login
        public static string semail;

        // Constructor to initialize the form components
        public userlogin()
        {
            InitializeComponent();
        }

        // Event handler for the "Back" button (button1) click event
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to the main form and hide the current login form
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        // Event handler for the picture box click event (used as a back button)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate to the main form and hide the current login form
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        // Event handler for the "Login" button (button1) click event
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Establish a connection to the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local ; database = Certificategenerator; integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // SQL query to check if the username and password exist in the user table
            cmd.CommandText = "select * from usertable where username = '" + usernametextbox.Text + "' and pass ='" + userpasstextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // If a matching username and password are found in the database
            if (ds.Tables[0].Rows.Count != 0)
            {
                // Store the logged-in user's email in the static variable
                semail = usernametextbox.Text;

                // Show a success message and navigate to the user dashboard
                MessageBox.Show("Username and Password are correct", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);

                userdashboard userdashboard = new userdashboard();
                userdashboard.Show();
                this.Hide();
            }
            else
            {
                // Show an error message if the username or password is incorrect
                MessageBox.Show("Wrong Username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear the input fields and focus on the username textbox
                usernametextbox.Clear();
                userpasstextbox.Clear();
                usernametextbox.Focus();
            }
        }

        // Event handler for the "Exit" button (button3) click event
        private void button3_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        // Event handler for the mouse click event on the username textbox
        private void usernametextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // If the username textbox contains the placeholder text "Enter E-mail", clear the textbox
            if (usernametextbox.Text == "Enter E-mail")
            {
                usernametextbox.Clear();
            }
        }

        // Event handler for the mouse click event on the password textbox
        private void userpasstextbox_MouseClick(object sender, MouseEventArgs e)
        {
            // If the password textbox contains the placeholder text "Password", clear the textbox and enable password masking
            if (userpasstextbox.Text == "Password")
            {
                userpasstextbox.Clear();
                userpasstextbox.UseSystemPasswordChar = true;
            }
        }

        // Event handler for when the "Show Password" checkbox is checked/unchecked
        private void userpassshowcheakbox_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the password visibility based on checkbox state
            if (userpassshowcheakbox.Checked == true)
            {
                userpasstextbox.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                userpasstextbox.UseSystemPasswordChar = true; // Hide password
            }
        }

        // Event handler for the "Sign Up" button click event
        private void usersignupbutton_Click(object sender, EventArgs e)
        {
            // Navigate to the signup form and hide the current login form
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }
    }
}
