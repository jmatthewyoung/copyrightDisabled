using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JamieTheRobot2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Robot robot;
        private int counter;

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            pbLightbulb.Image = imgLightBulb.Images[1];

            robot = new Robot();
            robot.Crash += new EventHandler(CrashHandler);
            lblPosition.Text = robot.Position.ToString();
            lblRobot.Text = Convert.ToChar(233).ToString();
            listBox.Items.Add("RobotDirection.N");
            timer.Interval = 1500;
        }

        private void UpdateListBox()
        {
            if (listBox.Items.Count > 0 && !(listBox.Items[listBox.Items.Count-1].Equals("RobotDirection." + robot.Direction.ToString())))
            {
                listBox.Items.Add("RobotDirection." + robot.Direction.ToString());
            }
        }

        private void btnN_Click(object sender, System.EventArgs e)
        {
            robot.Direction = RobotDirection.N;
            lblRobot.Text = Convert.ToChar(233).ToString();  // Up arrow
            UpdateListBox();
        }

        private void btnS_Click(object sender, System.EventArgs e)
        {
            robot.Direction = RobotDirection.S;
            lblRobot.Text = Convert.ToChar(234).ToString();  // Down arrow
            UpdateListBox();
        }

        private void btnW_Click(object sender, System.EventArgs e)
        {
            robot.Direction = RobotDirection.W;
            lblRobot.Text = Convert.ToChar(231).ToString();  // Left arrow
            UpdateListBox();
        }

        private void btnE_Click(object sender, System.EventArgs e)
        {
            robot.Direction = RobotDirection.E;
            lblRobot.Text = Convert.ToChar(232).ToString();  // Right arrow
            UpdateListBox();
        }

        private void btnGo1_Click(object sender, System.EventArgs e)
        {
            this.MoveRobot(1);
        }

        private void btnGo10_Click(object sender, System.EventArgs e)
        {
            this.MoveRobot(10);
        }

        private void MoveRobot(int units)
        {
            robot.Go(units);
            Point rp = robot.Position;
            lblRobot.Location = new Point(rp.X + 100, -rp.Y + 100);
            lblPosition.Text = rp.ToString();
            listBox.Items.Add("MoveRobot(" + units + ")");
        }

        private void CrashHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Crash!");
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pbLightbulb.Image = imgLightBulb.Images[0];
            counter = 0;
            progressBar.Maximum = listBox.Items.Count;
            progressBar.Value = 0;
            robot = new Robot();
            lblRobot.Location = new Point(100, 100);
            lblPosition.Text = robot.Position.ToString();
            gbMovement.Enabled = false;
            timer.Enabled = true;
            btnPlay.Visible = false;
            btnDataFill.Enabled = false;
            btnClear.Enabled = false;
            btnReset.Enabled = false;
            btnStop.Visible = true;
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            if (tbSpeed.Value != 0)
            {
                timer.Interval = (1500 / tbSpeed.Value);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            robot = new Robot();
            lblRobot.Location = new Point(100, 100);
            lblPosition.Text = robot.Position.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            listBox.Items.Add("RobotDirection." + robot.Direction.ToString());
        }

        private void DoWork(int counter)
        {
            string currentInstruction = listBox.Items[counter].ToString();

            if (currentInstruction.Equals("RobotDirection.N"))
            {
                robot.Direction = RobotDirection.N;
                lblRobot.Text = Convert.ToChar(233).ToString();
            }

            else if (currentInstruction.Equals("RobotDirection.E"))
            {
                robot.Direction = RobotDirection.E;
                lblRobot.Text = Convert.ToChar(232).ToString();
            }
            else if (currentInstruction.Equals("RobotDirection.S"))
            {
                robot.Direction = RobotDirection.S;
                lblRobot.Text = Convert.ToChar(234).ToString();
            }
            else if (currentInstruction.Equals("RobotDirection.W"))
            {
                robot.Direction = RobotDirection.W;
                lblRobot.Text = Convert.ToChar(231).ToString();
            }
            else if (currentInstruction.Equals("MoveRobot(10)"))
            {
                robot.Go(10);
                Point p = robot.Position;
                lblRobot.Location = new Point(p.X + 100, -p.Y + 100);
                lblPosition.Text = p.ToString();
            }
            else if (currentInstruction.Equals("MoveRobot(1)"))
            {
                robot.Go(1);
                Point p = robot.Position;
                lblRobot.Location = new Point(p.X + 100, -p.Y + 100);
                lblPosition.Text = p.ToString();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (counter != listBox.Items.Count)
            {
                listBox.SetSelected(counter, true);
                progressBar.Value = counter + 1;
                DoWork(counter);          
                counter++;
            }
            else if (cbLoop.Checked)
            {
                counter = 0;
                progressBar.Value = counter;
                robot = new Robot();
                lblRobot.Location = new Point(100, 100);
                lblPosition.Text = robot.Position.ToString();
                progressBar.Value = 0;
            }
            else
            {
                listBox.SetSelected(counter - 1, false);
                progressBar.Value = counter;
                timer.Enabled = false;
                gbMovement.Enabled = true;
                btnStop.Visible = false;
                btnDataFill.Enabled = true;
                btnClear.Enabled = true;
                btnReset.Enabled = true;
                btnPlay.Visible = true;
                robot = new Robot();
                lblRobot.Location = new Point(100, 100);
                lblPosition.Text = robot.Position.ToString();
                MessageBox.Show("Tracking complete.");
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pbLightbulb.Image = imgLightBulb.Images[1];
            gbMovement.Enabled = true;
            timer.Enabled = false;
            btnStop.Visible = false;
            btnDataFill.Enabled = true;
            btnClear.Enabled = true;
            btnReset.Enabled = true;
            btnPlay.Visible = true;
        }

        private void btnDataFill_Click(object sender, EventArgs e)
        {
            listBox.Items.Add("MoveRobot(10)");
            listBox.Items.Add("RobotDirection.E");
            listBox.Items.Add("MoveRobot(10)");
            listBox.Items.Add("RobotDirection.S");
            listBox.Items.Add("MoveRobot(10)");
            listBox.Items.Add("RobotDirection.W");
            listBox.Items.Add("MoveRobot(10)");
            listBox.Items.Add("RobotDirection.N");
        }
    }
}