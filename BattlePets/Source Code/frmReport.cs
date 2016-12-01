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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private DataTable dt;
        private List<string> list;

        private void frmReport_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font(new FontFamily("Lucida Sans"), 10, FontStyle.Regular);
            list = new List<string>(100);
            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;

            try
            {
                using (SqlConnection connection = new SqlConnection(_cnDB))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"Select distinct battleNum from combatLog where userID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", frmMain.userID);
                        SqlDataReader reader = command.ExecuteReader();
                        int numRows = 0;
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                list.Add(reader[0].ToString());
                                numRows++;
                            }
                        }
                        list.TrimExcess();
                        for (int i = 0; i < numRows; i++)
                        {
                            cb.Items.Add(list[i]);
                        }
                        if (numRows > 0)
                        {
                            cb.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("User ID");
            dt.Columns.Add("Round Number");
            dt.Columns.Add("Timestamp");
            dt.Columns.Add("User Pet Name");
            dt.Columns.Add("Ability");
            dt.Columns.Add("Result");
            dt.Columns.Add("Target Pet Name");

            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;

            try
            {
                using (SqlConnection connection = new SqlConnection(_cnDB))
                {
                    connection.Open();

                    using (SqlCommand comm = new SqlCommand(@"Select userID, roundNum, battleTime, userPetName, abilityUsed, result, targetPetName from combatLog where userID = @id AND battleNum = @num", connection))
                    {
                        comm.Parameters.AddWithValue("@id", frmMain.userID);
                        comm.Parameters.AddWithValue("@num", cb.SelectedItem);
                        SqlDataReader reader = comm.ExecuteReader();

                        string name1 = "", name2 = "";
                        int counter = 0;
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                if(counter == 0)
                                {
                                    DataRow dr1 = dt.NewRow();
                                    dr1["User ID"] = "----";
                                    dr1["Round Number"] = "START";
                                    dr1["Timestamp"] = "----";
                                    name1 = reader[3].ToString();
                                    dr1["User Pet Name"] = name1;
                                    dr1["Ability"] = "-- VS --";
                                    dr1["Result"] = "----";
                                    name2 = reader[6].ToString();
                                    dr1["Target Pet Name"] = name2;
                                    dt.Rows.Add(dr1);
                                }
                                DataRow dr = dt.NewRow();
                                dr["User ID"] = reader[0].ToString();
                                dr["Round Number"] = reader[1].ToString();
                                dr["Timestamp"] = reader[2].ToString();
                                dr["User Pet Name"] = reader[3].ToString();
                                dr["Ability"] = reader[4].ToString();
                                dr["Result"] = reader[5].ToString();
                                dr["Target Pet Name"] = reader[6].ToString();
                                if (!dr.IsNull("User ID"))
                                {
                                    dt.Rows.Add(dr);
                                }
                            }
                            counter++;
                        }
                        DataRow dr2 = dt.NewRow();
                        dr2["User ID"] = "----";
                        dr2["Round Number"] = "BATTLE OVER";
                        dr2["Timestamp"] = "----";
                        dr2["User Pet Name"] = name1;
                        dr2["Ability"] = "-- VS --";
                        dr2["Result"] = "----";
                        dr2["Target Pet Name"] = name2;
                        dt.Rows.Add(dr2);
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            dataGridView1.DataSource = dt;
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}