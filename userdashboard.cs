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
    public partial class userdashboard : Form
    {
        public userdashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void course1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takecourse1 takecourse1 = new takecourse1();
            takecourse1.Show();

        }

        private void course1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            profile1 profile1 = new profile1();
            profile1.Show();
        }

        private void course2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takecourse2 takecourse2 = new takecourse2();
            takecourse2.Show();
        }

        private void course2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            profile2 profile2 = new profile2();
            profile2.Show();
        }

        private void course3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takecourse3 takecourse3 = new takecourse3();
            takecourse3.Show();
        }

        private void course3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            profile3 profile3 = new profile3();
            profile3.Show();
        }

        private void course4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takecourse4 takecourse4 = new takecourse4();
            takecourse4.Show();
        }

        private void course4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            profile4 profile4 = new profile4();
            profile4.Show();
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportissue reportissue = new reportissue();
            reportissue.Show();
        }
    }
}
