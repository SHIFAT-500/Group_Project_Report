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
    public partial class takecourse3 : Form
    {
        public takecourse3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void nametextbox_TextChanged(object sender, EventArgs e)
        {
            nametextbox.BackColor = Color.White;
        }

        private void enrolltextbox_TextChanged(object sender, EventArgs e)
        {
            enrolltextbox.BackColor = Color.White;
        }

        private void malebutton_CheckedChanged(object sender, EventArgs e)
        {
            malebutton.BackColor = Color.White;
        }

        private void femalebutton_CheckedChanged(object sender, EventArgs e)
        {
            femalebutton.BackColor = Color.White;
        }

        private void contacttextbox_TextChanged(object sender, EventArgs e)
        {
            contacttextbox.BackColor = Color.White;
        }

        private void emailtextbox_TextChanged(object sender, EventArgs e)
        {
            emailtextbox.BackColor = Color.White;
        }

        private void institutetextbox_TextChanged_1(object sender, EventArgs e)
        {
            institutetextbox.BackColor = Color.White;
        }

        private void countrytextbox_TextChanged(object sender, EventArgs e)
        {
            countrytextbox.BackColor = Color.White;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (nametextbox.Text == "")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }
            if (enrolltextbox.Text == "")
            {
                enrolltextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Enroll", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enrolltextbox.Focus();
                return;
            }
            if (!((malebutton.Checked) || (femalebutton.Checked)))
            {
                MessageBox.Show("Please enter your Gender", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (contacttextbox.Text == "")
            {
                contacttextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Contact", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }
            
            if (institutetextbox.Text == "")
            {
                institutetextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Institute Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                institutetextbox.Focus();
                return;
            }
            if (countrytextbox.Text == "")
            {
                countrytextbox.BackColor = Color.Red;
                MessageBox.Show("Please enter your Country Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countrytextbox.Focus();
                return;
            }


            String sname = nametextbox.Text;
            String senroll = enrolltextbox.Text;
            String sgender;

            if (malebutton.Checked)
            {
                sgender = "Male";
            }
            else
            {
                sgender = "Female";
            }

            String scontact = contacttextbox.Text;
            String semail = userlogin.semail;
            String sinstitute = institutetextbox.Text;
            String scountry = countrytextbox.Text;

            int a = contacttextbox.Text.Length;
            if (!(a == 11))
            {
                MessageBox.Show("Invalid Contact", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contacttextbox.Focus();
                return;
            }


            // cheaking if the student enroll is already exist in database


            int count = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addstudentcourse3 where senroll = '" + enrolltextbox.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

            if (count > 0)
            {
                MessageBox.Show("Student Enroll aleady exists in database.. Choose Another", "Enroll Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enrolltextbox.Focus();
                return;
            }


            // cheaking if the student email is already exist in database

            int count2;


            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;

            cmd2.CommandText = "select * from addstudentcourse3 where semail = '" + semail + "'";

            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            count2 = Convert.ToInt32(ds2.Tables[0].Rows.Count.ToString());

            if (count2 > 0)
            {
                MessageBox.Show("Student Email aleady exists in database or already taken the course", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailtextbox.Focus();
                return;
            }



            // cheaking if the student contact is already exist in database

            int count3;


            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;

            cmd3.CommandText = "select * from addstudentcourse3 where scontact = '" + contacttextbox.Text + "' ";

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            count3 = Convert.ToInt32(ds3.Tables[0].Rows.Count.ToString());

            if (count3 > 0)
            {
                MessageBox.Show("Student Contact aleady exists in database.. Choose Another", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contacttextbox.Focus();
                return;
            }



            // inerting neew student in databse


            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = "data source = (localdb)\\Local; database = Certificategenerator; integrated security = True";
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con4;

            con4.Open();
            cmd4.CommandText = " insert into addstudentcourse3(sname,senroll,sgender,scontact,semail,sinstitute,scountry) values ('" + sname + "','" + senroll + "','" + sgender + "','" + scontact + "','" + semail + "','" + sinstitute + "','" + scountry + "')";
            cmd4.ExecuteNonQuery();
            con4.Close();

            MessageBox.Show("data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void takecourse1_Load(object sender, EventArgs e)
        {
            emailtextbox.Text = userlogin.semail;
        }

        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void enrolltextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void contacttextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void institutetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void countrytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
