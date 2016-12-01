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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain.username = tbtUsername.Text;
            frmMain.password = tbtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            frmCreate frm = new frmCreate();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Tag = frm.Tag;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            SortedList<string, Image> images = new SortedList<string, Image>(10);

            //Themed Text Images
            images["username"] = Image.FromFile(@"Resources\Backgrounds\Text\username.png");
            images["password"] = Image.FromFile(@"Resources\Backgrounds\Text\password.png");
            images["logo"] = Image.FromFile(@"Resources\Backgrounds\Text\logo.png");

            //Menu Backgrounds
            images["menubg"] = Image.FromFile(@"Resources\Backgrounds\Menu\menubackground.png");

            BackgroundImage = images["menubg"];
            title.BackgroundImage = images["logo"];
            username.BackgroundImage = images["username"];
            password.BackgroundImage = images["password"];
        }
    }
}
