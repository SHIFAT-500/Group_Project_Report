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
        // Constructor to initialize the form components
        public signup()
        {
            InitializeComponent();
        }

        // Event handler for when the back button (pictureBox2) is clicked
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Navigate back to the user login form and hide the current signup form
            userlogin userlogin = new userlogin();
            userlogin.Show();
            this.Hide();
        }

        // Event handler for when the back button (button2) is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate back to the user login form and hide the current signup form
            userlogin userlogin = new userlogin();
            userlogin.Show();
            this.Hide();
        }

        // Event handler for when the "Show Password" checkbox for the password is checked/unchecked
        private void showpasscheakbox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on checkbox state
            if (showpasscheakbox1.Checked == true)
            {
                passtextbox.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                passtextbox.UseSystemPasswordChar = true; // Hide password
            }
        }

        // Event handler for when the "Show Password" checkbox for the confirm password is checked/unchecked
        private void showpasscheakbox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle confirm password visibility based on checkbox state
            if (showpasscheakbox2.Checked == true)
            {
                confirmpasstextbox.UseSystemPasswordChar = false; // Show confirm password
            }
            else
            {
                confirmpasstextbox.UseSystemPasswordChar = true; // Hide confirm password
            }
        }

        // Event handler for when the email textbox text is changed
        private void Useremailtextbox_TextChanged(object sender, EventArgs e)
        {
            // Reset background color when user starts typing in the email textbox
            useremailtextbox.BackColor = Color.White;
        }

        // Event handler for when the password textbox text is changed
        private void passtextbox_TextChanged(object sender, EventArgs e)
        {
            // Reset background color when user starts typing in the password textbox
            passtextbox.BackColor = Color.White;
        }

        // Event handler for when the confirm password textbox text is changed
        private void confirmpasstextbox_TextChanged(object sender, EventArgs e)
        {
            // Reset background color when user starts typing in the confirm password textbox
            confirmpasstextbox.BackColor = Color.White;
        }

        // Event handler for when the signup button (button1) is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled out
            if (useremailtextbox.Text == "")
            {
                useremailtextbox.BackColor = Color.Red; // Highlight the field in red if empty
                MessageBox.Show("Please enter your Email", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                useremailtextbox.Focus();
                return;
            }

            if (passtextbox.Text == "")
            {
                passtextbox.BackColor = Color.Red; // Highlight the field in red if empty
                MessageBox.Show("Please enter your Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passtextbox.Focus();
                return;
            }

            if (confirmpasstextbox.Text == "")
            {
                confirmpasstextbox.BackColor = Color.Red; // Highlight the field in red if empty
                MessageBox.Show("Please enter Confirm Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmpasstextbox.Focus();
                return;
            }

            // Assign the values from the textboxes to local variables
            String username = useremailtextbox.Text;
            String password = passtextbox.Text;

            int n = username.Length;

            // Validate that the email is in lowercase and ends with "@gmail.com"
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

            // Check if the email already exists in the database
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

            // If the email exists, show an error message
            if (count > 0)
            {
                MessageBox.Show("Student Email already exists in the database. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                useremailtextbox.Focus();
                return;
            }

            // If the passwords match, insert the new user into the database
            if (password == confirmpasstextbox.Text)
            {
                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con2;

                con2.Open();
                cmd2.CommandText = "insert into usertable (username, pass) values ('" + username + "','" + password + "')";
                cmd2.ExecuteNonQuery();
                con2.Close();

                // Show success message
                MessageBox.Show("Successfully Signed up!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If passwords don't match, show an error message
                MessageBox.Show("Password and Confirm Password Does Not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmpasstextbox.Focus();
            }
        }

        // Event handler for when the checkbox (tccheakbox) is checked/unchecked
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Enable the signup button only if the checkbox is checked
            if (tccheakbox.Checked == false)
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
