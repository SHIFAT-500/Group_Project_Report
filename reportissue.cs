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
    public partial class reportissue : Form
    {
        // Constructor to initialize the form components
        public reportissue()
        {
            InitializeComponent();
        }

        // Event handler for the label2 click event (currently not implemented)
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Event handler to reset the background color of the enroll textbox to white
        private void enrolltextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        // Event handler for key press in the enroll textbox. It only allows numbers and control keys (backspace, etc.)
        private void enrolltextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;  // Prevent invalid characters from being typed
            }
        }

        // Event handler to reset the background color of the course combobox to white
        private void coursecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursecombobox.BackColor = Color.White;
        }

        // Event handler to reset the background color of the issue textbox to white
        private void issuebox_TextChanged(object sender, EventArgs e)
        {
            issuetextbox.BackColor = Color.White;
        }

        // Event handler for the submit button click. Validates input and submits data to the database.
        private void submitbutton_Click(object sender, EventArgs e)
        {
            // Check if the course name is empty
            if (coursecombobox.Text == "")
            {
                coursecombobox.BackColor = Color.Red;  // Highlight the field with red
                MessageBox.Show("Please enter Course Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                coursecombobox.Focus();
                return;
            }

            // Check if the enrollment number is empty
            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;  // Highlight the field with red
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }

            // Check if the issue description is empty
            if (issuetextbox.Text == "")
            {
                issuetextbox.BackColor = Color.Red;  // Highlight the field with red
                MessageBox.Show("Please enter your Issue", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                issuetextbox.Focus();
                return;
            }

            // Retrieve the values from the input fields
            String course = coursecombobox.Text;
            String enroll = enrolltextbox.Text;
            String issue = issuetextbox.Text;

            // Establish a database connection and insert the new issue record
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;

            con4.Open();
            // Insert the new issue data into the database
            cmd4.CommandText = " insert into issue(course_name,enroll,Issue) values ('" + course + "','" + enroll + "','" + issue + "')";
            cmd4.ExecuteNonQuery();  // Execute the insert command
            con4.Close();

            // Notify the user that the report has been successfully sent
            MessageBox.Show("Report Send!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handler for the refresh button click. Clears the enroll and issue textboxes
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            enrolltextbox.Clear();  // Clear the enrollment textbox
            issuetextbox.Clear();  // Clear the issue textbox
        }

        // Event handler for the cancel button click. Confirms the exit and closes the form if confirmed
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();  // Close the form if the user confirms
            }
        }
    }
}
