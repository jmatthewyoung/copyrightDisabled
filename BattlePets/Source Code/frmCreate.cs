using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldTeamRules
{
    public partial class frmCreate : Form
    {
        public frmCreate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int l1 = tbtUsername.Text.ToCharArray().Length;
            int l2 = tbtPassword.Text.ToCharArray().Length;
            int l3 = tbtFName.Text.ToCharArray().Length;
            int l4 = tbtLName.Text.ToCharArray().Length;

            if (l1 >= 4)
            {
                if (l2 >= 4)
                {
                    if (l3 >= 2)
                    {
                        if (l4 >= 2)
                        {
                            frmMain.username = tbtUsername.Text;
                            frmMain.password = tbtPassword.Text;
                            this.DialogResult = DialogResult.OK;
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(GoldTeamRules.Properties.Settings.Default.cnDb))
                                {
                                    connection.Open();
                                    SqlCommand cmd = new SqlCommand("Select username from logins where username = @username", connection);
                                    cmd.Parameters.AddWithValue("@username", frmMain.username);
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        throw new ArgumentOutOfRangeException();
                                    }
                                    reader.Close();
                                    SqlCommand command = new SqlCommand("dbo.usp_Add_New_Person", connection);
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@firstName", tbtFName.Text);
                                    command.Parameters.AddWithValue("@lastName", tbtLName.Text);
                                    command.ExecuteNonQuery();
                                    command = new SqlCommand("SELECT person_ID FROM dbo.Person where first_name = @firstName", connection);
                                    command.CommandType = CommandType.Text;
                                    command.Parameters.AddWithValue("@firstName", tbtFName.Text);
                                    int personID = 0;
                                    using (SqlDataReader datareader = command.ExecuteReader())
                                    {
                                        if (datareader.HasRows)
                                        {
                                            while (datareader.Read())
                                            {
                                                personID = Int32.Parse(datareader[0].ToString());
                                            }
                                        }
                                    }
                                    command = new SqlCommand("dbo.usp_Add_New_Login", connection);
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@username", tbtUsername.Text);
                                    command.Parameters.AddWithValue("@password", tbtPassword.Text);
                                    command.Parameters.AddWithValue("@personID", personID);
                                    command.ExecuteNonQuery();
                                    command = new SqlCommand("SELECT userID FROM dbo.Logins where personID = @personID", connection);
                                    command.CommandType = CommandType.Text;
                                    command.Parameters.AddWithValue("@personID", personID);
                                    using (SqlDataReader datareader = command.ExecuteReader())
                                    {
                                        if (datareader.HasRows)
                                        {
                                            while (datareader.Read())
                                            {
                                                frmMain.userID = Int32.Parse(datareader[0].ToString());
                                            }
                                        }
                                    }
                                    frmStart startFrm = new frmStart();
                                    startFrm.ShowDialog();
                                }
                            }
                            catch (ArgumentOutOfRangeException e1)
                            {
                                MessageBox.Show("That username is taken!");
                                this.DialogResult = DialogResult.Abort;
                                this.Close();
                            }
                            catch (Exception e2)
                            {
                                MessageBox.Show(e2.Message);
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Last name has to be at least 3 characters!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("First name has to be at least 3 characters!");
                    }
                }
                else
                {
                    MessageBox.Show("Password has to be at least 5 characters!");
                }
            }
            else
            {
                MessageBox.Show("Username has to be at least 5 characters!");
            }
        }

        private void frmCreate_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            SortedList<string, Image> images = new SortedList<string, Image>(10);

            //Themed Text Images
            images["username"] = Image.FromFile(@"Resources\Backgrounds\Text\username.png");
            images["password"] = Image.FromFile(@"Resources\Backgrounds\Text\password.png");
            images["firstname"] = Image.FromFile(@"Resources\Backgrounds\Text\firstname.png");
            images["lastname"] = Image.FromFile(@"Resources\Backgrounds\Text\lastname.png");
            images["logo"] = Image.FromFile(@"Resources\Backgrounds\Text\logo.png");

            //Menu Backgrounds
            images["createbg"] = Image.FromFile(@"Resources\Backgrounds\Menu\createbackground.png");

            BackgroundImage = images["createbg"];
            title.BackgroundImage = images["logo"];
            username.BackgroundImage = images["username"];
            password.BackgroundImage = images["password"];
            firstname.BackgroundImage = images["firstname"];
            lastname.BackgroundImage = images["lastname"];
        }
    }
}
