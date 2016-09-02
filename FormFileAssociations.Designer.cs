namespace Gaku
{
    partial class FormFileAssociations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileAssociations));
            this.button1 = new System.Windows.Forms.Button();
            this.rbCurrentUser = new System.Windows.Forms.RadioButton();
            this.cbJpg = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGif = new System.Windows.Forms.CheckBox();
            this.cbBmp = new System.Windows.Forms.CheckBox();
            this.cbPng = new System.Windows.Forms.CheckBox();
            this.rbAllUsers = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbCurrentUser
            // 
            this.rbCurrentUser.AutoSize = true;
            this.rbCurrentUser.Checked = true;
            this.rbCurrentUser.Location = new System.Drawing.Point(21, 29);
            this.rbCurrentUser.Name = "rbCurrentUser";
            this.rbCurrentUser.Size = new System.Drawing.Size(82, 17);
            this.rbCurrentUser.TabIndex = 1;
            this.rbCurrentUser.TabStop = true;
            this.rbCurrentUser.Text = "Current user";
            this.rbCurrentUser.UseVisualStyleBackColor = true;
            // 
            // cbJpg
            // 
            this.cbJpg.AutoSize = true;
            this.cbJpg.Location = new System.Drawing.Point(22, 34);
            this.cbJpg.Name = "cbJpg";
            this.cbJpg.Size = new System.Drawing.Size(108, 17);
            this.cbJpg.TabIndex = 2;
            this.cbJpg.Text = "JPEG (.jpg, .jpeg)";
            this.cbJpg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGif);
            this.groupBox1.Controls.Add(this.cbBmp);
            this.groupBox1.Controls.Add(this.cbPng);
            this.groupBox1.Controls.Add(this.cbJpg);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File type associations: ";
            // 
            // cbGif
            // 
            this.cbGif.AutoSize = true;
            this.cbGif.Enabled = false;
            this.cbGif.Location = new System.Drawing.Point(22, 103);
            this.cbGif.Name = "cbGif";
            this.cbGif.Size = new System.Drawing.Size(66, 17);
            this.cbGif.TabIndex = 5;
            this.cbGif.Text = "GIF (.gif)";
            this.cbGif.UseVisualStyleBackColor = true;
            // 
            // cbBmp
            // 
            this.cbBmp.AutoSize = true;
            this.cbBmp.Location = new System.Drawing.Point(22, 80);
            this.cbBmp.Name = "cbBmp";
            this.cbBmp.Size = new System.Drawing.Size(81, 17);
            this.cbBmp.TabIndex = 4;
            this.cbBmp.Text = "BMP (.bmp)";
            this.cbBmp.UseVisualStyleBackColor = true;
            // 
            // cbPng
            // 
            this.cbPng.AutoSize = true;
            this.cbPng.Location = new System.Drawing.Point(22, 57);
            this.cbPng.Name = "cbPng";
            this.cbPng.Size = new System.Drawing.Size(79, 17);
            this.cbPng.TabIndex = 3;
            this.cbPng.Text = "PNG (.png)";
            this.cbPng.UseVisualStyleBackColor = true;
            // 
            // rbAllUsers
            // 
            this.rbAllUsers.AutoSize = true;
            this.rbAllUsers.Location = new System.Drawing.Point(21, 58);
            this.rbAllUsers.Name = "rbAllUsers";
            this.rbAllUsers.Size = new System.Drawing.Size(64, 17);
            this.rbAllUsers.TabIndex = 4;
            this.rbAllUsers.Text = "All users";
            this.rbAllUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAllUsers);
            this.groupBox2.Controls.Add(this.rbCurrentUser);
            this.groupBox2.Location = new System.Drawing.Point(215, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 97);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Apply for: ";
            // 
            // FormFileAssociations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 171);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFileAssociations";
            this.Text = "File Associations";
            this.Load += new System.EventHandler(this.FormFileAssociations_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbCurrentUser;
        private System.Windows.Forms.CheckBox cbJpg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAllUsers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbGif;
        private System.Windows.Forms.CheckBox cbBmp;
        private System.Windows.Forms.CheckBox cbPng;
    }
}