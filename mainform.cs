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
    public partial class mainform : Form
    {
        // Constructor to initialize the form components
        public mainform()
        {
            InitializeComponent();
        }

        // Event handler for the "Exit" button click event (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        // Event handler for the "Exit" button click event (exitbutton2)
        private void exitbutton2_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        // Event handler for the "Admin" button click event (adminbutton)
        private void adminbutton_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin login form and show it
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();

            // Hide the current main form
            this.Hide();    
        }

        // Event handler for the "User" button click event (userbutton)
        private void userbutton_Click(object sender, EventArgs e)
        {
            // Create an instance of the user login form and show it
            userlogin userlogin = new userlogin();
            userlogin.Show();

            // Hide the current main form
            this.Hide();
        }

        // Event handler for the Paint event of the panel (panel1) (currently not used)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // No implementation is provided for this event handler
        }
    }
}
