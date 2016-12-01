namespace GoldTeamRules
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
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.petMover = new System.Windows.Forms.Timer(this.components);
            this.battleLoop = new System.Windows.Forms.Timer(this.components);
            this.collisionChecker = new System.Windows.Forms.Timer(this.components);
            this.invincibilitySeconds = new System.Windows.Forms.Timer(this.components);
            this.invincibilityBlinker = new System.Windows.Forms.Timer(this.components);
            this.pushBack = new System.Windows.Forms.Timer(this.components);
            this.damageDisplayer = new System.Windows.Forms.Timer(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.mapScreen = new System.Windows.Forms.TabPage();
            this.btnPause = new System.Windows.Forms.Button();
            this.menuScreen = new System.Windows.Forms.TabPage();
            this.battleScreen = new System.Windows.Forms.TabPage();
            this.tutorialScreen = new System.Windows.Forms.TabPage();
            healTimer = new System.Windows.Forms.Timer(this.components);
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.tc.SuspendLayout();
            this.mapScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Interval = 1;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // petMover
            // 
            this.petMover.Interval = 200;
            this.petMover.Tick += new System.EventHandler(this.petMover_Tick);
            // 
            // battleLoop
            // 
            this.battleLoop.Tick += new System.EventHandler(this.battleLoop_Tick);
            // 
            // collisionChecker
            // 
            this.collisionChecker.Interval = 1;
            this.collisionChecker.Tick += new System.EventHandler(this.collisionChecker_Tick);
            // 
            // invincibilitySeconds
            // 
            this.invincibilitySeconds.Interval = 1000;
            this.invincibilitySeconds.Tick += new System.EventHandler(this.invincibilitySeconds_Tick);
            // 
            // invincibilityBlinker
            // 
            this.invincibilityBlinker.Interval = 50;
            this.invincibilityBlinker.Tick += new System.EventHandler(this.invincibilityBlinker_Tick);
            // 
            // pushBack
            // 
            this.pushBack.Interval = 150;
            this.pushBack.Tick += new System.EventHandler(this.pushBack_Tick);
            // 
            // damageDisplayer
            // 
            this.damageDisplayer.Interval = 1;
            this.damageDisplayer.Tick += new System.EventHandler(this.damageDisplayer_Tick);
            // 
            // tc
            // 
            this.tc.Controls.Add(this.mapScreen);
            this.tc.Controls.Add(this.menuScreen);
            this.tc.Controls.Add(this.battleScreen);
            this.tc.Controls.Add(this.tutorialScreen);
            this.tc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc.Location = new System.Drawing.Point(0, 0);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(800, 600);
            this.tc.TabIndex = 0;
            this.tc.TabStop = false;
            this.tc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tc_KeyDown);
            this.tc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tc_KeyUp);
            // 
            // mapScreen
            // 
            this.mapScreen.Controls.Add(this.btnPause);
            this.mapScreen.Location = new System.Drawing.Point(4, 22);
            this.mapScreen.Name = "mapScreen";
            this.mapScreen.Padding = new System.Windows.Forms.Padding(3);
            this.mapScreen.Size = new System.Drawing.Size(792, 574);
            this.mapScreen.TabIndex = 0;
            this.mapScreen.Text = "mapScreen";
            this.mapScreen.UseVisualStyleBackColor = true;
            this.mapScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.mapScreen_Paint_1);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(0, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(47, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuScreen
            // 
            this.menuScreen.Location = new System.Drawing.Point(4, 22);
            this.menuScreen.Name = "menuScreen";
            this.menuScreen.Padding = new System.Windows.Forms.Padding(3);
            this.menuScreen.Size = new System.Drawing.Size(792, 574);
            this.menuScreen.TabIndex = 1;
            this.menuScreen.Text = "menuScreen";
            this.menuScreen.UseVisualStyleBackColor = true;
            this.menuScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.menuScreen_Paint_1);
            // 
            // battleScreen
            // 
            this.battleScreen.Location = new System.Drawing.Point(4, 22);
            this.battleScreen.Name = "battleScreen";
            this.battleScreen.Size = new System.Drawing.Size(792, 574);
            this.battleScreen.TabIndex = 2;
            this.battleScreen.Text = "battleScreen";
            this.battleScreen.UseVisualStyleBackColor = true;
            this.battleScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.battleScreen_Paint_1);
            // 
            // tutorialScreen
            // 
            this.tutorialScreen.Location = new System.Drawing.Point(4, 22);
            this.tutorialScreen.Name = "tutorialScreen";
            this.tutorialScreen.Size = new System.Drawing.Size(792, 574);
            this.tutorialScreen.TabIndex = 3;
            this.tutorialScreen.Text = "tutorialScreen";
            this.tutorialScreen.UseVisualStyleBackColor = true;
            this.tutorialScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.tutorialScreen_Paint);
            // 
            // healTimer
            // 
            healTimer.Interval = 300000;
            healTimer.Tick += new System.EventHandler(healTimer_Tick);
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gold Team Rules";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tc.ResumeLayout(false);
            this.mapScreen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Timer petMover;
        private System.Windows.Forms.Timer battleLoop;
        private System.Windows.Forms.Timer collisionChecker;
        private System.Windows.Forms.Timer invincibilitySeconds;
        private System.Windows.Forms.Timer invincibilityBlinker;
        private System.Windows.Forms.Timer pushBack;
        private System.Windows.Forms.Timer damageDisplayer;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage mapScreen;
        private System.Windows.Forms.TabPage menuScreen;
        private System.Windows.Forms.TabPage battleScreen;
        private System.Windows.Forms.TabPage tutorialScreen;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Button btnPause;
        public static System.Windows.Forms.Timer healTimer;
    }
}

