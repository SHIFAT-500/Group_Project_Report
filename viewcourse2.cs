using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Certificate_Generator
{
    public partial class viewcourse2 : Form
    {
        public viewcourse2()
        {
            InitializeComponent(); // Initializes the form components
        }

        // Event handler when the picture box is clicked (not used currently)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        // Event handler when label1 is clicked (not used currently)
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Event handler when label2 is clicked (not used currently)
        private void label2_Click(object sender, EventArgs e)
        {
        }

        // Event handler for the search textbox text change
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if (searchtextbox.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif"); // Display search gif
                pictureBox1.Image = image;

                // Set up connection to database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Search query based on enroll number
                cmd.CommandText = "select * from addstudentcourse2 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Display the results in the DataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("D:\\VS CODE\\search.gif"); // Display default search gif
                pictureBox1.Image = image;

                // Set up connection to database to show all data
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to fetch all data
                cmd.CommandText = "select * from addstudentcourse2";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Display all data in the DataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Event handler when the form loads
        private void viewcourse1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; // Hide the details panel initially

            // Set up connection to database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to fetch all data
            cmd.CommandText = "select * from addstudentcourse2";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Display all data in the DataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid; // Variable to hold selected student order ID
        Int64 rowid; // Variable to hold the row ID for database operations

        // Event handler when a cell in the DataGridView is clicked
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); // Get selected student order ID
                }
                panel2.Visible = true; // Show the details panel

                // Set up connection to database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to fetch selected student details
                cmd.CommandText = "select * from addstudentcourse2 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Parse and display student details in respective textboxes
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                gendertextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                contacttextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                emailtextbox.Text = ds.Tables[0].Rows[0][5].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show error message if any
            }
        }

        // Event handler for the Update button
        private void updatebutton_Click(object sender, EventArgs e)
        {
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = gendertextbox.Text;
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Prompt user for confirmation before updating
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Set up connection to database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to update student data
                cmd.CommandText = "update addstudentcourse2 set sname = '" + sname + "',senroll = '" + senroll + "',sgender = '" + sgender + "',scontact = '" + scontact + "',semail = '" + semail + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload data after update
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for the Refresh button
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            viewcourse1_Load(this, null); // Reload data
        }

        // Event handler for the Delete button
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Prompt user for confirmation before deleting
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Set up connection to database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to delete student data
                cmd.CommandText = "delete from addstudentcourse2 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload data after deletion
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for the Cancel button (close form)
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close(); // Close the form
            }
        }
    }
}
