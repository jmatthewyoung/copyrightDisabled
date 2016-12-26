using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace GoldTeamRules
{
    class Pet : GameObject
    {
        private int petID;
        private string name;
        private string type;
        private string rarity;
        private int baseHP;
        private int hpScale;
        private int baseSpeed;
        private int speedScale;
        private int baseAtk;
        private int atkScale;
        private int currentXP;
        public Ability[] abilities;
        private int currentHP;
        private Ability selectedAbility;
        public static int seed;
        private int rosterSlot;
        private int favorite;

        public enum RarityLevel
        {
            Poor,
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }

        public Pet()
        {
            this.petID = 0;
            this.name = "Magical Crawdad";
            this.type = "Aquatic";
            this.rarity = "Rare";
            this.baseHP = 999;
            this.hpScale = 10;
            this.baseSpeed = 999;
            this.speedScale = 10;
            this.baseAtk = 999;
            this.atkScale = 10;
            this.DisplayImage = frmMain.petImages[this.name];
            currentHP = HP;
            currentXP = 10000;
            FillAbilities();
        }

        //Create Wild Pet
        public Pet(int petID)
        {
            if (!frmMain.testModeActive)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(GoldTeamRules.Properties.Settings.Default.cnDb))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("dbo.usp_Load_Pet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@petID", petID);
                        command.Parameters.AddWithValue("@numRows", new Int32());
                        using (SqlDataReader datareader = command.ExecuteReader())
                        {
                            if (datareader.HasRows)
                            {
                                while (datareader.Read())
                                {
                                    this.petID = petID;
                                    this.name = datareader[0].ToString();
                                    this.type = datareader[1].ToString();
                                    this.rarity = GetRarity(Int32.Parse(datareader[2].ToString()));
                                    this.baseHP = Int32.Parse(datareader[3].ToString());
                                    this.hpScale = Int32.Parse(datareader[4].ToString());
                                    this.baseSpeed = Int32.Parse(datareader[5].ToString());
                                    this.speedScale = Int32.Parse(datareader[6].ToString());
                                    this.baseAtk = Int32.Parse(datareader[7].ToString());
                                    this.atkScale = Int32.Parse(datareader[8].ToString());
                                    this.DisplayImage = frmMain.petImages[this.name];
                                }
                            }
                        }
                    }
                    Random r = new Random(seed * this.petID);
                    int top = 0;
                    int bottom = 0;
                    for (int i = 0; i < frmMain.activeList.Count; i++)
                    {
                        top += frmMain.activeList[i].currentXP;
                    }
                    top /= 3;
                    top += 10000;
                    bottom = top;
                    bottom -= 20000;
                    if (bottom < 500)
                    {
                        bottom = 501;
                    }
                    currentXP = r.Next(bottom, top);
                    currentHP = HP;
                    rosterSlot = -1;
                    FillNewAbilities();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                this.petID = 0;
                this.name = "Magical Crawdad";
                this.type = "Aquatic";
                this.rarity = "Rare";
                this.baseHP = 999;
                this.hpScale = 10;
                this.baseSpeed = 999;
                this.speedScale = 10;
                this.baseAtk = 999;
                this.atkScale = 10;
                this.DisplayImage = frmMain.petImages[this.name];
            }
        }

        //Load Pet
        public Pet(int petID, int currentXP, int currentHP, int? rosterSlot, int favorite)
        {
            if (!frmMain.testModeActive)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(GoldTeamRules.Properties.Settings.Default.cnDb))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("dbo.usp_Load_Pet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@petID", petID);
                        command.Parameters.AddWithValue("@numRows", new Int32());
                        using (SqlDataReader datareader = command.ExecuteReader())
                        {
                            if (datareader.HasRows)
                            {
                                while (datareader.Read())
                                {
                                    this.petID = petID;
                                    this.name = datareader[0].ToString();
                                    this.type = datareader[1].ToString();
                                    this.rarity = GetRarity(Int32.Parse(datareader[2].ToString()));
                                    this.baseHP = Int32.Parse(datareader[3].ToString());
                                    this.hpScale = Int32.Parse(datareader[4].ToString());
                                    this.baseSpeed = Int32.Parse(datareader[5].ToString());
                                    this.speedScale = Int32.Parse(datareader[6].ToString());
                                    this.baseAtk = Int32.Parse(datareader[7].ToString());
                                    this.atkScale = Int32.Parse(datareader[8].ToString());
                                    this.DisplayImage = frmMain.petImages[this.name];
                                }
                            }
                        }
                    }
                    this.currentHP = currentHP;
                    this.currentXP = currentXP;
                    if (rosterSlot != null)
                    {
                        this.rosterSlot = (int)rosterSlot;
                    }
                    this.favorite = favorite;
                    FillAbilities();
                }

                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                this.petID = 0;
                this.name = "MAGICAL CRAWDAD";
                this.type = "Aquatic";
                this.rarity = "Rare";
                this.baseHP = 999;
                this.hpScale = 10;
                this.baseSpeed = 999;
                this.speedScale = 10;
                this.baseAtk = 999;
                this.atkScale = 10;
                this.DisplayImage = frmMain.petImages[this.name];
            }
}

        //Starting Pet
        public Pet(int petID, int currentXP, int rosterSlot, bool a)
        {
            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;
            if (!frmMain.testModeActive)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_cnDB))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("dbo.usp_Load_Pet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@petID", petID);
                        command.Parameters.AddWithValue("@numRows", new Int32());
                        using (SqlDataReader datareader = command.ExecuteReader())
                        {
                            if (datareader.HasRows)
                            {
                                while (datareader.Read())
                                {
                                    this.petID = petID;
                                    this.name = datareader[0].ToString();
                                    this.type = datareader[1].ToString();
                                    this.rarity = GetRarity(Int32.Parse(datareader[2].ToString()));
                                    this.baseHP = Int32.Parse(datareader[3].ToString());
                                    this.hpScale = Int32.Parse(datareader[4].ToString());
                                    this.baseSpeed = Int32.Parse(datareader[5].ToString());
                                    this.speedScale = Int32.Parse(datareader[6].ToString());
                                    this.baseAtk = Int32.Parse(datareader[7].ToString());
                                    this.atkScale = Int32.Parse(datareader[8].ToString());
                                    this.DisplayImage = frmMain.petImages[this.name];
                                }
                            }
                        }

                        command = new SqlCommand("dbo.usp_add_New_CapturedPet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", frmMain.userID);
                        command.Parameters.AddWithValue("@petID", petID);
                        command.Parameters.AddWithValue("@currentXP", currentXP);
                        command.Parameters.AddWithValue("@currentHP", HP);
                        command.Parameters.AddWithValue("@rosterSlot", rosterSlot);
                        command.ExecuteNonQuery();

                        this.currentHP = 10000;
                        this.currentXP = currentXP;
                        this.rosterSlot = (int)rosterSlot;

                        FillAbilities();
                        frmMain.petList.Add(this);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
            else
            {
                this.petID = 0;
                this.name = "MAGICAL CRAWDAD";
                this.type = "Aquatic";
                this.rarity = "Rare";
                this.baseHP = 999;
                this.hpScale = 10;
                this.baseSpeed = 999;
                this.speedScale = 10;
                this.baseAtk = 999;
                this.atkScale = 10;
                this.DisplayImage = frmMain.petImages[this.name];
            }
        }

        public int Favorite
        {
            get { return favorite; }
            set { favorite = value; }
        }

        private string GetRarity(int rarity)
        {
            switch (rarity)
            {
                case (int)RarityLevel.Poor:
                    return "POOR";
                case (int)RarityLevel.Common:
                    return "COMMON";
                case (int)RarityLevel.Uncommon:
                    return "UNCOMMON";
                case (int)RarityLevel.Rare:
                    return "RARE";
                case (int)RarityLevel.Epic:
                    return "EPIC";
                case (int)RarityLevel.Legendary:
                    return "LEGENDARY";
            }
            return null;
        }

        public int RosterSlot
        {
            get { return rosterSlot; }
            set { rosterSlot = value; }
        }
        public int Level
        {
            get
            {
                //XP number to get to to be at the next level
                int cap = 0;
                
                //Setting a level cap of 25
                for (int i = 0; i < 25; i++)
                {
                    if (i != 24)
                    {
                        //Going through and adding more to the cap (i.e. 500 for 1, 1500: 2, 3000: 3)
                        for(int z = 0; z < i + 1; z++)
                        {
                            cap += (500);
                        }
                        if (currentXP > cap)
                        {
                            continue;
                        }
                        else
                        {
                            return (i + 1);
                        }
                    }
                    else
                    {
                        //Highest level
                        return 25;
                    }
                }
                return 0;
            }
           
        }
        public Ability SelectedAbility
        {
            get { return selectedAbility; }
            set { selectedAbility = value; }
        }

        public int Attack
        {
            get { return baseAtk + (atkScale * (Level - 1)); }
        }

        public int CurrentHP
        {
            get { if (currentHP < 0)
                {
                    currentHP = 0;
                }
                if (currentHP > HP)
                {
                    currentHP = HP;
                }
                    return currentHP; }
            set {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > HP)
                {
                    value = HP;
                }
                currentHP = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CurrentXP
        {
            get { return currentXP; }
            set { currentXP = value; }
        }

        public string Rarity
        {
            get { return rarity; }
        }

        public int HP
        {
            get { return baseHP + (hpScale * (Level - 1)); }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Speed
        {
            get { return baseSpeed + (speedScale*(Level - 1)); }
        }

        public Color GetColor()
        {
            if (this.rarity.Equals("COMMON"))
            {
                return Color.Black;
            }
            if (this.rarity.Equals("UNCOMMON"))
            {
                return Color.Red;
            }
            if (this.rarity.Equals("RARE"))
            {
                return Color.Green;
            }
            if (this.rarity.Equals("EPIC"))
            {
                return Color.Purple;
            }
            if (this.rarity.Equals("LEGENDARY"))
            {
                return Color.Blue;
            }
            return Color.Black;
        }

        private void FillAbilities()
        {
            abilities = new Ability[6];

            for (int i = 0; i < abilities.Length; i++)
            {
                Ability ability = new Ability(petID, i, true);
                abilities[i] = ability;
            }
        }

        private void FillNewAbilities()
        {
            abilities = new Ability[6];

            for (int i = 0; i < abilities.Length; i++)
            {
                Ability ability = new Ability(petID, i, false);
                abilities[i] = ability;
            }
        }

        public int PetID
        {
            get { return petID; }
            set { petID = value; }
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
