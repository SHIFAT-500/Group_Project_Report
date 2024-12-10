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
    public partial class Add_Student4 : Form
    {
        public Add_Student4()
        {
            InitializeComponent();
        }

        // Event handler for label click
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for picture box click
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for the exit button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Confirming exit
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        // Event handler for name textbox key press, only allows letters, whitespaces, and control characters
        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for enrollment textbox text change, resets background color to white
        private void idtextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        // Event handler for enrollment textbox key press, only allows numbers and control characters
        private void idtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for contact textbox key press, only allows numbers and control characters
        private void contacttextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for institute textbox key press, only allows letters, whitespaces, and control characters
        private void institutetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for country textbox key press, only allows letters, whitespaces, and control characters
        private void countrytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        // Event handler for the refresh button click, clears all textboxes
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            nametextbox.Clear();
            enrolltextbox.Clear();
            contacttextbox.Clear();
            emailtextbox.Clear();
            institutetextbox.Clear();
            countrytextbox.Clear();
        }

        // Event handler for the save button click, performs various checks and saves the data
        private void savebutton_Click(object sender, EventArgs e)
        {
            // Check if name textbox is empty
            if (nametextbox.Text == "")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }

            // Check if enrollment textbox is empty
            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }

            // Check if gender is selected
            if (!((malebutton.Checked) || (femalebutton.Checked)))
            {
                MessageBox.Show("Please enter your Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if contact textbox is empty
            if (contacttextbox.Text == "")
            {
                contacttextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            // Check if email textbox is empty
            if (emailtextbox.Text == "")
            {
                emailtextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Check if institute textbox is empty
            if (institutetextbox.Text == "")
            {
                institutetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Institute Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                institutetextbox.Focus();
                return;
            }

            // Check if country textbox is empty
            if (countrytextbox.Text == "")
            {
                countrytextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Country Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countrytextbox.Focus();
                return;
            }

            // Assign values from textboxes to variables
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender;

            // Determine gender based on selected radio button
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

            // Check if contact number is 11 digits
            int a = contacttextbox.Text.Length;
            if (!(a == 11))
            {
                MessageBox.Show("Invalid Contact", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }

            // Check if email is in lowercase
            int n = semail.Length;
            if (!(semail == semail.ToLower()))
            {
                MessageBox.Show("Invalid Email!! All alphabet will be in lower case", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Check if email has valid format
            if (!(semail[n - 1] == 'm' && semail[n - 2] == 'o' && semail[n - 3] == 'c' && semail[n - 4] == '.' && semail[n - 5] == 'l' && semail[n - 6] == 'i' && semail[n - 7] == 'a' && semail[n - 8] == 'm' && semail[n - 9] == 'g' && semail[n - 10] == '@'))
            {
                MessageBox.Show("Invalid Email", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtextbox.Focus();
                return;
            }

            // Check if the student enrollment number already exists in the database
            int count = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from addstudentcourse4 where senroll = '" + enrolltextbox.Text + "'";
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
            cmd2.CommandText = "select * from addstudentcourse4 where semail = '" + emailtextbox.Text + "'";
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
            cmd3.CommandText = "select * from addstudentcourse4 where scontact = '" + contacttextbox.Text + "' ";
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

            // Inserting new student into the database
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;

            con4.Open();
            cmd4.CommandText = "insert into addstudentcourse4(sname, senroll, sgender, scontact, semail, sinstitute, scountry) values ('" + sname + "','" + senroll + "','" + sgender + "','" + scontact + "','" + semail + "','" + sinstitute + "','" + scountry + "')";
            cmd4.ExecuteNonQuery();
            con4.Close();

            MessageBox.Show("Data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handler for name textbox text change, resets background color to white
        private void nametextbox_TextChanged(object sender, EventArgs e)
        {
            nametextbox.BackColor = Color.White;
        }

        // Event handler for male radio button checked change, resets background color to white
        private void malebutton_CheckedChanged(object sender, EventArgs e)
        {
            malebutton.BackColor = Color.White;
        }

        // Event handler for female radio button checked change, resets background color to white
        private void femalebutton_CheckedChanged(object sender, EventArgs e)
        {
            femalebutton.BackColor = Color.White;
        }

        // Event handler for contact textbox text change, resets background color to white
        private void contacttextbox_TextChanged(object sender, EventArgs e)
        {
            contacttextbox.BackColor = Color.White;
        }

        // Event handler for email textbox text change, resets background color to white
        private void emailtextbox_TextChanged(object sender, EventArgs e)
        {
            emailtextbox.BackColor = Color.White;
        }

        // Event handler for institute textbox text change, resets background color to white
        private void institutetextbox_TextChanged(object sender, EventArgs e)
        {
            institutetextbox.BackColor = Color.White;
        }

        // Event handler for country textbox text change, resets background color to white
        private void countrytextbox_TextChanged(object sender, EventArgs e)
        {
            countrytextbox.BackColor = Color.White;
        }
    }
}
