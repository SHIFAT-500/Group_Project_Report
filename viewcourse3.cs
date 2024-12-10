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
    public partial class viewcourse3 : Form
    {
        // Constructor to initialize the form components
        public viewcourse3()
        {
            InitializeComponent();
        }

        // Event handler for when the picture box is clicked (currently does nothing)
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for when the first label is clicked (currently does nothing)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for when the second label is clicked (currently does nothing)
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Event handler for the search text box. Filters the data based on user input.
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if(searchtextbox.Text != "")
            {
                // Hide the message label when text is entered in the search box
                label1.Visible= false;

                // Display a loading image
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");
                pictureBox1.Image = image;

                // Connect to the database and filter results based on the search text
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute query to find rows where student enrollment starts with the entered text
                cmd.CommandText = "select * from addstudentcourse3 where senroll LIKE '"+searchtextbox.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Set the data grid view source to the filtered data
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                // If the search box is empty, show the message label and default image
                label1.Visible = true;
                Image image = Image.FromFile("D:\\VS CODE\\search.gif");
                pictureBox1.Image = image;

                // Connect to the database and fetch all data when search box is empty
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute query to get all rows from the table
                cmd.CommandText = "select * from addstudentcourse3";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Set the data grid view source to all the data
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Event handler for form load, initializes the data grid with all courses
        private void viewcourse1_Load(object sender, EventArgs e)
        {
            // Hide the detail panel initially
            panel2.Visible = false;

            // Connect to the database and fetch all data
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Execute query to fetch all rows from addstudentcourse3 table
            cmd.CommandText = "select * from addstudentcourse3";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Set the data grid view source to the fetched data
            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;  // Variable to store selected student ID
        Int64 rowid;  // Variable to store row ID for further database operations

        // Event handler for when a cell in the data grid view is clicked
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the cell clicked has data (to avoid errors)
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Get the student ID of the selected row
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;  // Show the details panel

                // Connect to the database and fetch detailed data for the selected student
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute query to get data for the selected student
                cmd.CommandText = "select * from addstudentcourse3 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Get the row ID for future reference
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                // Populate the text boxes with student details
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
                // Display any exceptions that occur
                MessageBox.Show(ex.Message);
            }
            
        }

        // Event handler for when the update button is clicked, to update student data
        private void updatebutton_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = gendertextbox.Text;
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Confirm update action
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Connect to the database and update student data
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute update query
                cmd.CommandText = "update addstudentcourse3 set sname = '" + sname + "',senroll = '" + senroll + "',sgender = '" + sgender + "',scontact = '" + scontact + "',semail = '" + semail + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the data grid after the update
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for the refresh button to reload data
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            viewcourse1_Load(this, null);  // Reload the data
        }

        // Event handler for the delete button to delete student data
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Connect to the database and delete the selected student data
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from addstudentcourse3 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the data grid after deletion
                viewcourse1_Load(this, null);
            }
        }

        // Event handler for the cancel button to close the form with a confirmation
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();  // Close the form if the user confirms
            }
        }
    }
}
