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
    public partial class createcertificate4 : Form
    {
        public createcertificate4()
        {
            InitializeComponent();
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            createcertificate1_Load(this, null);
        }

        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if (searchtextbox.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addstudentcourse4 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
   
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addstudentcourse4";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void createcertificate1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addstudentcourse4";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                panel2.Visible = true;



                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addstudentcourse4 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


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
                MessageBox.Show(ex.Message);
            }
            
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                this.Close();

            }
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender = gendertextbox.Text;
            String scontact = contacttextbox.Text;
            String semail = emailtextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;
            String date = datetime.Text;

            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate4 where senroll = '" + enrolltextbox.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                MessageBox.Show("Certificate already created!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                con1.Open();
                cmd1.CommandText = " insert into createcertificate4(sname,senroll,sgender,scontact,semail,sinstitute,scountry,Issue_date) values ('" + sname + "','" + senroll + "','" + sgender + "','" + scontact + "','" + semail + "','" + sinstitute + "','" + scountry + "','" + date + "')";
                cmd1.ExecuteNonQuery();
                con1.Close();

                MessageBox.Show("Certificate created!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void printbutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate4 where senroll = '" + searchtextbox2.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                pagesetupdialog.Document = printdocument1;
                pagesetupdialog.ShowDialog();

                printpreview1.Document = printdocument1;
                printpreview1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Certificate not Created For this Student", "Not Created", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                searchtextbox2.Focus();
                return;
            }
        }

        private void printdocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate4 where senroll = '" + searchtextbox2.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            String sname = ds.Tables[0].Rows[0][1].ToString();
            String senroll = ds.Tables[0].Rows[0][2].ToString();
            
            String sinstitute = ds.Tables[0].Rows[0][6].ToString();
            String scountry = ds.Tables[0].Rows[0][7].ToString();

            Bitmap bitmap = Properties.Resources.workshop2;
            Image image = new Bitmap(bitmap);


            e.Graphics.DrawImage(image, 0, 0, 1100, 850);

            e.Graphics.DrawString(sname, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(415, 380));
            e.Graphics.DrawString(senroll, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(360, 427));
            e.Graphics.DrawString(scountry, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(748, 427));
            e.Graphics.DrawString(sinstitute, new Font("Cambria", 14, FontStyle.Regular), Brushes.Black, new Point(410, 478));
            e.Graphics.DrawString(datetime.Text, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(870, 150));
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate4 where senroll = '" + searchtextbox2.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                pagesetupdialog.Document = printdocument1;
                pagesetupdialog.ShowDialog();

                printdocument1.Print();
            }
            else
            {
                MessageBox.Show("Enter Enroll First", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchtextbox2.Focus();
                return;
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
