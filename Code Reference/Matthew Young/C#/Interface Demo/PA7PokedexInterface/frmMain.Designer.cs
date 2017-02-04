namespace PA7_Young_John
{
    partial class frmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.udClones = new System.Windows.Forms.NumericUpDown();
            this.btnClone = new System.Windows.Forms.Button();
            this.dgvPokedex = new System.Windows.Forms.DataGridView();
            this.dgvPokemon = new System.Windows.Forms.DataGridView();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udClones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokedex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(515, 342);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // udClones
            // 
            this.udClones.Enabled = false;
            this.udClones.Location = new System.Drawing.Point(13, 112);
            this.udClones.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udClones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udClones.Name = "udClones";
            this.udClones.Size = new System.Drawing.Size(86, 22);
            this.udClones.TabIndex = 4;
            this.udClones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnClone
            // 
            this.btnClone.Enabled = false;
            this.btnClone.Location = new System.Drawing.Point(105, 112);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 5;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // dgvPokedex
            // 
            this.dgvPokedex.AllowUserToAddRows = false;
            this.dgvPokedex.AllowUserToDeleteRows = false;
            this.dgvPokedex.AllowUserToResizeRows = false;
            this.dgvPokedex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPokedex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPokedex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokedex.Location = new System.Drawing.Point(12, 141);
            this.dgvPokedex.MultiSelect = false;
            this.dgvPokedex.Name = "dgvPokedex";
            this.dgvPokedex.RowHeadersVisible = false;
            this.dgvPokedex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokedex.Size = new System.Drawing.Size(578, 195);
            this.dgvPokedex.TabIndex = 6;
            // 
            // dgvPokemon
            // 
            this.dgvPokemon.AllowUserToAddRows = false;
            this.dgvPokemon.AllowUserToDeleteRows = false;
            this.dgvPokemon.AllowUserToResizeRows = false;
            this.dgvPokemon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPokemon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPokemon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemon.Location = new System.Drawing.Point(13, 12);
            this.dgvPokemon.MultiSelect = false;
            this.dgvPokemon.Name = "dgvPokemon";
            this.dgvPokemon.ReadOnly = true;
            this.dgvPokemon.RowHeadersVisible = false;
            this.dgvPokemon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemon.Size = new System.Drawing.Size(577, 94);
            this.dgvPokemon.TabIndex = 7;
            this.dgvPokemon.SelectionChanged += new System.EventHandler(this.dgvPokemon_SelectionChanged);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(434, 342);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 377);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgvPokemon);
            this.Controls.Add(this.dgvPokedex);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.udClones);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample Interface";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udClones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokedex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown udClones;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.DataGridView dgvPokedex;
        private System.Windows.Forms.DataGridView dgvPokemon;
        private System.Windows.Forms.Button btnReport;
    }
}

