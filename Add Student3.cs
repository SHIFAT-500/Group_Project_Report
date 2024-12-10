// Including necessary namespaces for the application
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
    public partial class Add_Student3 : Form
    {
        // Constructor to initialize the form components
        public Add_Student3()
        {
            InitializeComponent();
        }

        // Event handler for label1 click event (currently empty)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for pictureBox1 click event (currently empty)
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for the Exit button click event
        private void button2_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog before closing the form
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        // Event handler for nametextbox KeyPress event
        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, whitespace, and control characters
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for idtextbox TextChanged event
        private void idtextbox_TextChanged(object sender, EventArgs e)
        {
            // Reset background color to white when text changes
            enrolltextbox.BackColor = Color.White;
        }

        // Event handler for idtextbox KeyPress event
        private void idtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and control characters
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for contacttextbox KeyPress event
        private void contacttextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and control characters
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for institutetextbox KeyPress event
        private void institutetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, whitespace, and control characters
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for countrytextbox KeyPress event
        private void countrytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, whitespace, and control characters
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for the Refresh button click event
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            nametextbox.Clear();
            enrolltextbox.Clear();
            contacttextbox.Clear();
            emailtextbox.Clear();
            institutetextbox.Clear();
            countrytextbox.Clear();
        }

        // Event handler for the Save button click event
        private void savebutton_Click(object sender, EventArgs e)
        {
            // Validate name field
            if (nametextbox.Text == "")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }
            // Validate enroll field
            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }
            // Validate gender selection
            if (!((malebutton.Checked) || (femalebutton.Checked)))
            {
                MessageBox.Show("Please enter your Gender", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate contact field
            if (contacttextbox.Text == "")
            {
                contacttextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Contact", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }
            // Validate email field
            if (emailtextbox.Text == "")
            {
                emailtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Email", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }
            // Validate institute field
            if (institutetextbox.Text == "")
            {
                institutetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Institute Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                institutetextbox.Focus();
                return;
            }
            // Validate country field
            if (countrytextbox.Text == "")
            {
                countrytextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Country Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countrytextbox.Focus();
                return;
            }

            // Extract and assign values from textboxes
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender;

            // Assign gender based on the selected radio button
            if (malebutton.Checked)
            {
                sgender = "Male";
            }
            else
            {
                sgender = "Female";
            }

            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Validate contact number length
            int a = contacttextbox.Text.Length;
            if (!(a == 11))
            {
                MessageBox.Show("Invalid Contact", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            // Validate email format
            int n = semail.Length;
            if (!(semail == semail.ToLower()))
            {
                MessageBox.Show("Invalid Email!! all alphabet will be in lower case", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Further email format validation
            if (!(semail[n - 1] == 'm' && semail[n - 2] == 'o' && semail[n - 3] == 'c' && semail[n - 4] == '.' && semail[n - 5] == 'l' && semail[n - 6] == 'i' && semail[n - 7] == 'a' && semail[n - 8] == 'm' && semail[n - 9] == 'g' && semail[n - 10] == '@'))
            {
                MessageBox.Show("Invalid Email", "email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Check if the student enroll already exists in the database
            int count = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from addstudentcourse3 where senroll = '" + enrolltextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                MessageBox.Show("Student Enroll already exists in database.. Choose Another", "Enroll Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enrolltextbox.Focus();
                return;
            }

            // Check if the student email already exists in the database
            int count2;
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandText = "select * from addstudentcourse3 where semail = '" + emailtextbox.Text + "'";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            count2 = Convert.ToInt32(ds2.Tables[0].Rows.Count.ToString());

            if (count2 > 0)
            {
                MessageBox.Show("Student Email already exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailtextbox.Focus();
                return;
            }

            // Check if the student contact already exists in the database
            int count3;
            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            cmd3.CommandText = "select * from addstudentcourse3 where scontact = '" + contacttextbox.Text + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            count3 = Convert.ToInt32(ds3.Tables[0].Rows.Count.ToString());

            if (count3 > 0)
            {
                MessageBox.Show("Student Contact already exists in database.. Choose Another", "Contact Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contacttextbox.Focus();
                return;
            }

            // Insert new student data into the database
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;
            con4.Open();
            cmd4.CommandText = " insert into addstudentcourse3(sname,senroll,sgender,scontact,semail,sinstitute,scountry) values ('" + sname + "','" + senroll + "','" + sgender + "','" + scontact + "','" + semail + "','" + sinstitute + "','" + scountry + "')";
            cmd4.ExecuteNonQuery();
            con4.Close();

            // Show success message
            MessageBox.Show("Data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handlers to reset the background color of textboxes when text changes
        private void nametextbox_TextChanged(object sender, EventArgs e)
        {
            nametextbox.BackColor = Color.White;
        }

        private void malebutton_CheckedChanged(object sender, EventArgs e)
        {
            malebutton.BackColor = Color.White;
        }

        private void femalebutton_CheckedChanged(object sender, EventArgs e)
        {
            femalebutton.BackColor = Color.White;
        }

        private void contacttextbox_TextChanged(object sender, EventArgs e)
        {
            contacttextbox.BackColor = Color.White;
        }

        private void emailtextbox_TextChanged(object sender, EventArgs e)
        {
            emailtextbox.BackColor = Color.White;
        }

        private void institutetextbox_TextChanged(object sender, EventArgs e)
        {
            institutetextbox.BackColor = Color.White;
        }

        private void countrytextbox_TextChanged(object sender, EventArgs e)
        {
            countrytextbox.BackColor = Color.White;
        }
    }
}
