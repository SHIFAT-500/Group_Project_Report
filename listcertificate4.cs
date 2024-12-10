using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate_Generator
{
    public partial class listcertificate4 : Form
    {
        // Constructor to initialize the form components
        public listcertificate4()
        {
            InitializeComponent();
        }

        // Event handler for when text in the search textbox changes
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // If search textbox is not empty, perform search
            if (searchtextbox.Text != "")
            {
                label1.Visible = false; // Hide the label when searching
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif"); // Set the search-in-progress image
                pictureBox1.Image = image;

                // Establish SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to search for records with enrollment matching the entered text
                cmd.CommandText = "select * from createcertificate4 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Set the result to be displayed in the DataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                // If search textbox is empty, display all records
                label1.Visible = true;
                Image image = Image.FromFile("D:\\VS CODE\\search.gif"); // Set default search image
                pictureBox1.Image = image;

                // Establish SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to fetch all records from the table
                cmd.CommandText = "select * from createcertificate4";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Set the result to be displayed in the DataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Event handler for refresh button click
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            listcertificate1_Load(this, null); // Reload the form to refresh the data
        }

        int bid; // Store selected row's ID
        Int64 rowid; // Store the ID of the certificate to update or delete

        // Event handler for cell click in the DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if a valid cell was clicked
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); // Get the ID of the selected row
                }
                panel2.Visible = true; // Make the details panel visible

                // SQL connection to fetch certificate details based on selected row's ID
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from createcertificate4 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString()); // Store the unique ID of the certificate

                // Fill the textboxes with the fetched certificate details
                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();
                datetime.Text = ds.Tables[0].Rows[0][8].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Show error message if something goes wrong
            }
        }

        // Event handler for update button click
        private void updatebutton_Click(object sender, EventArgs e)
        {
            // Get the values entered in the textboxes
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;
            String date = datetime.Text;

            // Ask for confirmation before updating
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Establish SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to update certificate details in the database
                cmd.CommandText = "update createcertificate4 set sname = '" + sname + "', senroll = '" + senroll + "', sinstitute = '" + sinstitute + "', scountry = '" + scountry + "', Issue_date = '" + date + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the form to reflect the changes
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for form load to display all certificate records
        private void listcertificate1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; // Hide the panel initially

            // Establish SQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to fetch all records from the table
            cmd.CommandText = "select * from createcertificate4";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Display the fetched records in the DataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Event handler for delete button click
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before deleting
            if (MessageBox.Show("Data will be deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Establish SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to delete the selected certificate from the database
                cmd.CommandText = "delete from createcertificate4 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the form to reflect the deletion
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for cancel button click
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Confirm before closing the form
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close(); // Close the form
            }
        }

        // Event handler for print button click
        private void printbutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            // Establish SQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to check if the certificate exists based on enrollment number
            cmd.CommandText = "select * from createcertificate4 where senroll = '" + enrolltextbox.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            // If record exists, show the print preview dialog
            if (count > 0)
            {
                pagesetupdialog.Document = printdocument1;
                pagesetupdialog.ShowDialog();

                printpreview1.Document = printdocument1;
                printpreview1.ShowDialog();
            }
        }

        // Event handler for save button click to print the certificate
        private void savebutton_Click(object sender, EventArgs e)
        {
            pagesetupdialog.Document = printdocument1;
            pagesetupdialog.ShowDialog();

            printdocument1.Print();
        }

        // Event handler to handle printing of the certificate
        private void printdocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Establish SQL connection to get the certificate details
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate4 where senroll = '" + enrolltextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Extract details for the certificate
            String sname = ds.Tables[0].Rows[0][1].ToString();
            String senroll = ds.Tables[0].Rows[0][2].ToString();
            String sinstitute = ds.Tables[0].Rows[0][6].ToString();
            String scountry = ds.Tables[0].Rows[0][7].ToString();
            String date = ds.Tables[0].Rows[0][8].ToString();

            // Load the certificate template image
            Bitmap bitmap = Properties.Resources.workshop2;
            Image image = new Bitmap(bitmap);

            // Draw the certificate template and details onto the page
            e.Graphics.DrawImage(image, 0, 0, 1100, 850);
            e.Graphics.DrawString(sname, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(415, 380));
            e.Graphics.DrawString(senroll, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(360, 427));
            e.Graphics.DrawString(scountry, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(748, 427));
            e.Graphics.DrawString(sinstitute, new Font("Cambria", 14, FontStyle.Regular), Brushes.Black, new Point(410, 478));
            e.Graphics.DrawString(date, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(870, 150));
        }

        // Event handler for panel paint (empty method, can be extended if needed)
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Nothing implemented here
        }
    }
}
