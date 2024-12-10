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
    public partial class Add_Student : Form
    {
        // Constructor: Initializes the form
        public Add_Student()
        {
            InitializeComponent();
        }

        // Event handler: Triggered when label1 is clicked
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Event handler: Triggered when pictureBox1 is clicked
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        // Event handler: Closes the form with a confirmation dialog
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        // Event handler: Restricts input to letters, whitespaces, and control keys for the name textbox
        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler: Resets the background color of enrolltextbox when its text changes
        private void idtextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        // Event handler: Restricts input to numbers and control keys for the ID textbox
        private void idtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler: Restricts input to numbers and control keys for the contact textbox
        private void contacttextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler: Restricts input to letters, whitespaces, and control keys for the institute textbox
        private void institutetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler: Restricts input to letters, whitespaces, and control keys for the country textbox
        private void countrytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler: Clears all input fields
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            nametextbox.Clear();
            enrolltextbox.Clear();
            contacttextbox.Clear();
            emailtextbox.Clear();
            institutetextbox.Clear();
            countrytextbox.Clear();
        }

        // Event handler: Validates and saves student information to the database
        private void savebutton_Click(object sender, EventArgs e)
        {
            // Input validation
            if (nametextbox.Text == "")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }

            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }

            if (!((malebutton.Checked) || (femalebutton.Checked)))
            {
                MessageBox.Show("Please enter your Gender", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (contacttextbox.Text == "")
            {
                contacttextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Contact", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            if (emailtextbox.Text == "")
            {
                emailtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Email", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            if (institutetextbox.Text == "")
            {
                institutetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Institute Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                institutetextbox.Focus();
                return;
            }

            if (countrytextbox.Text == "")
            {
                countrytextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Country Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countrytextbox.Focus();
                return;
            }

            // Extracting input values
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = malebutton.Checked ? "Male" : "Female";
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Validating contact length
            if (contacttextbox.Text.Length != 11)
            {
                MessageBox.Show("Invalid Contact", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            // Validating email format
            if (!semail.All(char.IsLower) || !semail.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Invalid Email", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Database validation and insertion
            // Checking for duplicate enrollment, email, and contact
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";

            if (RecordExists(con, "senroll", senroll))
            {
                MessageBox.Show("Student Enroll already exists in database.. Choose Another", "Enroll Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enrolltextbox.Focus();
                return;
            }

            if (RecordExists(con, "semail", semail))
            {
                MessageBox.Show("Student Email already exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailtextbox.Focus();
                return;
            }

            if (RecordExists(con, "scontact", scontact))
            {
                MessageBox.Show("Student Contact already exists in database.. Choose Another", "Contact Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contacttextbox.Focus();
                return;
            }

            // Insert the new student record
            SqlCommand cmd = new SqlCommand($"INSERT INTO addstudentcourse1 (sname, senroll, sgender, scontact, semail, sinstitute, scountry) VALUES ('{sname}', '{senroll}', '{sgender}', '{scontact}', '{semail}', '{sinstitute}', '{scountry}')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helper method: Checks if a record with the specified field value exists
        private bool RecordExists(SqlConnection con, string field, string value)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM addstudentcourse1 WHERE {field} = '{value}'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0].Rows.Count > 0;
        }
    }
}
