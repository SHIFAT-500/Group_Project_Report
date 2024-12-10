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
    public partial class sdplist : Form
    {
        // Constructor to initialize the form
        public sdplist()
        {
            InitializeComponent();
        }

        // Event handler for search textbox. Filters certificates based on project name.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Check if the search textbox is not empty
            if (searchtextbox.Text != "")
            {
                label1.Visible = false;  // Hide the label
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");  // Display search animation
                pictureBox1.Image = image;

                // Create a connection to the database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to filter certificates by project name
                cmd.CommandText = "select * from certificatesdp where project_name LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind the results to the dataGridView
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;  // Show the label again if search textbox is empty
                Image image = Image.FromFile("D:\\VS CODE\\search.gif");  // Display default search image
                pictureBox1.Image = image;

                // Fetch and display all certificates if search textbox is empty
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from certificatesdp";  // Fetch all records from the database
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Bind all data to the grid
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Refresh button click event. Reloads the certificate list.
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            listcertificate1_Load(this, null);
        }

        // Variable to store selected certificate's ID
        int bid;
        Int64 rowid;

        // Event handler for grid cell click. Displays selected certificate details in textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;  // Show the panel with selected certificate details

                // Fetch selected certificate details using SQL query
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from certificatesdp where stuid = " + bid + "";  // Fetch data by student ID
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Store the selected certificate row ID
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                // Populate the textboxes with the fetched data
                projectnametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                nametextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                idtextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                intaketextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                teachertextbox.Text = ds.Tables[0].Rows[0][5].ToString();
                datetime.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);  // Show error message if any exception occurs
            }
        }

        // Event handler for update button. Updates certificate details in the database.
        private void updatebutton_Click(object sender, EventArgs e)
        {
            String projectname = projectnametextbox.Text;
            String name = nametextbox.Text;
            String id = idtextbox.Text;
            String intake = intaketextbox.Text;
            String date = datetime.Text;
            String teacher = teachertextbox.Text;

            // Prompt the user for confirmation before updating
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Establish database connection and execute the update query
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Update query to change certificate details based on the selected row ID
                cmd.CommandText = "update certificatesdp set project_name = '" + projectname + "',member_name = '" + name + "',member_id = '" + id + "',intake = '" + intake + "',Issue_date = '" + date + "',teacher_name = '" + teacher + "' where stuid = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the certificate list after updating
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for form load. Displays all certificates in the grid.
        private void listcertificate1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;  // Hide the details panel

            // Fetch all certificates from the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp";  // Query to fetch all certificates
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Bind all data to the dataGridView
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Event handler for delete button. Deletes selected certificate from the database.
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirm if the user really wants to delete the certificate
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Establish connection and delete the selected certificate
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from certificatesdp where stuid = " + rowid + "";  // Delete the certificate by student ID
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Refresh the list after deletion
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for cancel button. Closes the form after confirming.
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Prompt for confirmation before exiting
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();  // Close the form
            }
        }

        // Event handler for print button. Prepares certificate for printing.
        private void printbutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            // Establish database connection and fetch certificates matching project name
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp where project_name = '" + projectnametextbox.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            // If there are matching records, show print preview
            if (count > 0)
            {
                pagesetupdialog.Document = printdocument1;
                pagesetupdialog.ShowDialog();  // Show page setup dialog

                printpreview1.Document = printdocument1;
                printpreview1.ShowDialog();  // Show print preview dialog
            }
        }

        // Event handler for save button. Saves the certificate as a print job.
        private void savebutton_Click(object sender, EventArgs e)
        {
            pagesetupdialog.Document = printdocument1;
            pagesetupdialog.ShowDialog();  // Show the page setup dialog

            printdocument1.Print();  // Print the certificate
        }

        // Event handler for print page. Formats the printing of certificate.
        private void printdocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Establish connection to fetch certificate details for printing
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp where project_name = '" + projectnametextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Get the certificate data to print
            String projectname = ds.Tables[0].Rows[0][1].ToString();
            String name = ds.Tables[0].Rows[0][2].ToString();
            String id = ds.Tables[0].Rows[0][3].ToString();
            String intake = ds.Tables[0].Rows[0][4].ToString();
            String teacher = ds.Tables[0].Rows[0][5].ToString();
            String date = ds.Tables[0].Rows[0][6].ToString();

            Bitmap bitmap = Properties.Resources.sdp_30012;  // Load a predefined image for the certificate
            Image image = new Bitmap(bitmap);

            // Draw the image and text onto the print page
            e.Graphics.DrawImage(image, 0, 0, 1100, 850);
            e.Graphics.DrawString(projectname, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(429, 442));
            e.Graphics.DrawString(name, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, 490));
            e.Graphics.DrawString(id, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, 528));
            e.Graphics.DrawString(intake, new Font("Cambria", 14, FontStyle.Regular), Brushes.Black, new Point(220, 565));
            e.Graphics.DrawString(date, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(180, 150));
            e.Graphics.DrawString(teacher, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(172, 685));
        }

        // Placeholder for panel paint event handler (currently not used)
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
