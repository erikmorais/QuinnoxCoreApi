namespace WinFormQuinox
{
    partial class Form1
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
            this.dgvMoviesList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.cmbPlot = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMoviesList
            // 
            this.dgvMoviesList.AllowUserToAddRows = false;
            this.dgvMoviesList.AllowUserToDeleteRows = false;
            this.dgvMoviesList.AllowUserToOrderColumns = true;
            this.dgvMoviesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoviesList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMoviesList.Location = new System.Drawing.Point(0, 309);
            this.dgvMoviesList.Name = "dgvMoviesList";
            this.dgvMoviesList.ReadOnly = true;
            this.dgvMoviesList.RowTemplate.Height = 40;
            this.dgvMoviesList.Size = new System.Drawing.Size(1605, 469);
            this.dgvMoviesList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(13, 51);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(360, 38);
            this.txtTitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(395, 51);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(101, 38);
            this.txtYear.TabIndex = 5;
            // 
            // cmbPlot
            // 
            this.cmbPlot.FormattingEnabled = true;
            this.cmbPlot.Items.AddRange(new object[] {
            "----",
            "short",
            "full"});
            this.cmbPlot.Location = new System.Drawing.Point(508, 50);
            this.cmbPlot.Name = "cmbPlot";
            this.cmbPlot.Size = new System.Drawing.Size(121, 39);
            this.cmbPlot.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Plot";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 778);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPlot);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvMoviesList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoviesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMoviesList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cmbPlot;
        private System.Windows.Forms.Label label3;
    }
}

