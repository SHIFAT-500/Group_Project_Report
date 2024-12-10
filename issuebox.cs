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
    public partial class issuebox : Form
    {
        // Constructor to initialize the form components
        public issuebox()
        {
            InitializeComponent();
        }

        // Event handler for the form load event
        private void issuebox_Load(object sender, EventArgs e)
        {
            // Initially, hide panel2 which is used for displaying detailed data
            panel2.Visible = false;

            // Establish a connection to the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // SQL query to select all data from the 'issue' table
            cmd.CommandText = "select * from issue";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind the data from the 'issue' table to the DataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Variables to hold the selected issue's ID and row ID
        int bid;
        Int64 rowid;

        // Event handler for cell click in the DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked cell has a value
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Get the ID of the selected issue from the first column (serial)
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                // Make panel2 visible to show detailed information of the selected issue
                panel2.Visible = true;

                // Establish a connection to the database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to get data of the selected issue using its ID
                cmd.CommandText = "select * from issue where serial = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Extract the row ID of the selected issue
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                // Fill the textboxes with the selected issue's data
                coursetextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                issuetextbox.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            catch(Exception ex)
            {
                // Show any errors that occur during the data retrieval process
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the "Delete" button click event
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirm with the user before deleting the data
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Establish a connection to the database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to delete the selected issue by its serial number (rowid)
                cmd.CommandText = "delete from issue where serial = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the issuebox to reflect the changes (data deletion)
                issuebox_Load(this, null);
            }
        }

        // Event handler for the "Cancel" button click event
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Confirm with the user before closing the form without saving changes
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Close the current form
                this.Close();
            }
        }
    }
}
