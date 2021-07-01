
namespace ProjectFinEtude
{
    partial class ingredientsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ingredientsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearIngredientsBtn = new System.Windows.Forms.PictureBox();
            this.updtaeIngredientsBtn = new System.Windows.Forms.PictureBox();
            this.deleteIngredientsBtn = new System.Windows.Forms.PictureBox();
            this.addIngredientsBtn = new System.Windows.Forms.PictureBox();
            this.ingredientQuantityTxtBx = new System.Windows.Forms.TextBox();
            this.ingredientNameTxtBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.foodNameLbl = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.ingredientsDgv = new System.Windows.Forms.DataGridView();
            this.directionTxtBx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clearDirectionBtn = new System.Windows.Forms.PictureBox();
            this.updateDirectionBtn = new System.Windows.Forms.PictureBox();
            this.deleteDirectionBtn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addDirectionBtn = new System.Windows.Forms.PictureBox();
            this.directionsDgv = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clearIngredientsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updtaeIngredientsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteIngredientsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addIngredientsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clearDirectionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateDirectionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteDirectionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDirectionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(428, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 405);
            this.panel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearIngredientsBtn);
            this.groupBox1.Controls.Add(this.updtaeIngredientsBtn);
            this.groupBox1.Controls.Add(this.deleteIngredientsBtn);
            this.groupBox1.Controls.Add(this.addIngredientsBtn);
            this.groupBox1.Controls.Add(this.ingredientQuantityTxtBx);
            this.groupBox1.Controls.Add(this.ingredientNameTxtBx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(9, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 185);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredients info";
            // 
            // clearIngredientsBtn
            // 
            this.clearIngredientsBtn.Image = global::ProjectFinEtude.Properties.Resources.eraser;
            this.clearIngredientsBtn.Location = new System.Drawing.Point(262, 137);
            this.clearIngredientsBtn.Name = "clearIngredientsBtn";
            this.clearIngredientsBtn.Size = new System.Drawing.Size(45, 40);
            this.clearIngredientsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearIngredientsBtn.TabIndex = 39;
            this.clearIngredientsBtn.TabStop = false;
            this.clearIngredientsBtn.Click += new System.EventHandler(this.clearIngredientsBtn_Click);
            // 
            // updtaeIngredientsBtn
            // 
            this.updtaeIngredientsBtn.Image = global::ProjectFinEtude.Properties.Resources.update;
            this.updtaeIngredientsBtn.Location = new System.Drawing.Point(209, 137);
            this.updtaeIngredientsBtn.Name = "updtaeIngredientsBtn";
            this.updtaeIngredientsBtn.Size = new System.Drawing.Size(47, 40);
            this.updtaeIngredientsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.updtaeIngredientsBtn.TabIndex = 38;
            this.updtaeIngredientsBtn.TabStop = false;
            this.updtaeIngredientsBtn.Click += new System.EventHandler(this.updtaeIngredientsBtn_Click);
            // 
            // deleteIngredientsBtn
            // 
            this.deleteIngredientsBtn.Image = global::ProjectFinEtude.Properties.Resources.remove;
            this.deleteIngredientsBtn.Location = new System.Drawing.Point(156, 137);
            this.deleteIngredientsBtn.Name = "deleteIngredientsBtn";
            this.deleteIngredientsBtn.Size = new System.Drawing.Size(47, 40);
            this.deleteIngredientsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteIngredientsBtn.TabIndex = 37;
            this.deleteIngredientsBtn.TabStop = false;
            this.deleteIngredientsBtn.Click += new System.EventHandler(this.deleteIngredientsBtn_Click);
            // 
            // addIngredientsBtn
            // 
            this.addIngredientsBtn.Image = global::ProjectFinEtude.Properties.Resources.add;
            this.addIngredientsBtn.Location = new System.Drawing.Point(105, 137);
            this.addIngredientsBtn.Name = "addIngredientsBtn";
            this.addIngredientsBtn.Size = new System.Drawing.Size(45, 40);
            this.addIngredientsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addIngredientsBtn.TabIndex = 36;
            this.addIngredientsBtn.TabStop = false;
            this.addIngredientsBtn.Click += new System.EventHandler(this.addIngredientsBtn_Click);
            // 
            // ingredientQuantityTxtBx
            // 
            this.ingredientQuantityTxtBx.Location = new System.Drawing.Point(156, 52);
            this.ingredientQuantityTxtBx.Name = "ingredientQuantityTxtBx";
            this.ingredientQuantityTxtBx.Size = new System.Drawing.Size(181, 23);
            this.ingredientQuantityTxtBx.TabIndex = 1;
            // 
            // ingredientNameTxtBx
            // 
            this.ingredientNameTxtBx.Location = new System.Drawing.Point(156, 95);
            this.ingredientNameTxtBx.Name = "ingredientNameTxtBx";
            this.ingredientNameTxtBx.Size = new System.Drawing.Size(181, 23);
            this.ingredientNameTxtBx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(18, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ingredient name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(74, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity:";
            // 
            // foodNameLbl
            // 
            this.foodNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foodNameLbl.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodNameLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.foodNameLbl.Location = new System.Drawing.Point(9, 41);
            this.foodNameLbl.Name = "foodNameLbl";
            this.foodNameLbl.Size = new System.Drawing.Size(844, 31);
            this.foodNameLbl.TabIndex = 9;
            this.foodNameLbl.Text = "Something weird";
            this.foodNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Image = global::ProjectFinEtude.Properties.Resources.minimize2;
            this.minimizeBtn.Location = new System.Drawing.Point(777, 2);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(42, 36);
            this.minimizeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizeBtn.TabIndex = 7;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::ProjectFinEtude.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(816, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(42, 36);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 8;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // ingredientsDgv
            // 
            this.ingredientsDgv.AllowUserToAddRows = false;
            this.ingredientsDgv.AllowUserToDeleteRows = false;
            this.ingredientsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ingredientsDgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.ingredientsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsDgv.Location = new System.Drawing.Point(9, 266);
            this.ingredientsDgv.Name = "ingredientsDgv";
            this.ingredientsDgv.ReadOnly = true;
            this.ingredientsDgv.RowHeadersVisible = false;
            this.ingredientsDgv.RowHeadersWidth = 51;
            this.ingredientsDgv.RowTemplate.Height = 26;
            this.ingredientsDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ingredientsDgv.Size = new System.Drawing.Size(412, 230);
            this.ingredientsDgv.TabIndex = 5;
            this.ingredientsDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsDgv_CellClick);
            // 
            // directionTxtBx
            // 
            this.directionTxtBx.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionTxtBx.Location = new System.Drawing.Point(6, 43);
            this.directionTxtBx.Multiline = true;
            this.directionTxtBx.Name = "directionTxtBx";
            this.directionTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.directionTxtBx.Size = new System.Drawing.Size(408, 76);
            this.directionTxtBx.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clearDirectionBtn);
            this.groupBox2.Controls.Add(this.directionTxtBx);
            this.groupBox2.Controls.Add(this.updateDirectionBtn);
            this.groupBox2.Controls.Add(this.deleteDirectionBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.addDirectionBtn);
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(437, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(416, 185);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Directions";
            // 
            // clearDirectionBtn
            // 
            this.clearDirectionBtn.Image = global::ProjectFinEtude.Properties.Resources.eraser;
            this.clearDirectionBtn.Location = new System.Drawing.Point(264, 137);
            this.clearDirectionBtn.Name = "clearDirectionBtn";
            this.clearDirectionBtn.Size = new System.Drawing.Size(45, 40);
            this.clearDirectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearDirectionBtn.TabIndex = 39;
            this.clearDirectionBtn.TabStop = false;
            this.clearDirectionBtn.Click += new System.EventHandler(this.clearDirectionBtn_Click);
            // 
            // updateDirectionBtn
            // 
            this.updateDirectionBtn.Image = global::ProjectFinEtude.Properties.Resources.update;
            this.updateDirectionBtn.Location = new System.Drawing.Point(211, 137);
            this.updateDirectionBtn.Name = "updateDirectionBtn";
            this.updateDirectionBtn.Size = new System.Drawing.Size(47, 40);
            this.updateDirectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.updateDirectionBtn.TabIndex = 38;
            this.updateDirectionBtn.TabStop = false;
            this.updateDirectionBtn.Click += new System.EventHandler(this.updateDirectionBtn_Click);
            // 
            // deleteDirectionBtn
            // 
            this.deleteDirectionBtn.Image = global::ProjectFinEtude.Properties.Resources.remove;
            this.deleteDirectionBtn.Location = new System.Drawing.Point(158, 137);
            this.deleteDirectionBtn.Name = "deleteDirectionBtn";
            this.deleteDirectionBtn.Size = new System.Drawing.Size(47, 40);
            this.deleteDirectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteDirectionBtn.TabIndex = 37;
            this.deleteDirectionBtn.TabStop = false;
            this.deleteDirectionBtn.Click += new System.EventHandler(this.deleteDirectionBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(169, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Direction:";
            // 
            // addDirectionBtn
            // 
            this.addDirectionBtn.Image = global::ProjectFinEtude.Properties.Resources.add;
            this.addDirectionBtn.Location = new System.Drawing.Point(107, 137);
            this.addDirectionBtn.Name = "addDirectionBtn";
            this.addDirectionBtn.Size = new System.Drawing.Size(45, 40);
            this.addDirectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addDirectionBtn.TabIndex = 36;
            this.addDirectionBtn.TabStop = false;
            this.addDirectionBtn.Click += new System.EventHandler(this.addDirectionBtn_Click);
            // 
            // directionsDgv
            // 
            this.directionsDgv.AllowUserToAddRows = false;
            this.directionsDgv.AllowUserToDeleteRows = false;
            this.directionsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.directionsDgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.directionsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.directionsDgv.Location = new System.Drawing.Point(437, 266);
            this.directionsDgv.Name = "directionsDgv";
            this.directionsDgv.ReadOnly = true;
            this.directionsDgv.RowHeadersVisible = false;
            this.directionsDgv.RowHeadersWidth = 51;
            this.directionsDgv.RowTemplate.Height = 26;
            this.directionsDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.directionsDgv.Size = new System.Drawing.Size(416, 230);
            this.directionsDgv.TabIndex = 14;
            this.directionsDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.directionsDgv_CellClick);
            // 
            // ingredientsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 501);
            this.Controls.Add(this.directionsDgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.foodNameLbl);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.ingredientsDgv);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ingredientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ingredientsForm";
            this.Load += new System.EventHandler(this.ingredientsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clearIngredientsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updtaeIngredientsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteIngredientsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addIngredientsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsDgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clearDirectionBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateDirectionBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteDirectionBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addDirectionBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionsDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label foodNameLbl;
        private System.Windows.Forms.PictureBox minimizeBtn;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.DataGridView ingredientsDgv;
        private System.Windows.Forms.TextBox directionTxtBx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView directionsDgv;
        private System.Windows.Forms.TextBox ingredientNameTxtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ingredientQuantityTxtBx;
        private System.Windows.Forms.PictureBox clearIngredientsBtn;
        private System.Windows.Forms.PictureBox updtaeIngredientsBtn;
        private System.Windows.Forms.PictureBox deleteIngredientsBtn;
        private System.Windows.Forms.PictureBox addIngredientsBtn;
        private System.Windows.Forms.PictureBox clearDirectionBtn;
        private System.Windows.Forms.PictureBox updateDirectionBtn;
        private System.Windows.Forms.PictureBox deleteDirectionBtn;
        private System.Windows.Forms.PictureBox addDirectionBtn;
    }
}