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
    public partial class listcertificate3 : Form
    {
        public listcertificate3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (searchtextbox.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from createcertificate3 where senroll LIKE '" + searchtextbox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("D:\\VS CODE\\search.gif");
                pictureBox1.Image = image;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from createcertificate3";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            listcertificate1_Load(this, null);
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

                cmd.CommandText = "select * from createcertificate3 where stuorder = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();
                datetime.Text = ds.Tables[0].Rows[0][8].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;
            String date = datetime.Text;

            //updating data


            if (MessageBox.Show("Data will be upated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update createcertificate3 set sname = '" + sname + "',senroll = '" + senroll + "',sinstitute = '" + sinstitute + "',scountry = '" + scountry + "',Issue_date = '" + date + "' where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                listcertificate1_Load(this, null);

            }
        }

        private void listcertificate1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from createcertificate3 where stuorder = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                listcertificate1_Load(this, null);

            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                this.Close();

            }
        }

        private void printbutton_Click(object sender, EventArgs e)
        {
            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3 where senroll = '" + enrolltextbox.Text + "'";

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
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            pagesetupdialog.Document = printdocument1;
            pagesetupdialog.ShowDialog();

            printdocument1.Print();
        }

        private void printdocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3 where senroll = '" + enrolltextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            String sname = ds.Tables[0].Rows[0][1].ToString();
            String senroll = ds.Tables[0].Rows[0][2].ToString();
           
            String sinstitute = ds.Tables[0].Rows[0][6].ToString();
            String scountry = ds.Tables[0].Rows[0][7].ToString();
            String date = ds.Tables[0].Rows[0][8].ToString();

            Bitmap bitmap = Properties.Resources.workshop1;
            Image image = new Bitmap(bitmap);


            e.Graphics.DrawImage(image, 0, 0, 1100, 850);

            e.Graphics.DrawString(sname, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(420, 368));
            e.Graphics.DrawString(senroll, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(380, 411));
            e.Graphics.DrawString(scountry, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(720, 411));
            e.Graphics.DrawString(sinstitute, new Font("Cambria", 14, FontStyle.Regular), Brushes.Black, new Point(423, 460));
            e.Graphics.DrawString(date, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(123, 225));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
