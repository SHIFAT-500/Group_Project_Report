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
        public sdplist()
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
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from certificatesdp where project_name LIKE '" + searchtextbox.Text + "%'";
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
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from certificatesdp";
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
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from certificatesdp where stuid = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                projectnametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                nametextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                idtextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                intaketextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                teachertextbox.Text = ds.Tables[0].Rows[0][5].ToString();
                datetime.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            String projectname = projectnametextbox.Text;
            String name = nametextbox.Text;
            String id = idtextbox.Text;
            String intake= intaketextbox.Text;
            String date = datetime.Text;
            String teacher = teachertextbox.Text;

            //updating data


            if (MessageBox.Show("Data will be upated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update certificatesdp set project_name = '" + projectname + "',member_name = '" + name + "',member_id = '" + id + "',intake = '" + intake + "',Issue_date = '" + date + "',teacher_name = '" + teacher + "' where stuid = " + rowid + "";
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
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp";
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
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from certificatesdp where stuid = " + rowid + "";
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
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp where project_name = '" + projectnametextbox.Text + "'";

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
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from certificatesdp where project_name = '" + projectnametextbox.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            String projectname = ds.Tables[0].Rows[0][1].ToString();
            String name = ds.Tables[0].Rows[0][2].ToString();
            String id = ds.Tables[0].Rows[0][3].ToString();
            String intake = ds.Tables[0].Rows[0][4].ToString();
            String teacher = ds.Tables[0].Rows[0][5].ToString();
            String date = ds.Tables[0].Rows[0][6].ToString();

            Bitmap bitmap = Properties.Resources.sdp_30012;
            Image image = new Bitmap(bitmap);


            e.Graphics.DrawImage(image, 0, 0, 1100, 850);

            e.Graphics.DrawString(projectname, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(429, 442));
            e.Graphics.DrawString(name, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, 490));
            e.Graphics.DrawString(id, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(220, 528));
            e.Graphics.DrawString(intake, new Font("Cambria", 14, FontStyle.Regular), Brushes.Black, new Point(220, 565));
            e.Graphics.DrawString(date, new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(180, 150));
            e.Graphics.DrawString(teacher, new Font("Arial Black", 14, FontStyle.Regular), Brushes.Black, new Point(172, 685));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
