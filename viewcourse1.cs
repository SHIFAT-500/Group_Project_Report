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
    public partial class viewcourse1 : Form
    {
        // Constructor to initialize the form
        public viewcourse1()
        {
            InitializeComponent();
        }

        // Event handler for search textbox change. Filters courses based on enrollment number.
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            // If the search textbox is not empty
            if(searchtextbox.Text != "")
            {
                label1.Visible = false;  // Hide the label
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");  // Show search animation
                pictureBox1.Image = image;

                // Set up SQL connection and command to search for courses based on enrollment number
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from addstudentcourse1 where senroll LIKE '" + searchtextbox.Text + "%'"; // SQL query to filter by enrollment number
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind filtered data to the grid
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;  // Show the label again if search is empty
                Image image = Image.FromFile("D:\\VS CODE\\search.gif");  // Show default search image
                pictureBox1.Image = image;

                // Fetch all data if search textbox is empty
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from addstudentcourse1"; // SQL query to fetch all courses
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind all data to the grid
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Event handler for form load. Loads all courses into the grid when the form is opened.
        private void viewcourse1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;  // Hide the details panel initially

            // Fetch and display all student courses from the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from addstudentcourse1";  // SQL query to fetch all courses
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the result to the DataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Variable to store selected course ID and row ID
        int bid;
        Int64 rowid;

        // Event handler for DataGridView cell click. Displays selected course details in textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Get the course ID when a row is clicked
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                // Show the details panel
                panel2.Visible = true;

                // Fetch and display details of the selected course
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from addstudentcourse1 where stuorder = " + bid + ""; // SQL query to fetch course details by ID
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Store the selected course's row ID
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                // Populate the textboxes with course details
                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                gendertextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                contacttextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                emailtextbox.Text = ds.Tables[0].Rows[0][5].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);  // Show error message if any exception occurs
            }
        }

        // Event handler for update button. Updates the selected course details in the database.
        private void updatebutton_Click(object sender, EventArgs e)
        {
            // Get data from the textboxes
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = gendertextbox.Text;
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Confirm the update action
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Set up SQL connection to update the course
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update addstudentcourse1 set sname = '" + sname + "',senroll = '" + senroll + "',sgender = '" + sgender + "',scontact = '" + scontact + "',semail = '" + semail + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "' where stuorder = " + rowid + ""; // Update course details
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the course list after updating
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for refresh button. Reloads the course list.
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            viewcourse1_Load(this, null);  // Reload the form
        }

        // Event handler for delete button. Deletes the selected course from the database.
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirm the delete action
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Set up SQL connection to delete the course
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from addstudentcourse1 where stuorder = " + rowid + ""; // SQL query to delete course
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the course list after deletion
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for cancel button. Closes the form after confirming.
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Confirm before closing
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();  // Close the form
            }
        }
    }
}
