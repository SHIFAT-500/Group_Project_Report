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
        public reportissue()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void enrolltextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        private void enrolltextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void coursecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursecombobox.BackColor = Color.White;
        }

        private void issuebox_TextChanged(object sender, EventArgs e)
        {
            issuetextbox.BackColor = Color.White;
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (coursecombobox.Text == "")
            {
                coursecombobox.BackColor = Color.Red;
                MessageBox.Show("Please enter Course Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                coursecombobox.Focus();
                return;
            }

            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }

            if (issuetextbox.Text == "")
            {
                issuetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Issue", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                issuetextbox.Focus();
                return;
            }

            String course = coursecombobox.Text;
            String enroll = enrolltextbox.Text;
            String issue = issuetextbox.Text;

            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;
            con4.Open();
            cmd4.CommandText = " insert into issue(course_name,enroll,Issue) values ('" + course + "','" + enroll + "','" + issue + "')";
            cmd4.ExecuteNonQuery();
            con4.Close();

            MessageBox.Show("Report Send!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            
            enrolltextbox.Clear();
            issuetextbox.Clear();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
