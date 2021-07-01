
namespace ProjectFinEtude
{
    partial class loginForm
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
            this.passwordErrorLbl = new System.Windows.Forms.Label();
            this.emailErrorLbl = new System.Windows.Forms.Label();
            this.logInBtn = new System.Windows.Forms.Button();
            this.passwordTxtBx = new System.Windows.Forms.TextBox();
            this.emailTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordErrorLbl
            // 
            this.passwordErrorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordErrorLbl.AutoSize = true;
            this.passwordErrorLbl.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordErrorLbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.passwordErrorLbl.Location = new System.Drawing.Point(111, 377);
            this.passwordErrorLbl.Name = "passwordErrorLbl";
            this.passwordErrorLbl.Size = new System.Drawing.Size(0, 14);
            this.passwordErrorLbl.TabIndex = 24;
            // 
            // emailErrorLbl
            // 
            this.emailErrorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailErrorLbl.AutoSize = true;
            this.emailErrorLbl.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailErrorLbl.ForeColor = System.Drawing.Color.Lime;
            this.emailErrorLbl.Location = new System.Drawing.Point(111, 313);
            this.emailErrorLbl.Name = "emailErrorLbl";
            this.emailErrorLbl.Size = new System.Drawing.Size(0, 14);
            this.emailErrorLbl.TabIndex = 23;
            // 
            // logInBtn
            // 
            this.logInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.logInBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logInBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.logInBtn.FlatAppearance.BorderSize = 2;
            this.logInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logInBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logInBtn.Location = new System.Drawing.Point(55, 415);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(313, 36);
            this.logInBtn.TabIndex = 19;
            this.logInBtn.Text = "Log in now";
            this.logInBtn.UseVisualStyleBackColor = false;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // passwordTxtBx
            // 
            this.passwordTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTxtBx.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxtBx.Location = new System.Drawing.Point(99, 346);
            this.passwordTxtBx.Multiline = true;
            this.passwordTxtBx.Name = "passwordTxtBx";
            this.passwordTxtBx.PasswordChar = '*';
            this.passwordTxtBx.Size = new System.Drawing.Size(269, 28);
            this.passwordTxtBx.TabIndex = 17;
            this.passwordTxtBx.TextChanged += new System.EventHandler(this.passwordTxtBx_TextChanged);
            this.passwordTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTxtBx_KeyPress);
            // 
            // emailTxtBx
            // 
            this.emailTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTxtBx.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxtBx.Location = new System.Drawing.Point(99, 282);
            this.emailTxtBx.Multiline = true;
            this.emailTxtBx.Name = "emailTxtBx";
            this.emailTxtBx.Size = new System.Drawing.Size(269, 28);
            this.emailTxtBx.TabIndex = 16;
            this.emailTxtBx.TextChanged += new System.EventHandler(this.emailTxtBx_TextChanged);
            this.emailTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emailTxtBx_KeyPress);
            this.emailTxtBx.Leave += new System.EventHandler(this.emailTxtBx_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(59, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 36);
            this.label2.TabIndex = 20;
            this.label2.Text = "Log into your account";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(139)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(127, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Welcome Back!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(0)))));
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.closeBtn.FlatAppearance.BorderSize = 2;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBtn.Location = new System.Drawing.Point(55, 457);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(313, 36);
            this.closeBtn.TabIndex = 33;
            this.closeBtn.Text = "Exit";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ProjectFinEtude.Properties.Resources.padlock;
            this.pictureBox4.Location = new System.Drawing.Point(55, 345);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ProjectFinEtude.Properties.Resources.email;
            this.pictureBox3.Location = new System.Drawing.Point(56, 282);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProjectFinEtude.Properties.Resources.logozakwhite1;
            this.pictureBox2.Location = new System.Drawing.Point(67, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(288, 149);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(422, 521);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.passwordErrorLbl);
            this.Controls.Add(this.emailErrorLbl);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.passwordTxtBx);
            this.Controls.Add(this.emailTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label passwordErrorLbl;
        private System.Windows.Forms.Label emailErrorLbl;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.TextBox passwordTxtBx;
        private System.Windows.Forms.TextBox emailTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button closeBtn;
    }
}