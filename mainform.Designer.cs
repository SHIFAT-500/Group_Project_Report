namespace Certificate_Generator
{
    partial class mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitbutton1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adminbutton = new System.Windows.Forms.Button();
            this.userbutton = new System.Windows.Forms.Button();
            this.exitbutton2 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(94)))), ((int)(((byte)(234)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.exitbutton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(778, 36);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // exitbutton1
            // 
            this.exitbutton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbutton1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.exitbutton1.FlatAppearance.BorderSize = 0;
            this.exitbutton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.exitbutton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.exitbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton1.Location = new System.Drawing.Point(728, -1);
            this.exitbutton1.Name = "exitbutton1";
            this.exitbutton1.Size = new System.Drawing.Size(49, 39);
            this.exitbutton1.TabIndex = 0;
            this.exitbutton1.Text = "X";
            this.exitbutton1.UseVisualStyleBackColor = true;
            this.exitbutton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(94)))), ((int)(((byte)(234)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 528);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Certificate_Generator.Properties.Resources._7F4w;
            this.pictureBox1.Location = new System.Drawing.Point(26, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 252);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Certificate Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(123)))), ((int)(((byte)(236)))));
            this.label2.Location = new System.Drawing.Point(496, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "LOG IN";
            // 
            // adminbutton
            // 
            this.adminbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.adminbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminbutton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.adminbutton.FlatAppearance.BorderSize = 10;
            this.adminbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.adminbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.adminbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.adminbutton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminbutton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.adminbutton.Location = new System.Drawing.Point(473, 274);
            this.adminbutton.Name = "adminbutton";
            this.adminbutton.Size = new System.Drawing.Size(242, 53);
            this.adminbutton.TabIndex = 1;
            this.adminbutton.Text = "ADMIN";
            this.adminbutton.UseVisualStyleBackColor = false;
            this.adminbutton.Click += new System.EventHandler(this.adminbutton_Click);
            // 
            // userbutton
            // 
            this.userbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.userbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userbutton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.userbutton.FlatAppearance.BorderSize = 10;
            this.userbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.userbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.userbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userbutton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userbutton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.userbutton.Location = new System.Drawing.Point(473, 358);
            this.userbutton.Name = "userbutton";
            this.userbutton.Size = new System.Drawing.Size(242, 53);
            this.userbutton.TabIndex = 2;
            this.userbutton.Text = "USER";
            this.userbutton.UseVisualStyleBackColor = false;
            this.userbutton.Click += new System.EventHandler(this.userbutton_Click);
            // 
            // exitbutton2
            // 
            this.exitbutton2.BackColor = System.Drawing.Color.Black;
            this.exitbutton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbutton2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.exitbutton2.FlatAppearance.BorderSize = 10;
            this.exitbutton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew;
            this.exitbutton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.exitbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitbutton2.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.exitbutton2.Location = new System.Drawing.Point(431, 461);
            this.exitbutton2.Name = "exitbutton2";
            this.exitbutton2.Size = new System.Drawing.Size(242, 53);
            this.exitbutton2.TabIndex = 3;
            this.exitbutton2.Text = "EXIT";
            this.exitbutton2.UseVisualStyleBackColor = false;
            this.exitbutton2.Click += new System.EventHandler(this.exitbutton2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Certificate_Generator.Properties.Resources.User;
            this.pictureBox4.Location = new System.Drawing.Point(394, 358);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(59, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Certificate_Generator.Properties.Resources.admin;
            this.pictureBox3.Location = new System.Drawing.Point(394, 274);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Certificate_Generator.Properties.Resources.certificate_icon;
            this.pictureBox2.Location = new System.Drawing.Point(512, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 564);
            this.Controls.Add(this.exitbutton2);
            this.Controls.Add(this.userbutton);
            this.Controls.Add(this.adminbutton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitbutton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button adminbutton;
        private System.Windows.Forms.Button userbutton;
        private System.Windows.Forms.Button exitbutton2;
    }
}

