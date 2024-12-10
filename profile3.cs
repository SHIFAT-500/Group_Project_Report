using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Certificate_Generator
{
    public partial class profile3 : Form
    {
        public profile3()
        {
            InitializeComponent();
        }

        private void refershbutton_Click(object sender, EventArgs e)
        {

            String semail = userlogin.semail;


            int count = 0;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addstudentcourse3 where semail = '" + semail + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {

                nametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                enrolltextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                gendertextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                contacttextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                emailtextbox.Text = ds.Tables[0].Rows[0][5].ToString();
                institutetextbox.Text = ds.Tables[0].Rows[0][6].ToString();
                countrytextbox.Text = ds.Tables[0].Rows[0][7].ToString();

            }
            else
            {
                MessageBox.Show("You have not selected the Course", "Not taken", MessageBoxButtons.OK, MessageBoxIcon.Information);

                printbutton.Enabled = false;
                savebutton.Enabled = false;
                return;
            }


            int count1 = 0;

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;

            cmd1.CommandText = "select * from createcertificate3 where semail = '" + semail + "'";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            count1 = Convert.ToInt32(ds1.Tables[0].Rows.Count.ToString());

            if (count1 > 0)
            {
                downloadtextbox.Text = "Certificate Created";

                return;

            }
            else
            {
                downloadtextbox.Text = "Certificate not Created";

                printbutton.Enabled = false;
                savebutton.Enabled = false;
                return;
            }

        }

        private void printdocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            String semail = userlogin.semail;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3 where semail = '" + semail + "'";
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

        private void printbutton_Click(object sender, EventArgs e)
        {

            String semail = userlogin.semail;

            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3 where semail = '" + semail + "'";

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

                return;
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {

            String semail = userlogin.semail;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from createcertificate3 where semail = '" + semail + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            pagesetupdialog.Document = printdocument1;
            pagesetupdialog.ShowDialog();

            printdocument1.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                this.Close();

            }
        }
    }
}
