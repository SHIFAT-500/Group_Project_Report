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
    public partial class viewcourse4 : Form
    {
        // Constructor for initializing the form.
        public viewcourse4()
        {
            InitializeComponent();
        }

        // Event handler for PictureBox click, currently not implemented.
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for Label1 click, currently not implemented.
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Event handler for Label2 click, currently not implemented.
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Event handler for Search Textbox TextChanged event.
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            // If there's text in the search textbox, show search results based on the text.
            if(searchtextbox.Text != "")
            {
                label1.Visible = false;
                // Set a loading search animation image.
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");
                pictureBox1.Image = image;

                // SQL connection setup
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute a query to search for student enrollment matching the input.
                cmd.CommandText = "select * from addstudentcourse4 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Display the results in the DataGridView.
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                // If search textbox is empty, show all records and reset search animation.
                label1.Visible = true;
                Image image = Image.FromFile("D:\\VS CODE\\search.gif");
                pictureBox1.Image = image;

                // SQL connection setup for retrieving all data
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Execute a query to retrieve all records.
                cmd.CommandText = "select * from addstudentcourse4";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Display all records in the DataGridView.
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Load event handler for the form, to display all student course records initially.
        private void viewcourse1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            // SQL connection setup
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Execute query to get all records and display in the DataGridView.
            cmd.CommandText = "select * from addstudentcourse4";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind data to DataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Declare variables to hold the selected row ID and bid.
        int bid;
        Int64 rowid;

        // Event handler when a cell in DataGridView is clicked.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                // Check if the clicked cell has value.
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;

                // SQL connection setup
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Fetch student details using the selected 'stuorder' (bid).
                cmd.CommandText = "select * from addstudentcourse4 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Retrieve row ID and display the student details in textboxes.
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
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
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler to update student data in the database.
        private void updatebutton_Click(object sender, EventArgs e)
        {
            // Collect the updated values from the form.
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = gendertextbox.Text;
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            // Prompt to confirm data update.
            if (MessageBox.Show("Data will be upated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // SQL connection setup
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Update student details in the database using the row ID.
                cmd.CommandText = "update addstudentcourse4 set sname = '" + sname + "',senroll = '" + senroll + "',sgender = '" + sgender + "',scontact = '" + scontact + "',semail = '" + semail + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the data to reflect the update.
                viewcourse1_Load(this, null);
            }
        }

        // Event handler to refresh the DataGridView with updated data.
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            viewcourse1_Load(this, null);
        }

        // Event handler to delete a record from the database.
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Prompt to confirm deletion.
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // SQL connection setup
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Delete the student record using the row ID.
                cmd.CommandText = "delete from addstudentcourse4 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the data after deletion.
                viewcourse1_Load(this, null);
            }
        }

        // Event handler to cancel the operation and close the form.
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Confirm before closing the form and discarding any changes.
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { 
                this.Close();
            }
        }
    }
}
