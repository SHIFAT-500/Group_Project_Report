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
    public partial class sdpgrouplist : Form
    {
        public sdpgrouplist()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if(searchtextbox.Text != "")
            {
                label1.Visible= false;
                Image image = Image.FromFile("D:\\VS CODE\\search1.gif");
                pictureBox1 .Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addsdp where project_name LIKE '" + searchtextbox.Text+"%'";
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

                cmd.CommandText = "select * from addsdp";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void viewcourse1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addsdp";
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
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addsdp where stuid = " + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                projectnametextbox.Text = ds.Tables[0].Rows[0][1].ToString();
                nametextbox.Text = ds.Tables[0].Rows[0][2].ToString();
                idtextbox.Text = ds.Tables[0].Rows[0][3].ToString();
                intaketextbox.Text = ds.Tables[0].Rows[0][4].ToString();
                teachertextbox.Text = ds.Tables[0].Rows[0][5].ToString();
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
            String intake = intaketextbox.Text;
            String date = datetime.Text;
            String teacher = teachertextbox.Text;

            //updating data


            if (MessageBox.Show("Data will be upated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update addsdp set project_name = '" + projectname + "',member_name = '" + name + "',member_id = '" + id + "',intake = '" + intake + "',teacher_name = '" + teacher + "' where stuid = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viewcourse1_Load(this, null);


                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                cmd1.CommandText = "update certificatesdp set project_name = '" + projectname + "',member_name = '" + name + "',member_id = '" + id + "',intake = '" + intake + "',Issue_date = '" + date + "',teacher_name = '" + teacher + "' where project_name = '" + projectname + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            viewcourse1_Load(this, null);
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from addsdp where stuid = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viewcourse1_Load(this, null);

            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unwanted data will be lost", "Exit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { 

                 this.Close();

            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String projectname = projectnametextbox.Text;
            String name = nametextbox.Text;
            String id = idtextbox.Text;
            String intake = intaketextbox.Text;
            String date = datetime.Text;
            String teacher = teachertextbox.Text;

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;

            con1.Open();
            cmd1.CommandText = " insert into certificatesdp(project_name,member_name,member_id,intake,Issue_date,teacher_name) values ('" + projectname + "','" + name + "','" + id + "','" + intake + "','" + date + "','" + teacher + "')";
            cmd1.ExecuteNonQuery();
            con1.Close();

            MessageBox.Show("Certificate created!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
