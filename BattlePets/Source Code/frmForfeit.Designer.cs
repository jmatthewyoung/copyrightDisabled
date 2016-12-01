namespace GoldTeamRules
{
    partial class frmForfeit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForfeit));
            this.label1 = new System.Windows.Forms.Label();
            this.btnForfeit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you\'d like to forfeit? \r\n(If you\'ve attacked the wild pet, it will f" +
    "lee, \r\nhowever if it is undamaged, it will remain)\r\n";
            // 
            // btnForfeit
            // 
            this.btnForfeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnForfeit.Location = new System.Drawing.Point(18, 103);
            this.btnForfeit.Name = "btnForfeit";
            this.btnForfeit.Size = new System.Drawing.Size(225, 66);
            this.btnForfeit.TabIndex = 1;
            this.btnForfeit.Text = "Forfeit";
            this.btnForfeit.UseVisualStyleBackColor = true;
            this.btnForfeit.Click += new System.EventHandler(this.btnForfeit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(249, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(219, 66);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmForfeit
            // 
            this.AcceptButton = this.btnForfeit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(489, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnForfeit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmForfeit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forfeit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnForfeit;
        private System.Windows.Forms.Button btnCancel;
    }
}