
namespace ProjectFinEtude
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.recipeBtn = new System.Windows.Forms.Button();
            this.usersBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usersUC1 = new ProjectFinEtude.usersUC();
            this.recipeUC1 = new ProjectFinEtude.recipeUC();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.logOutBtn);
            this.panel1.Controls.Add(this.recipeBtn);
            this.panel1.Controls.Add(this.usersBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 614);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ProjectFinEtude.Properties.Resources.logozakwhite2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(33)))), ((int)(((byte)(0)))));
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.closeBtn.FlatAppearance.BorderSize = 2;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(0, 566);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(201, 38);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // logOutBtn
            // 
            this.logOutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.logOutBtn.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.logOutBtn.FlatAppearance.BorderSize = 2;
            this.logOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutBtn.ForeColor = System.Drawing.Color.White;
            this.logOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("logOutBtn.Image")));
            this.logOutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logOutBtn.Location = new System.Drawing.Point(0, 522);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.logOutBtn.Size = new System.Drawing.Size(201, 38);
            this.logOutBtn.TabIndex = 3;
            this.logOutBtn.Text = "Log out";
            this.logOutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logOutBtn.UseVisualStyleBackColor = false;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click_1);
            // 
            // recipeBtn
            // 
            this.recipeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipeBtn.FlatAppearance.BorderSize = 0;
            this.recipeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recipeBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeBtn.ForeColor = System.Drawing.Color.White;
            this.recipeBtn.Image = global::ProjectFinEtude.Properties.Resources.whiteRecipe;
            this.recipeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recipeBtn.Location = new System.Drawing.Point(0, 311);
            this.recipeBtn.Name = "recipeBtn";
            this.recipeBtn.Padding = new System.Windows.Forms.Padding(25, 0, 8, 0);
            this.recipeBtn.Size = new System.Drawing.Size(201, 38);
            this.recipeBtn.TabIndex = 2;
            this.recipeBtn.Text = "Recipe";
            this.recipeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recipeBtn.UseVisualStyleBackColor = true;
            this.recipeBtn.Click += new System.EventHandler(this.recipeBtn_Click);
            // 
            // usersBtn
            // 
            this.usersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersBtn.FlatAppearance.BorderSize = 0;
            this.usersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersBtn.ForeColor = System.Drawing.Color.White;
            this.usersBtn.Image = global::ProjectFinEtude.Properties.Resources.whiteUser;
            this.usersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersBtn.Location = new System.Drawing.Point(0, 265);
            this.usersBtn.Name = "usersBtn";
            this.usersBtn.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.usersBtn.Size = new System.Drawing.Size(201, 38);
            this.usersBtn.TabIndex = 1;
            this.usersBtn.Text = "Users";
            this.usersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usersBtn.UseVisualStyleBackColor = true;
            this.usersBtn.Click += new System.EventHandler(this.usersBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.usersUC1);
            this.panel2.Controls.Add(this.recipeUC1);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(206, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 602);
            this.panel2.TabIndex = 1;
            // 
            // usersUC1
            // 
            this.usersUC1.BackColor = System.Drawing.Color.White;
            this.usersUC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usersUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersUC1.Location = new System.Drawing.Point(0, 0);
            this.usersUC1.Name = "usersUC1";
            this.usersUC1.Padding = new System.Windows.Forms.Padding(3);
            this.usersUC1.Size = new System.Drawing.Size(767, 602);
            this.usersUC1.TabIndex = 2;
            // 
            // recipeUC1
            // 
            this.recipeUC1.BackColor = System.Drawing.Color.White;
            this.recipeUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeUC1.Location = new System.Drawing.Point(0, 0);
            this.recipeUC1.Name = "recipeUC1";
            this.recipeUC1.Padding = new System.Windows.Forms.Padding(3);
            this.recipeUC1.Size = new System.Drawing.Size(767, 602);
            this.recipeUC1.TabIndex = 1;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(981, 614);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button recipeBtn;
        private System.Windows.Forms.Button usersBtn;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Button closeBtn;
        private recipeUC recipeUC1;
        private usersUC usersUC1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}