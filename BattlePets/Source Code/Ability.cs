using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeamRules
{
    class Ability
    {
        private string name;
        private int damage;
        private double accuracy;

        public Ability(int id, int num, bool a)
        {
            if (a)
            {
                GetAbility(id, num);
            }
            else
            {
                GetNewAbility(id, num);
            }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        private void GetAbility(int id, int num)
        {
            string conn = GoldTeamRules.Properties.Settings.Default.cnDb;
            int abilityID = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("dbo.usp_Load_Ability_ID", connection);
                command.Parameters.Clear();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@petID", id);
                command.Parameters.AddWithValue("@abilityNum", num);
                command.Parameters.AddWithValue("@userID", frmMain.userID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            abilityID = Int32.Parse(reader[0].ToString());
                        }
                    }
                }
                command = new SqlCommand("dbo.usp_Load_Ability", connection);
                command.Parameters.Clear();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AbilityID", abilityID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader[0].ToString();
                            damage = Int32.Parse(reader[1].ToString());
                            accuracy = Int32.Parse(reader[2].ToString());
                        }
                    }
                }  
            }
        }

        private void GetNewAbility(int id, int num)
        {
            string conn = GoldTeamRules.Properties.Settings.Default.cnDb;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("dbo.usp_Load_Wild_Ability", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@petID", id);
                command.Parameters.AddWithValue("@abilityNum", num);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader[0].ToString();
                            damage = Int32.Parse(reader[1].ToString());
                            accuracy = Int32.Parse(reader[2].ToString());
                        }
                    }
                }             
            }
        }

        public string Name
        {
            get { return name; }
        }
    }
}