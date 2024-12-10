// Importing necessary namespaces
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
    public partial class listcertificate2 : Form
    {
        // Constructor for initializing the form
        public listcertificate2()
        {
            InitializeComponent();
        }

        // Event handler for text change in the search textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Check if the search textbox is not empty
            if (searchtextbox.Text != "")
            {
                label1.Visible = false; // Hide the label
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif"); // Load a new image for the picture box
                pictureBox1.Image = image;

                // Establishing SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to search for certificates based on enrollment number
                cmd.CommandText = "select * from createcertificate2 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Setting the data source for the data grid view
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true; // Show the label
                Image image = Image.FromFile("D:\\VS CODE\\search.gif"); // Load the default image for the picture box
                pictureBox1.Image = image;

                // Establishing SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to get all certificates
                cmd.CommandText = "select * from createcertificate2";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Setting the data source for the data grid view
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // Event handler for refresh button click
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            // Reload the form
            listcertificate1_Load(this, null);
        }

        int bid;
        Int64 rowid;

        // Event handler for cell click in the data grid view
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked cell is not null
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true; // Show the panel

                // Establishing SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to get the certificate details based on the selected row
                cmd.CommandText = "select * from createcertificate2 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Filling the text boxes with the data from the selected row
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();
                datetime.Text = ds.Tables[0].Rows[0][8].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); // Show error message
            }
        }

        // Event handler for update button click
        private void updatebutton_Click(object sender, EventArgs e)
        {
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;
            String date = datetime.Text;

            // Confirming data update
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Establishing SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to update the certificate details
                cmd.CommandText = "update createcertificate2 set sname = '" + sname + "',senroll = '" + senroll + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "',Issue_date = '" + date + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the form
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for form load
        private void listcertificate1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; // Hide the panel

            // Establishing SQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to get all certificates
            cmd.CommandText = "select * from createcertificate2";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Setting the data source for the data grid view
            dataGridView1.DataSource = ds.Tables[0];
        }

        // Event handler for delete button click
        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirming data deletion
            if (MessageBox.Show("Data will be deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Establishing SQL connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Query to delete the selected certificate
                cmd.CommandText = "delete from createcertificate2 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Reload the form
                listcertificate1_Load(this, null);
            }
        }

        // Event handler for cancel button click
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            // Confirming exit without saving unwanted data
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close(); // Close the form
            }
        }

        // Event handler for print button click
        private void printbutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            // Establishing SQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to check if the certificate exists
            cmd.CommandText = "select * from createcertificate2 where senroll = '" + enrolltextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            // If certificate exists, show print preview
            if (count > 0)
            {
                pagesetupdialog.Document = printdocument1;
                pagesetupdialog.ShowDialog();

                printpreview1.Document = printdocument1;
                printpreview1.ShowDialog();
            }
        }

        // Event handler for save button click
        private void savebutton_Click(object sender, EventArgs e)
        {
            // Show print dialog and print the document
            pagesetupdialog.Document = printdocument1;
            pagesetupdialog.ShowDialog();

            printdocument1.Print();
        }

        // Event handler for print document print page
        private void printdocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Establishing SQL connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator2; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Query to get the certificate details for printing
            cmd.CommandText = "select * from createcertificate2 where senroll = '" + enrolltextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Extracting details from the dataset
            String sname = ds.Tables[0].Rows[0][1].ToString();
            String senroll = ds.Tables[0].Rows[0][2].ToString();
            String sinstitute = ds.Tables[0].Rows[0][6].ToString();
            String scountry = ds.Tables[0].Rows[0][7].ToString();
            String date = ds.Tables[0].Rows[0][8].ToString();

            // Loading the certificate template
            Bitmap bitmap = Properties.Resources.seminar2;
            Image image = new Bitmap(bitmap);

            // Drawing the certificate details on the template
            e.Graphics.DrawImage(image, 0, 0, 1100, 850);
            e.Graphics.DrawString(sname, new Font("Arial Black", 16, FontStyle.Regular), Brushes.Black, new Point(380, 365));
            e.Graphics.DrawString(senroll, new Font("Arial Black", 16, FontStyle.Regular), Brushes.Black, new Point(325, 413));
            e.Graphics.DrawString(scountry, new Font("Arial Black", 16, FontStyle.Regular), Brushes.Black, new Point(735, 413));
            e.Graphics.DrawString(sinstitute, new Font("Cambria", 16, FontStyle.Regular), Brushes.Black, new Point(380, 467));
            e.Graphics.DrawString(datetime.Text, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(355, 705));
        }

        // Event handler for panel paint (not used)
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // No implementation needed for panel paint event
        }
    }
}
