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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtbxUpperBound = new System.Windows.Forms.TextBox();
            this.txtbxLowerBound = new System.Windows.Forms.TextBox();
            this.txtbxSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSetBounds = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblUpperBound = new System.Windows.Forms.Label();
            this.lblLowerBound = new System.Windows.Forms.Label();
            this.grpbxSearch = new System.Windows.Forms.GroupBox();
            this.grpbxBounds = new System.Windows.Forms.GroupBox();
            this.btnClearBounds = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.grpbxDatasetNav = new System.Windows.Forms.GroupBox();
            this.grpbxSaveLoad = new System.Windows.Forms.GroupBox();
            this.txtbxAverage = new System.Windows.Forms.TextBox();
            this.lblAverage = new System.Windows.Forms.Label();
            this.grpbxLegend = new System.Windows.Forms.GroupBox();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.pctbxRed = new System.Windows.Forms.PictureBox();
            this.pctbxGreen = new System.Windows.Forms.PictureBox();
            this.pctbxBlue = new System.Windows.Forms.PictureBox();
            this.txtbxTitle = new System.Windows.Forms.TextBox();
            this.grpbxTitle = new System.Windows.Forms.GroupBox();
            this.grpbxSearch.SuspendLayout();
            this.grpbxBounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpbxDatasetNav.SuspendLayout();
            this.grpbxSaveLoad.SuspendLayout();
            this.grpbxLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxBlue)).BeginInit();
            this.grpbxTitle.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSetBounds.Click += new System.EventHandler(this.btnSetBounds_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(30, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.grpbxSearch.Location = new System.Drawing.Point(740, 76);
            this.grpbxSearch.Name = "grpbxSearch";
            this.grpbxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpbxSearch.Size = new System.Drawing.Size(135, 88);
            this.grpbxSearch.TabIndex = 8;
            this.grpbxSearch.TabStop = false;
            // 
            // grpbxBounds
            // 
            this.grpbxBounds.Controls.Add(this.btnClearBounds);
            this.grpbxBounds.Controls.Add(this.txtbxLowerBound);
            this.grpbxBounds.Controls.Add(this.txtbxUpperBound);
            this.grpbxBounds.Controls.Add(this.lblLowerBound);
            this.grpbxBounds.Controls.Add(this.btnSetBounds);
            this.grpbxBounds.Controls.Add(this.lblUpperBound);
            this.grpbxBounds.Location = new System.Drawing.Point(596, 12);
            this.grpbxBounds.Name = "grpbxBounds";
            this.grpbxBounds.Size = new System.Drawing.Size(137, 203);
            this.grpbxBounds.TabIndex = 9;
            this.grpbxBounds.TabStop = false;
            // 
            // btnClearBounds
            // 
            this.btnClearBounds.Location = new System.Drawing.Point(19, 158);
            this.btnClearBounds.Name = "btnClearBounds";
            this.btnClearBounds.Size = new System.Drawing.Size(90, 23);
            this.btnClearBounds.TabIndex = 8;
            this.btnClearBounds.Text = "Clear Bounds";
            this.btnClearBounds.UseVisualStyleBackColor = true;
            this.btnClearBounds.Click += new System.EventHandler(this.btnClearBounds_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(87, 19);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 368);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(87, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrev.Location = new System.Drawing.Point(6, 19);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // grpbxDatasetNav
            // 
            this.grpbxDatasetNav.Controls.Add(this.btnPrev);
            this.grpbxDatasetNav.Controls.Add(this.btnNext);
            this.grpbxDatasetNav.Location = new System.Drawing.Point(415, 9);
            this.grpbxDatasetNav.Name = "grpbxDatasetNav";
            this.grpbxDatasetNav.Size = new System.Drawing.Size(175, 55);
            this.grpbxDatasetNav.TabIndex = 15;
            this.grpbxDatasetNav.TabStop = false;
            this.grpbxDatasetNav.Text = "Dataset Navigation";
            // 
            // grpbxSaveLoad
            // 
            this.grpbxSaveLoad.Controls.Add(this.btnSave);
            this.grpbxSaveLoad.Controls.Add(this.btnLoad);
            this.grpbxSaveLoad.Location = new System.Drawing.Point(3, 12);
            this.grpbxSaveLoad.Name = "grpbxSaveLoad";
            this.grpbxSaveLoad.Size = new System.Drawing.Size(176, 52);
            this.grpbxSaveLoad.TabIndex = 16;
            this.grpbxSaveLoad.TabStop = false;
            this.grpbxSaveLoad.Text = "File";
            // 
            // txtbxAverage
            // 
            this.txtbxAverage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbxAverage.Location = new System.Drawing.Point(717, 236);
            this.txtbxAverage.Name = "txtbxAverage";
            this.txtbxAverage.ReadOnly = true;
            this.txtbxAverage.Size = new System.Drawing.Size(99, 20);
            this.txtbxAverage.TabIndex = 17;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(664, 239);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(47, 13);
            this.lblAverage.TabIndex = 18;
            this.lblAverage.Text = "Average";
            // 
            // grpbxLegend
            // 
            this.grpbxLegend.Controls.Add(this.lblRed);
            this.grpbxLegend.Controls.Add(this.lblGreen);
            this.grpbxLegend.Controls.Add(this.lblBlue);
            this.grpbxLegend.Controls.Add(this.pctbxRed);
            this.grpbxLegend.Controls.Add(this.pctbxGreen);
            this.grpbxLegend.Controls.Add(this.pctbxBlue);
            this.grpbxLegend.Location = new System.Drawing.Point(624, 271);
            this.grpbxLegend.Name = "grpbxLegend";
            this.grpbxLegend.Size = new System.Drawing.Size(225, 167);
            this.grpbxLegend.TabIndex = 19;
            this.grpbxLegend.TabStop = false;
            this.grpbxLegend.Text = "Legend";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(69, 122);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(96, 13);
            this.lblRed.TabIndex = 5;
            this.lblRed.Text = "Above Set Bounds";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(69, 81);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(95, 13);
            this.lblGreen.TabIndex = 4;
            this.lblGreen.Text = "Within Set Bounds";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(69, 40);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(94, 13);
            this.lblBlue.TabIndex = 3;
            this.lblBlue.Text = "Below Set Bounds";
            // 
            // pctbxRed
            // 
            this.pctbxRed.BackColor = System.Drawing.Color.DarkSalmon;
            this.pctbxRed.Location = new System.Drawing.Point(17, 111);
            this.pctbxRed.Name = "pctbxRed";
            this.pctbxRed.Size = new System.Drawing.Size(46, 34);
            this.pctbxRed.TabIndex = 2;
            this.pctbxRed.TabStop = false;
            // 
            // pctbxGreen
            // 
            this.pctbxGreen.BackColor = System.Drawing.Color.PaleGreen;
            this.pctbxGreen.Location = new System.Drawing.Point(17, 71);
            this.pctbxGreen.Name = "pctbxGreen";
            this.pctbxGreen.Size = new System.Drawing.Size(46, 34);
            this.pctbxGreen.TabIndex = 1;
            this.pctbxGreen.TabStop = false;
            // 
            // pctbxBlue
            // 
            this.pctbxBlue.BackColor = System.Drawing.Color.SkyBlue;
            this.pctbxBlue.Location = new System.Drawing.Point(17, 31);
            this.pctbxBlue.Name = "pctbxBlue";
            this.pctbxBlue.Size = new System.Drawing.Size(46, 34);
            this.pctbxBlue.TabIndex = 0;
            this.pctbxBlue.TabStop = false;
            // 
            // txtbxTitle
            // 
            this.txtbxTitle.Location = new System.Drawing.Point(6, 19);
            this.txtbxTitle.Name = "txtbxTitle";
            this.txtbxTitle.ReadOnly = true;
            this.txtbxTitle.Size = new System.Drawing.Size(212, 20);
            this.txtbxTitle.TabIndex = 20;
            // 
            // grpbxTitle
            // 
            this.grpbxTitle.Controls.Add(this.txtbxTitle);
            this.grpbxTitle.Location = new System.Drawing.Point(185, 12);
            this.grpbxTitle.Name = "grpbxTitle";
            this.grpbxTitle.Size = new System.Drawing.Size(224, 52);
            this.grpbxTitle.TabIndex = 21;
            this.grpbxTitle.TabStop = false;
            this.grpbxTitle.Text = "Current Dataset";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.grpbxTitle);
            this.Controls.Add(this.grpbxLegend);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.txtbxAverage);
            this.Controls.Add(this.grpbxSaveLoad);
            this.Controls.Add(this.grpbxDatasetNav);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpbxBounds);
            this.Controls.Add(this.grpbxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SensorShare";
            this.grpbxSearch.ResumeLayout(false);
            this.grpbxSearch.PerformLayout();
            this.grpbxBounds.ResumeLayout(false);
            this.grpbxBounds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpbxDatasetNav.ResumeLayout(false);
            this.grpbxSaveLoad.ResumeLayout(false);
            this.grpbxLegend.ResumeLayout(false);
            this.grpbxLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxBlue)).EndInit();
            this.grpbxTitle.ResumeLayout(false);
            this.grpbxTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbxUpperBound;
        private System.Windows.Forms.TextBox txtbxLowerBound;
        private System.Windows.Forms.TextBox txtbxSearchTerm;
        private System.Windows.Forms.Button btnSetBounds;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblUpperBound;
        private System.Windows.Forms.Label lblLowerBound;
        private System.Windows.Forms.GroupBox grpbxSearch;
        private System.Windows.Forms.GroupBox grpbxBounds;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.GroupBox grpbxDatasetNav;
        private System.Windows.Forms.GroupBox grpbxSaveLoad;
        private System.Windows.Forms.TextBox txtbxAverage;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.GroupBox grpbxLegend;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.PictureBox pctbxRed;
        private System.Windows.Forms.PictureBox pctbxGreen;
        private System.Windows.Forms.PictureBox pctbxBlue;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.TextBox txtbxTitle;
        private System.Windows.Forms.GroupBox grpbxTitle;
        private System.Windows.Forms.Button btnClearBounds;
    }
}

