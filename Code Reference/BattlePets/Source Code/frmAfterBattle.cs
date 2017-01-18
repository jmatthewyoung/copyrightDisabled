using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldTeamRules
{
    public partial class frmAfterBattle : Form
    {
        public frmAfterBattle()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAfterBattle_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            for(int i = 0; i < frmMain.afterBattleMessages.Count; i++)
            {
                string[] s = frmMain.afterBattleMessages[i].Split('|');
                for (int j = 0; j < s.Length; j++)
                {
                    lblMessage.Text += s[j] + "\n";
                }
            }
        }
    }
}
