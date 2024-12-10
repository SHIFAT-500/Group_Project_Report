namespace Certificate_Generator
{
    partial class signup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signup));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.useremailtextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passtextbox = new System.Windows.Forms.TextBox();
            this.confirmpasstextbox = new System.Windows.Forms.TextBox();
            this.showpasscheakbox1 = new System.Windows.Forms.CheckBox();
            this.showpasscheakbox2 = new System.Windows.Forms.CheckBox();
            this.signupbutton = new System.Windows.Forms.Button();
            this.backbutton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tccheakbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(154, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIGN UP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter E-mail";
            // 
            // useremailtextbox
            // 
            this.useremailtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useremailtextbox.Location = new System.Drawing.Point(48, 144);
            this.useremailtextbox.Name = "useremailtextbox";
            this.useremailtextbox.Size = new System.Drawing.Size(250, 27);
            this.useremailtextbox.TabIndex = 4;
            this.useremailtextbox.TextChanged += new System.EventHandler(this.Useremailtextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // passtextbox
            // 
            this.passtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtextbox.Location = new System.Drawing.Point(48, 220);
            this.passtextbox.Name = "passtextbox";
            this.passtextbox.Size = new System.Drawing.Size(250, 27);
            this.passtextbox.TabIndex = 7;
            this.passtextbox.UseSystemPasswordChar = true;
            this.passtextbox.TextChanged += new System.EventHandler(this.passtextbox_TextChanged);
            // 
            // confirmpasstextbox
            // 
            this.confirmpasstextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpasstextbox.Location = new System.Drawing.Point(48, 308);
            this.confirmpasstextbox.Name = "confirmpasstextbox";
            this.confirmpasstextbox.Size = new System.Drawing.Size(250, 27);
            this.confirmpasstextbox.TabIndex = 8;
            this.confirmpasstextbox.UseSystemPasswordChar = true;
            this.confirmpasstextbox.TextChanged += new System.EventHandler(this.confirmpasstextbox_TextChanged);
            // 
            // showpasscheakbox1
            // 
            this.showpasscheakbox1.AutoSize = true;
            this.showpasscheakbox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showpasscheakbox1.Location = new System.Drawing.Point(179, 253);
            this.showpasscheakbox1.Name = "showpasscheakbox1";
            this.showpasscheakbox1.Size = new System.Drawing.Size(125, 20);
            this.showpasscheakbox1.TabIndex = 9;
            this.showpasscheakbox1.Text = "Show Password";
            this.showpasscheakbox1.UseVisualStyleBackColor = true;
            this.showpasscheakbox1.CheckedChanged += new System.EventHandler(this.showpasscheakbox1_CheckedChanged);
            // 
            // showpasscheakbox2
            // 
            this.showpasscheakbox2.AutoSize = true;
            this.showpasscheakbox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showpasscheakbox2.Location = new System.Drawing.Point(179, 341);
            this.showpasscheakbox2.Name = "showpasscheakbox2";
            this.showpasscheakbox2.Size = new System.Drawing.Size(125, 20);
            this.showpasscheakbox2.TabIndex = 10;
            this.showpasscheakbox2.Text = "Show Password";
            this.showpasscheakbox2.UseVisualStyleBackColor = true;
            this.showpasscheakbox2.CheckedChanged += new System.EventHandler(this.showpasscheakbox2_CheckedChanged);
            // 
            // signupbutton
            // 
            this.signupbutton.BackColor = System.Drawing.Color.Cyan;
            this.signupbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signupbutton.Enabled = false;
            this.signupbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupbutton.Location = new System.Drawing.Point(40, 406);
            this.signupbutton.Name = "signupbutton";
            this.signupbutton.Size = new System.Drawing.Size(264, 39);
            this.signupbutton.TabIndex = 11;
            this.signupbutton.Text = "SIGN UP";
            this.signupbutton.UseVisualStyleBackColor = false;
            this.signupbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // backbutton
            // 
            this.backbutton.BackColor = System.Drawing.Color.Black;
            this.backbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbutton.ForeColor = System.Drawing.Color.Cyan;
            this.backbutton.Location = new System.Drawing.Point(40, 462);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(264, 39);
            this.backbutton.TabIndex = 12;
            this.backbutton.Text = "BACK";
            this.backbutton.UseVisualStyleBackColor = false;
            this.backbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Certificate_Generator.Properties.Resources.Question_Mark;
            this.pictureBox3.Location = new System.Drawing.Point(304, 144);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "Must Use (@gamil.com) at the End");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(310, -4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(44, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tccheakbox
            // 
            this.tccheakbox.AutoSize = true;
            this.tccheakbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.tccheakbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tccheakbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tccheakbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tccheakbox.Location = new System.Drawing.Point(48, 370);
            this.tccheakbox.Name = "tccheakbox";
            this.tccheakbox.Size = new System.Drawing.Size(162, 24);
            this.tccheakbox.TabIndex = 14;
            this.tccheakbox.Text = "Accept Our T/C";
            this.tccheakbox.UseVisualStyleBackColor = false;
            this.tccheakbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(347, 541);
            this.Controls.Add(this.tccheakbox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.signupbutton);
            this.Controls.Add(this.showpasscheakbox2);
            this.Controls.Add(this.showpasscheakbox1);
            this.Controls.Add(this.confirmpasstextbox);
            this.Controls.Add(this.passtextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.useremailtextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox useremailtextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passtextbox;
        private System.Windows.Forms.TextBox confirmpasstextbox;
        private System.Windows.Forms.CheckBox showpasscheakbox1;
        private System.Windows.Forms.CheckBox showpasscheakbox2;
        private System.Windows.Forms.Button signupbutton;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox tccheakbox;
    }
}