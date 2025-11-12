namespace SensorDataApplication
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtbxUpperBound = new System.Windows.Forms.TextBox();
            this.txtbxLowerBound = new System.Windows.Forms.TextBox();
            this.txtbxSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSetBounds = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblUpperBound = new System.Windows.Forms.Label();
            this.lblLowerBound = new System.Windows.Forms.Label();
            this.grpbxSearch = new System.Windows.Forms.GroupBox();
            this.grpbxBounds = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpbxSearch.SuspendLayout();
            this.grpbxBounds.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(576, 374);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtbxUpperBound
            // 
            this.txtbxUpperBound.Location = new System.Drawing.Point(15, 27);
            this.txtbxUpperBound.Name = "txtbxUpperBound";
            this.txtbxUpperBound.Size = new System.Drawing.Size(100, 20);
            this.txtbxUpperBound.TabIndex = 1;
            // 
            // txtbxLowerBound
            // 
            this.txtbxLowerBound.Location = new System.Drawing.Point(15, 83);
            this.txtbxLowerBound.Name = "txtbxLowerBound";
            this.txtbxLowerBound.Size = new System.Drawing.Size(100, 20);
            this.txtbxLowerBound.TabIndex = 2;
            // 
            // txtbxSearchTerm
            // 
            this.txtbxSearchTerm.Location = new System.Drawing.Point(16, 19);
            this.txtbxSearchTerm.Name = "txtbxSearchTerm";
            this.txtbxSearchTerm.Size = new System.Drawing.Size(100, 20);
            this.txtbxSearchTerm.TabIndex = 3;
            // 
            // btnSetBounds
            // 
            this.btnSetBounds.Location = new System.Drawing.Point(25, 118);
            this.btnSetBounds.Name = "btnSetBounds";
            this.btnSetBounds.Size = new System.Drawing.Size(75, 23);
            this.btnSetBounds.TabIndex = 4;
            this.btnSetBounds.Text = "Set Bounds";
            this.btnSetBounds.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(29, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblUpperBound
            // 
            this.lblUpperBound.AutoSize = true;
            this.lblUpperBound.Location = new System.Drawing.Point(22, 11);
            this.lblUpperBound.Name = "lblUpperBound";
            this.lblUpperBound.Size = new System.Drawing.Size(84, 13);
            this.lblUpperBound.TabIndex = 6;
            this.lblUpperBound.Text = "Upper Boundary";
            // 
            // lblLowerBound
            // 
            this.lblLowerBound.AutoSize = true;
            this.lblLowerBound.Location = new System.Drawing.Point(25, 64);
            this.lblLowerBound.Name = "lblLowerBound";
            this.lblLowerBound.Size = new System.Drawing.Size(84, 13);
            this.lblLowerBound.TabIndex = 7;
            this.lblLowerBound.Text = "Lower Boundary";
            // 
            // grpbxSearch
            // 
            this.grpbxSearch.Controls.Add(this.txtbxSearchTerm);
            this.grpbxSearch.Controls.Add(this.btnSearch);
            this.grpbxSearch.Location = new System.Drawing.Point(739, 75);
            this.grpbxSearch.Name = "grpbxSearch";
            this.grpbxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpbxSearch.Size = new System.Drawing.Size(135, 88);
            this.grpbxSearch.TabIndex = 8;
            this.grpbxSearch.TabStop = false;
            // 
            // grpbxBounds
            // 
            this.grpbxBounds.Controls.Add(this.txtbxLowerBound);
            this.grpbxBounds.Controls.Add(this.txtbxUpperBound);
            this.grpbxBounds.Controls.Add(this.lblLowerBound);
            this.grpbxBounds.Controls.Add(this.btnSetBounds);
            this.grpbxBounds.Controls.Add(this.lblUpperBound);
            this.grpbxBounds.Location = new System.Drawing.Point(596, 64);
            this.grpbxBounds.Name = "grpbxBounds";
            this.grpbxBounds.Size = new System.Drawing.Size(137, 153);
            this.grpbxBounds.TabIndex = 9;
            this.grpbxBounds.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.grpbxBounds);
            this.Controls.Add(this.grpbxSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "SensorShare";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpbxSearch.ResumeLayout(false);
            this.grpbxSearch.PerformLayout();
            this.grpbxBounds.ResumeLayout(false);
            this.grpbxBounds.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtbxUpperBound;
        private System.Windows.Forms.TextBox txtbxLowerBound;
        private System.Windows.Forms.TextBox txtbxSearchTerm;
        private System.Windows.Forms.Button btnSetBounds;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblUpperBound;
        private System.Windows.Forms.Label lblLowerBound;
        private System.Windows.Forms.GroupBox grpbxSearch;
        private System.Windows.Forms.GroupBox grpbxBounds;
    }
}

