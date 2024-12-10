using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Certificate_Generator
{
    public partial class addgroup : Form
    {
        public addgroup()
        {
            InitializeComponent();
        }

        private void Projectnametextbox_TextChanged(object sender, EventArgs e)
        {
            projectnametextbox.BackColor = Color.White;
        }

        private void projectnametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void nametextbox_TextChanged(object sender, EventArgs e)
        {
            nametextbox.BackColor = Color.White;
        }

        private void nametextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (e.KeyChar != 44) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void idtextbox_TextChanged(object sender, EventArgs e)
        {
            idtextbox.BackColor = Color.White;
        }

        private void idtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar!=44))
            {
                e.Handled = true;
            }
        }

        private void intaketextbox_TextChanged(object sender, EventArgs e)
        {
            intaketextbox.BackColor = Color.White;
        }

        private void intaketextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            projectnametextbox.Clear();
            nametextbox.Clear();
            idtextbox.Clear();
            intaketextbox.Clear();
            teachertextbox.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm To Exit?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (projectnametextbox.Text == "")
            {
                projectnametextbox.BackColor = Color.Red;
                MessageBox.Show("Please Enter Project Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                projectnametextbox.Focus();
                return;
            }

            if (nametextbox.Text == "")
            {
                nametextbox.BackColor = Color.Red;
                MessageBox.Show("Please Enter Member Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextbox.Focus();
                return;
            }

            if (idtextbox.Text == "")
            {
                idtextbox.BackColor = Color.Red;
                MessageBox.Show("Please Enter Member ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idtextbox.Focus();
                return;
            }

            if (intaketextbox.Text == "")
            {
                intaketextbox.BackColor = Color.Red;
                MessageBox.Show("Please Enter Intake", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intaketextbox.Focus();
                return;
            }

            if (teachertextbox.Text == "")
            {
                teachertextbox.BackColor = Color.Red;
                MessageBox.Show("Please Enter Teacher Name ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                teachertextbox.Focus();
                return;
            }


            String projectname = projectnametextbox.Text;
            String name = nametextbox.Text;
            String id = idtextbox.Text;
            String intake = intaketextbox.Text;
            String teacher = teachertextbox.Text;


            // inerting neew student in databse


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (localdb)\\Local; database = certificate_generator3; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = " insert into addsdp(project_name,member_name,member_id,intake,teacher_name) values ('" + projectname + "','" + name + "','" + id + "','" + intake + "','" + teacher + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("data saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void teachertextbox_TextChanged(object sender, EventArgs e)
        {
            teachertextbox.BackColor = Color.White;
        }

        private void teachertextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
