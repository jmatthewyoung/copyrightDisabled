namespace JamieTheRobot2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGo10 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lblRobot = new System.Windows.Forms.Label();
            this.btnGo1 = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnN = new System.Windows.Forms.Button();
            this.btnDataFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.gbxReplay = new System.Windows.Forms.GroupBox();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.pbLightbulb = new System.Windows.Forms.PictureBox();
            this.imgLightBulb = new System.Windows.Forms.ImageList(this.components);
            this.gbMovement = new System.Windows.Forms.GroupBox();
            this.panel.SuspendLayout();
            this.gbxReplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLightbulb)).BeginInit();
            this.gbMovement.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(465, 381);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 24);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGo10
            // 
            this.btnGo10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo10.Location = new System.Drawing.Point(198, 33);
            this.btnGo10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGo10.Name = "btnGo10";
            this.btnGo10.Size = new System.Drawing.Size(56, 23);
            this.btnGo10.TabIndex = 16;
            this.btnGo10.Text = "Go 10";
            this.btnGo10.Click += new System.EventHandler(this.btnGo10_Click);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.lblRobot);
            this.panel.Location = new System.Drawing.Point(14, 43);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(259, 206);
            this.panel.TabIndex = 15;
            // 
            // lblRobot
            // 
            this.lblRobot.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRobot.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblRobot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRobot.Location = new System.Drawing.Point(100, 100);
            this.lblRobot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRobot.Name = "lblRobot";
            this.lblRobot.Size = new System.Drawing.Size(12, 12);
            this.lblRobot.TabIndex = 0;
            this.lblRobot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGo1
            // 
            this.btnGo1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo1.Location = new System.Drawing.Point(7, 33);
            this.btnGo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGo1.Name = "btnGo1";
            this.btnGo1.Size = new System.Drawing.Size(48, 23);
            this.btnGo1.TabIndex = 14;
            this.btnGo1.Text = "Go 1";
            this.btnGo1.Click += new System.EventHandler(this.btnGo1_Click);
            // 
            // btnE
            // 
            this.btnE.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.Location = new System.Drawing.Point(150, 33);
            this.btnE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(24, 23);
            this.btnE.TabIndex = 13;
            this.btnE.Text = "E";
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // btnW
            // 
            this.btnW.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnW.Location = new System.Drawing.Point(90, 33);
            this.btnW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(24, 23);
            this.btnW.TabIndex = 12;
            this.btnW.Text = "W";
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnS
            // 
            this.btnS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(118, 54);
            this.btnS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(24, 23);
            this.btnS.TabIndex = 11;
            this.btnS.Text = "S";
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnN
            // 
            this.btnN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN.Location = new System.Drawing.Point(118, 14);
            this.btnN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(24, 23);
            this.btnN.TabIndex = 10;
            this.btnN.Text = "N";
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnDataFill
            // 
            this.btnDataFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataFill.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDataFill.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFill.Location = new System.Drawing.Point(177, 381);
            this.btnDataFill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDataFill.Name = "btnDataFill";
            this.btnDataFill.Size = new System.Drawing.Size(64, 24);
            this.btnDataFill.TabIndex = 19;
            this.btnDataFill.Text = "DataFill";
            this.btnDataFill.Click += new System.EventHandler(this.btnDataFill_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(249, 381);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 24);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(321, 381);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 24);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPlay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(393, 381);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(64, 24);
            this.btnPlay.TabIndex = 22;
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(26, 17);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(59, 13);
            this.lblPosition.TabIndex = 23;
            this.lblPosition.Text = "{X=0, Y=0}";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(284, 17);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 24;
            this.lblProgress.Text = "Progress";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(280, 43);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(249, 264);
            this.listBox.TabIndex = 25;
            // 
            // gbxReplay
            // 
            this.gbxReplay.Controls.Add(this.cbLoop);
            this.gbxReplay.Controls.Add(this.lblSpeed);
            this.gbxReplay.Controls.Add(this.tbSpeed);
            this.gbxReplay.Location = new System.Drawing.Point(280, 314);
            this.gbxReplay.Name = "gbxReplay";
            this.gbxReplay.Size = new System.Drawing.Size(250, 61);
            this.gbxReplay.TabIndex = 26;
            this.gbxReplay.TabStop = false;
            this.gbxReplay.Text = "Replay";
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(185, 15);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(50, 17);
            this.cbLoop.TabIndex = 2;
            this.cbLoop.Text = "Loop";
            this.cbLoop.UseVisualStyleBackColor = true;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(18, 16);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "Speed";
            // 
            // tbSpeed
            // 
            this.tbSpeed.LargeChange = 2;
            this.tbSpeed.Location = new System.Drawing.Point(62, 13);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.tbSpeed.Maximum = 4;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(104, 45);
            this.tbSpeed.TabIndex = 0;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(342, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(187, 23);
            this.progressBar.TabIndex = 27;
            // 
            // timer
            // 
            this.timer.Interval = 300;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(392, 382);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 23);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbLightbulb
            // 
            this.pbLightbulb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLightbulb.Location = new System.Drawing.Point(241, 5);
            this.pbLightbulb.Name = "pbLightbulb";
            this.pbLightbulb.Size = new System.Drawing.Size(32, 32);
            this.pbLightbulb.TabIndex = 29;
            this.pbLightbulb.TabStop = false;
            // 
            // imgLightBulb
            // 
            this.imgLightBulb.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLightBulb.ImageStream")));
            this.imgLightBulb.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLightBulb.Images.SetKeyName(0, "lightbulb.png");
            this.imgLightBulb.Images.SetKeyName(1, "lightbulb_off.png");
            // 
            // gbMovement
            // 
            this.gbMovement.Controls.Add(this.btnGo1);
            this.gbMovement.Controls.Add(this.btnN);
            this.gbMovement.Controls.Add(this.btnW);
            this.gbMovement.Controls.Add(this.btnE);
            this.gbMovement.Controls.Add(this.btnS);
            this.gbMovement.Controls.Add(this.btnGo10);
            this.gbMovement.Location = new System.Drawing.Point(14, 251);
            this.gbMovement.Name = "gbMovement";
            this.gbMovement.Size = new System.Drawing.Size(259, 92);
            this.gbMovement.TabIndex = 30;
            this.gbMovement.TabStop = false;
            this.gbMovement.Text = "Movement";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(542, 417);
            this.Controls.Add(this.gbxReplay);
            this.Controls.Add(this.pbLightbulb);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDataFill);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.gbMovement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jamie The Robot";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel.ResumeLayout(false);
            this.gbxReplay.ResumeLayout(false);
            this.gbxReplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLightbulb)).EndInit();
            this.gbMovement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGo10;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblRobot;
        private System.Windows.Forms.Button btnGo1;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnN;
        private System.Windows.Forms.Button btnDataFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.GroupBox gbxReplay;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbLightbulb;
        private System.Windows.Forms.ImageList imgLightBulb;
        private System.Windows.Forms.GroupBox gbMovement;
    }
}

