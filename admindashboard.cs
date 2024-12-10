using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate_Generator
{
    public partial class admindashboard : Form
    {
        public admindashboard()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure You want to Exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void course1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Student add_Student = new Add_Student();    
            add_Student.Show();
        }

        private void course1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewcourse1 viewcourse1 = new viewcourse1();
            viewcourse1.Show();
        }

        private void course1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            createcertificate1 createcertificate1 = new createcertificate1();
            createcertificate1.Show();
        }

        private void listOfCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listcertificate1 listcertificate1 = new listcertificate1();
            listcertificate1.Show();
        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Student2 add_Student2 = new Add_Student2();
            add_Student2.Show();
        }

        private void course2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewcourse2 viewcourse2 = new viewcourse2();
            viewcourse2.Show();
        }

        private void course2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            createcertificate2 createcertificate2 = new createcertificate2();
            createcertificate2.Show();
        }

        private void listOfCertificateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listcertificate2 listcertificate2 = new listcertificate2();
            listcertificate2.Show();
        }

        private void sSCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Student3 add_Student3 = new Add_Student3();
            add_Student3.Show();
        }

        private void sSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewcourse3 viewcourse3 = new viewcourse3();
            viewcourse3.Show();
        }

        private void sSCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            createcertificate3 createcertificate3 = new createcertificate3();
            createcertificate3.Show();
        }

        private void listOfCertificateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listcertificate3 listcertificate3 = new listcertificate3();
            listcertificate3.Show();
        }

        private void hSCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Student4 add_Student4 = new Add_Student4();
            add_Student4.Show();
        }

        private void hSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewcourse4 viewcourse4 = new viewcourse4();
            viewcourse4.Show();
        }

        private void hSCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            createcertificate4 createcertificate4 = new createcertificate4();
            createcertificate4.Show();
        }

        private void listOfCertificateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listcertificate4 listcertificate4 = new listcertificate4();
            listcertificate4.Show();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addgroup addgroup = new addgroup();
            addgroup.Show();
        }

        private void viewGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sdpgrouplist sdpgrouplist = new sdpgrouplist();
            sdpgrouplist.Show();
        }

        private void ceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sdplist sdplist = new sdplist();
            sdplist.Show();
        }

        private void issueBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issuebox issuebox = new issuebox();
            issuebox.Show();
        }
    }
}
