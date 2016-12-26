using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Windows.Media;

namespace GoldTeamRules
{
    public partial class frmMain : Form
    {
        private const int objectSideLength = 64;

        private int counter;
        private int movingDirectionLR = (int)Moving.Stop;
        private int movingDirectionUD = (int)Moving.Stop;
        private int speed = 5;
        private int battleSelection;
        private int heightMin;
        private int heightMax;
        private int widthMin;
        private int widthMax;
        private int playerCurrentHP;
        private int enemyCurrentHP;
        private int invincibilityCounter;
        private int currentMap;
        private int menuSelection = (int)MenuSelection.PlayerStats;
        private int messageSelection = 0;
        private int enemyIndex;
        private int roundNum;
        private int petSelection;
        public static int userID;
        private int selectedPet;
        private int abilitySelection;
        private int playerNum, opponentNum;
        private int countdownCounter = 30;
        private int damageBuff, accuracyBuff;
        private string[,] battleLog;
        private int battleNum;
        private int wins, losses;

        private bool captureEnabled = false;
        private bool abilityMenu;
        private bool invincibleFlag;
        private bool parentMenu;
        private bool hasChanged = false;
        private bool displayDamage = false;
        private bool gameOver;
        private bool hasWon;
        private bool petMenu;
        private bool captureActive = false;
        private bool petCaptured = false;

        private Pet enemy;
        private Random r;
        private Player p;

        private GameObject[] gameObjects;
        private Pet[] wildPets;
        private string[] mainMenuItems = { "Abilities", "Capture", "Switch Pet", "Pass Turn" };
        private Point[] mainMenuPoints =
        {
            new Point(70, 465),
            new Point(480, 465),

            new Point(70, 540),
            new Point(480, 540)
        };
        private Point[] battlePoints =
        {
            new Point(60, 450),
            new Point(60, 488),
            new Point(60, 521),
            new Point(60, 550)
        };

        private Point[] namePoints =
        {
            new Point(60,465),
            new Point(60,502),
            new Point(60,545)

        };
        private ProgressBar[] progressBars;
        float[][] invincibilityColorMatrix =
        {
            new float[] {2, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {.2f, .2f, .2f, 0, 1}
        };
        private List<string> messages;
        public static SortedList<string, Image> petImages;
        private SortedList<string, Image> images;
        internal static List<Pet> petList;
        public static SortedList<int, string> reports;
        private Pet[] combatants;
        public static string username;
        public static string password;
        public static int totalPets;
        internal static List<Pet> activeList;
        internal static List<string> afterBattleMessages;
        private MediaPlayer mp;
        public static bool testModeActive = false;

        public enum Moving
        {
            Stop,
            Up,
            Down,
            Left,
            Right
        }

        public enum BattleSelection
        {
            Abilities,
            Capture,
            Pets,
            Pass,
        }

        public enum Map
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum MenuSelection
        {
            PlayerStats,
            ViewPets,
            EditRoster,
            Log,
            Tutorial,
            Exit
        }

        public frmMain()
        {
            InitializeComponent();
            tc.SelectedIndex = 1;

            //Pet Images                  
            petImages = new SortedList<string, Image>();

            ///Aquatic
            petImages["Magical Crawdad"] = Image.FromFile(@"Resources\Sprites\crawdad.png");
            petImages["Gulp Froglet"] = Image.FromFile(@"Resources\Sprites\froglet.png");
            petImages["Puddle Terror"] = Image.FromFile(@"Resources\Sprites\puddleterror.png");

            ///Beast
            petImages["Baby Elderhorn"] = Image.FromFile(@"Resources\Sprites\baby-elderhorn.png");
            petImages["Death Adder Hatchling"] = Image.FromFile(@"Resources\Sprites\death-adder-hatchling.png");
            petImages["Winterspring Cub"] = Image.FromFile(@"Resources\Sprites\winterspring-cub.png");

            ///Critter
            petImages["Darkmoon Rabbit"] = Image.FromFile(@"Resources\Sprites\darkmoon-rabbit.png");
            petImages["Tol`Vir Scarab"] = Image.FromFile(@"Resources\Sprites\tol-vir-scarab.png");
            petImages["Rapana Whelk"] = Image.FromFile(@"Resources\Sprites\rapana-whelk.png");

            ///Dragonkin
            petImages["Emerald Proto-Whelp"] = Image.FromFile(@"Resources\Sprites\emerald-proto-whelp.png");
            petImages["Wild Jade Hatchling"] = Image.FromFile(@"Resources\Sprites\wild-jade-hatchling.png");
            petImages["Blue Dragonhawk Hatchling"] = Image.FromFile(@"Resources\Sprites\blue-dh.png");

            ///Elemental
            petImages["Core Hound Pup"] = Image.FromFile(@"Resources\Sprites\core-hound-pup.png");
            petImages["Singing Sunflower"] = Image.FromFile(@"Resources\Sprites\singing-sunflower.png");
            petImages["Terrible Turnip"] = Image.FromFile(@"Resources\Sprites\terrible-turnip.png");

            ///Flying
            petImages["Hyacinth Macaw"] = Image.FromFile(@"Resources\Sprites\hyacinth-macaw.png");
            petImages["Gryphon Hatchling"] = Image.FromFile(@"Resources\Sprites\gryphon-hatchling.png");
            petImages["Cerulean Moth"] = Image.FromFile(@"Resources\Sprites\cerulean-moth.png");

            ///Humanoid
            petImages["Anubisath Idol"] = Image.FromFile(@"Resources\Sprites\anubisath-idol.png");
            petImages["Grunty"] = Image.FromFile(@"Resources\Sprites\grunty.png");
            petImages["Kun-Lai Runt"] = Image.FromFile(@"Resources\Sprites\kun-lai-runt.png");

            ///Magic
            petImages["Coilfang Stalker"] = Image.FromFile(@"Resources\Sprites\coilfang-stalker.png");
            petImages["Disgusting Oozeling"] = Image.FromFile(@"Resources\Sprites\oozeling.png");
            petImages["Arcane Eye"] = Image.FromFile(@"Resources\Sprites\arcane-eye.png");

            ///Mechanical
            petImages["Clockwork Gnome"] = Image.FromFile(@"Resources\Sprites\clockwork-gnome.png");
            petImages["Personal World Destroyer"] = Image.FromFile(@"Resources\Sprites\world-destroyer.png");
            petImages["Fluxfire Feline"] = Image.FromFile(@"Resources\Sprites\fluxfire-feline.png");

            ///Undead
            petImages["Frostwolf Ghostpup"] = Image.FromFile(@"Resources\Sprites\frostworlf-ghostpup.png");
            petImages["Scourged Whelpling"] = Image.FromFile(@"Resources\Sprites\scourged-whelpling.png");
            petImages["Unborn Val`kyr"] = Image.FromFile(@"Resources\Sprites\unborn-val-kyr.png");

            //Wild
            petImages["Wild"] = Image.FromFile(@"Resources\Sprites\grass.png");

            //All Other Images
            images = new SortedList<string, Image>();

            //Background Images
            for (int i = 1; i < 10; i++)
            {
                images["bg" + i] = Image.FromFile(@"Resources\Backgrounds\Map\#" + i.ToString() + ".png");
            }

            currentMap = 2;
            DisplayMap();
            mapScreen.Invalidate();

            //Menu Images
            images["menu"] = Image.FromFile(@"Resources\Backgrounds\Menu\menu.png");

            //Battle Images
            images["battle"] = Image.FromFile(@"Resources\Backgrounds\Battle\battle.png");
            images["cage"] = Image.FromFile(@"Resources\Icons\birdcage.png");

            //Mario Images
            images["playerRight"] = Image.FromFile(@"Resources\Sprites\marioRight.png");
            images["playerLeft"] = Image.FromFile(@"Resources\Sprites\marioLeft.png");
            images["playerUp"] = Image.FromFile(@"Resources\Sprites\marioUp.png");
            images["playerDown"] = Image.FromFile(@"Resources\Sprites\marioDown.png");
            images["playerWalkingLeft"] = Image.FromFile(@"Resources\Sprites\marioWalkingLeft.png");
            images["playerWalkingRight"] = Image.FromFile(@"Resources\Sprites\marioWalkingRight.png");


            //Tutorial Images
            images["tutorial1"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\1.png");
            images["tutorial2"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\2.png");
            images["tutorial3"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\3.png");
            images["tutorial4"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\4.png");
            images["tutorial5"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\5.png");
            images["tutorial6"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\6.png");
            images["tutorial7"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\7.png");
            images["tutorial8"] = Image.FromFile(@"Resources\Backgrounds\Tutorial\8.png");
        

            this.DoubleBuffered = true;
            p = new Player();
            p.Location = new Point(0, 0);
            petList = new List<Pet>(300);
            activeList = new List<Pet>(3);
            p.DisplayImage = images["playerRight"];

            //Fix flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, mapScreen, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, battleScreen, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, menuScreen, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, tutorialScreen, new object[] { true });

            //Tab Control Editing
            tc.Appearance = TabAppearance.FlatButtons;
            tc.ItemSize = new Size(0, 1);
            tc.SizeMode = TabSizeMode.Fixed;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            mp = new MediaPlayer();
            mp.Open(new Uri(Environment.CurrentDirectory + @"\Content\soundtrack.mp3"));
            mp.Play();
            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;
            frmLogin frm = new frmLogin();
            DialogResult result = frm.ShowDialog();
            //Login
            if (result == DialogResult.OK)
            {
                tc.SelectedIndex = 0;
                try
                {
                    using (SqlConnection connection = new SqlConnection(_cnDB))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT password, userID, wins, losses FROM dbo.Logins WHERE username = @Value", connection);
                        command.Parameters.AddWithValue("@Value", username);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (password == reader.GetString(0))
                                    {
                                        userID = reader.GetInt32(1);
                                        wins = reader.GetInt32(2);
                                        losses = reader.GetInt32(3);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Login unsuccessful.");
                                        Application.Restart();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Login unsuccessful.");
                                Application.Restart();
                            }
                        }
                        command = new SqlCommand("dbo.usp_Load_CapturedPet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@numRows", totalPets);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int petID = Int32.Parse(reader[0].ToString());
                                    int currentXP = Int32.Parse(reader[1].ToString());
                                    int currentHP = Int32.Parse(reader[2].ToString());
                                    int rosterSlot = -1;
                                    if (reader[3] != null)
                                    {
                                        rosterSlot = Int32.Parse(reader[3].ToString());
                                    }
                                    int favorite = 0;
                                    if(reader[4] != null)
                                    {
                                        favorite = Int32.Parse(reader[4].ToString());
                                    }
                                    Pet pet = new Pet(petID, currentXP, currentHP, rosterSlot, favorite);
                                    petList.Add(pet);
                                }
                            }
                        }
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.StackTrace);
                    MessageBox.Show(e1.Message);
                }
            }
            else if (result == DialogResult.Abort)
            {
                tc.SelectedIndex = 3;
            }
            else if(result == DialogResult.Ignore)
            {
                userID = 999;
                testModeActive = true;
                tc.SelectedIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    Pet p = new Pet();
                    p.RosterSlot = i + 1;
                    activeList.Add(p);
                    petList.Add(p);
                }
            }           
            else
            {
                Environment.Exit(0);
            }

            for (int i = 0; i < petList.Count; i++)
            {
                if (petList[i].RosterSlot != -1)
                {
                    activeList.Add(petList[i]);
                }
            }
            for (int i = 0; i < activeList.Count; i++)
            {
                for (int j = i + 1; j < activeList.Count; j++)
                {
                    if (activeList[j].RosterSlot < activeList[i].RosterSlot)
                    {
                        Pet temp = activeList[i];
                        activeList[i] = activeList[j];
                        activeList[j] = temp;
                    }
                }
            }

            gameObjects = new GameObject[6];
            messages = new List<string>();
            afterBattleMessages = new List<string>();
            gameLoop.Enabled = true;
            animationTimer.Enabled = true;

            battleScreen.BackgroundImage = images["battle"];
            menuScreen.BackgroundImage = images["menu"];
            tutorialScreen.BackgroundImage = images["tutorial1"];

            //Add controls to battlescreen
            ProgressBar pb0 = new ProgressBar();
            ProgressBar pb1 = new ProgressBar();

            pb0.Location = new Point(115, 130);
            pb1.Location = new Point(375, 325);
            pb0.Size = new Size(350, 23);
            pb1.Size = new Size(350, 23);
            pb0.Style = ProgressBarStyle.Continuous;
            pb1.Style = ProgressBarStyle.Continuous;

            progressBars = new ProgressBar[2];
            progressBars[0] = pb0; //Enemy Hp Bar
            progressBars[1] = pb1; //Player Hp Bar
            foreach (ProgressBar pb in progressBars)
            {
                battleScreen.Controls.Add(pb);
            }
            r = new Random();
            wildPets = new Pet[5];
            p.Location = new Point(400, 75);
            gameObjects[0] = p;
            SpawnPets();
            collisionChecker.Enabled = true;
            petMover.Enabled = true;
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {        
            if (invincibilityCounter > 10 || invincibilityCounter < -1)
            {
                invincibilityCounter = 0;
            }
            if (movingDirectionUD == (int)Moving.Up)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X, gameObjects[0].Location.Y - speed);
            }
            if (movingDirectionUD == (int)Moving.Down)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X, gameObjects[0].Location.Y + speed);
            }
            if (movingDirectionLR == (int)Moving.Left)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X - speed, gameObjects[0].Location.Y);
            }
            if (movingDirectionLR == (int)Moving.Right)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X + speed, gameObjects[0].Location.Y);
            }
            int currentlyMovingLR = movingDirectionLR;
            int currentlyMovingUD = movingDirectionUD;
            if (gameObjects[0].Location.X + objectSideLength > this.Width)
            {
                if (currentMap == 3 || currentMap == 6 || currentMap == 9)
                {
                    movingDirectionLR = (int)Moving.Left;
                    pushBack.Enabled = true;
                }
                else
                {
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;
                    if (hasChanged == false)
                    {
                        ChangeMap(Map.Right);
                        movingDirectionLR = currentlyMovingLR;
                        movingDirectionUD = currentlyMovingUD;
                    }
                }
            }

            if (gameObjects[0].Location.X + objectSideLength / 2 < 0)
            {
                if (currentMap == 1 || currentMap == 4 || currentMap == 7)
                {
                    movingDirectionLR = (int)Moving.Right;
                    pushBack.Enabled = true;
                }
                else
                {
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;
                    if (hasChanged == false)
                    {
                        ChangeMap(Map.Left);
                        movingDirectionLR = currentlyMovingLR;
                        movingDirectionUD = currentlyMovingUD;
                    }
                }
            }
            if (gameObjects[0].Location.Y > this.Height - (objectSideLength * 2) + 50)
            {
                if (currentMap == 7 || currentMap == 8 || currentMap == 9)
                {
                    movingDirectionUD = (int)Moving.Up;
                    pushBack.Enabled = true;
                }
                else
                {
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;
                    if (hasChanged == false)
                    {
                        ChangeMap(Map.Down);
                        movingDirectionLR = currentlyMovingLR;
                        movingDirectionUD = currentlyMovingUD;
                    }
                }
            }
            if (gameObjects[0].Location.Y < 5)
            {
                if (currentMap == 1 || currentMap == 2 || currentMap == 3)
                {
                    movingDirectionUD = (int)Moving.Down;
                    pushBack.Enabled = true;
                }
                else
                {
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;
                    if (hasChanged == false)
                    {
                        ChangeMap(Map.Up);
                        movingDirectionLR = currentlyMovingLR;
                        movingDirectionUD = currentlyMovingUD;
                    }
                }
            }
            if (currentMap == 5 && IsTouching(new Rectangle(gameObjects[0].Location, new Size(objectSideLength, objectSideLength)), new Rectangle(new Point(400 - objectSideLength, 300 - objectSideLength), new Size(objectSideLength, objectSideLength))))
            {
                //Colliding with image in center of map
                //Prob gonna be online pvp
                //why not
                //hack: that's a great way to do PVP. Def should do
            }
            mapScreen.Invalidate();
        }

        private void SpawnPets()
        {
            Random r = new Random();
            wildPets = new Pet[r.Next(2, 5)];
            for (int i = 0; i < wildPets.Length; i++)
            {
                //Fill game objects array for the paint method to draw               
                Pet.seed = (i * r.Next()) + r.Next();
                Pet pet = new Pet(r.Next(1, 30));
                wildPets[i] = pet;
                wildPets[i].Location = GetStartingPoint();
            }

            for (int i = 0; i < wildPets.Length; i++)
            {
                //Reduce duplicate locations signifigantly
                for (int j = i + 1; j < wildPets.Length - 1; j++)
                {
                    Rectangle r1 = new Rectangle(wildPets[j].Location, new Size(objectSideLength, objectSideLength));
                    Rectangle r2 = new Rectangle(wildPets[i].Location, new Size(objectSideLength, objectSideLength));
                    if (IsTouching(r1, r2))
                    {
                        wildPets[i].Location = GetStartingPoint();
                    }
                    for (int z = j + 1; j < wildPets.Length - 2; j++)
                    {
                        Rectangle r1a = new Rectangle(wildPets[z].Location, new Size(objectSideLength, objectSideLength));
                        Rectangle r2a = new Rectangle(wildPets[j].Location, new Size(objectSideLength, objectSideLength));
                        if (IsTouching(r1a, r2a))
                        {
                            wildPets[i].Location = GetStartingPoint();
                        }
                        for (int x = z + 1; j < wildPets.Length - 3; j++)
                        {
                            Rectangle r1b = new Rectangle(wildPets[x].Location, new Size(objectSideLength, objectSideLength));
                            Rectangle r2b = new Rectangle(wildPets[z].Location, new Size(objectSideLength, objectSideLength));
                            if (IsTouching(r1b, r2b))
                            {
                                wildPets[i].Location = GetStartingPoint();
                            }
                            for (int y = x + 1; j < wildPets.Length - 4; j++)
                            {
                                Rectangle r1c = new Rectangle(wildPets[y].Location, new Size(objectSideLength, objectSideLength));
                                Rectangle r2c = new Rectangle(wildPets[x].Location, new Size(objectSideLength, objectSideLength));
                                if (IsTouching(r1c, r2c))
                                {
                                    wildPets[i].Location = GetStartingPoint();
                                }
                            }
                        }
                    }
                }
            }
            //Refresh the screen
            mapScreen.Invalidate();
        }

        private void ChangeMap(Map mapMove)
        {
            if (mapMove == Map.Right)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X - this.Width + objectSideLength, gameObjects[0].Location.Y);
                currentMap++;
            }
            if (mapMove == Map.Left)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X + this.Width - objectSideLength, gameObjects[0].Location.Y);
                currentMap--;
            }
            if (mapMove == Map.Down)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X, (objectSideLength / 2));
                currentMap += 3;
            }
            if (mapMove == Map.Up)
            {
                gameObjects[0].Location = new Point(gameObjects[0].Location.X, this.Height - (objectSideLength * 2));
                currentMap -= 3;
            }
            hasChanged = true;
            DisplayMap();
            SpawnPets();
            hasChanged = false;
        }

        private void PrepareBattleVariables()
        {
            string _cndb = GoldTeamRules.Properties.Settings.Default.cnDb;
            battleLog = new string[100, 5];
            battleNum = 1;
            try
            {
                if (!testModeActive)
                {
                    using (SqlConnection connection = new SqlConnection(_cndb))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM CombatLog WHERE userID = @userID", connection))
                        {
                            command.Parameters.AddWithValue("@userID", userID);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.HasRows)
                                    {
                                        battleNum++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void DisplayMap()
        {
            mapScreen.BackgroundImage = null;
            mapScreen.BackgroundImage = images["bg" + currentMap];
        }

        private void Collision()
        {
            gameLoop.Enabled = false;
            petMover.Enabled = false;
            collisionChecker.Enabled = false;
            countdownCounter = 30;
            countdownTimer.Enabled = true;
            PrepareBattleVariables();
            tc.SelectedIndex = 2;
            damageBuff = 0;
            accuracyBuff = 0;
            battleSelection = (int)BattleSelection.Abilities;
            parentMenu = true;
            enemy = wildPets[enemyIndex];
            captureEnabled = true;
            for (int i = 0; i < petList.Count; i++)
            {
                if (petList[i].PetID.Equals(enemy.PetID))
                {
                    captureEnabled = false;
                }
            }
            playerCurrentHP = activeList[selectedPet].CurrentHP;
            enemyCurrentHP = enemy.HP;
            progressBars[0].Maximum = enemyCurrentHP;
            progressBars[1].Maximum = activeList[selectedPet].HP;
            battleScreen.Invalidate();
            battleLoop.Enabled = true;
            roundNum = 1;
        }

        private bool TakeTurn(int user, int target)
        {
            //Assign the users selected ability to local variables
            if (combatants[user].SelectedAbility.Name.Equals("Sandstorm"))
            {
                damageBuff = -74;
                accuracyBuff = -10;
            }
            if (combatants[user].SelectedAbility.Name.Equals("Sunlight"))
            {
                damageBuff = (int)(combatants[user].SelectedAbility.Damage * .5);
            }
            if (combatants[user].SelectedAbility.Name.Equals("Mana Surge"))
            {
                damageBuff = 154;
            }
            if (combatants[user].SelectedAbility.Name.Equals("Apocalypse"))
            {
                damageBuff = 80;
                accuracyBuff = 10;
            }
            if (combatants[user].SelectedAbility.Name.Equals("Flame Breath"))
            {
                damageBuff = 52;
            }
            if (combatants[user].SelectedAbility.Name.Equals("Amplify Magic"))
            {
                damageBuff = (int)(combatants[user].SelectedAbility.Damage * .5);
            }

            int damage = (damageBuff + combatants[user].Attack + combatants[user].SelectedAbility.Damage) / r.Next(5, 7);
            double accuracy = (accuracyBuff + combatants[user].SelectedAbility.Accuracy);
            string name = combatants[user].SelectedAbility.Name;

            int targetHP = combatants[target].CurrentHP;
            bool onTarget = false;

            //Checks if attack will miss or hit
            if (accuracy >= r.Next(100))
            {
                onTarget = true;
            }

            //Conditional if for on target attacks
            if (onTarget)
            {
                targetHP -= damage;
            }

            combatants[target].CurrentHP = targetHP;

            return onTarget;
        }

        private void SaveBattleLog()
        {
            string _cndb = GoldTeamRules.Properties.Settings.Default.cnDb;

            try
            {
                using (SqlConnection connection = new SqlConnection(_cndb))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"Insert into CombatLog Values(@b, @a, @c, @d, @e, @f, @g, @h)", connection))
                    {
                        for (int i = 0; i < roundNum - 1; i++)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@a", battleNum);
                            command.Parameters.AddWithValue("@b", userID);
                            command.Parameters.AddWithValue("@c", i + 1);
                            command.Parameters.AddWithValue("@d", battleLog[i, 0]);
                            command.Parameters.AddWithValue("@e", battleLog[i, 1]);
                            command.Parameters.AddWithValue("@f", battleLog[i, 2]);
                            command.Parameters.AddWithValue("@g", battleLog[i, 3]);
                            command.Parameters.AddWithValue("@h", battleLog[i, 4]);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                roundNum = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void SavePets()
        {
            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;

            try
            {
                using (SqlConnection connection = new SqlConnection(_cnDB))
                {
                    connection.Open();
                    for (int i = 0; i < petList.Count; i++)
                    {
                        SqlCommand command = new SqlCommand("dbo.usp_update_CapturedPet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@petID", petList[i].PetID);
                        command.Parameters.AddWithValue("@currentXP", petList[i].CurrentXP);
                        command.Parameters.AddWithValue("@currentHP", petList[i].CurrentHP);
                        command.Parameters.AddWithValue("@rosterSlot", petList[i].RosterSlot);
                        command.ExecuteNonQuery();

                        command = new SqlCommand("dbo.usp_Update_Ability", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        for (int z = 0; z < 6; z++)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@userID", userID);
                            command.Parameters.AddWithValue("@petID", petList[i].PetID);
                            command.Parameters.AddWithValue("@name", petList[i].abilities[z].Name);
                            command.Parameters.AddWithValue("@abilityNum", z);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private Point GetStartingPoint()
        {
            heightMin = 150;
            heightMax = 450;
            widthMin = 150;
            widthMax = 600;

            int height = r.Next(heightMin, heightMax);
            int width = r.Next(widthMin, widthMax);
            Point point = new Point(width, height);
            return point;
        }

        private void SaveStats()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(GoldTeamRules.Properties.Settings.Default.cnDb))
                {
                    conn.Open();
                    using(SqlCommand command = new SqlCommand("Update logins set wins = @wins, losses = @losses where userID = @id", conn))
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@wins", wins);
                        command.Parameters.AddWithValue("@losses", losses);
                        command.Parameters.AddWithValue("@id", userID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private bool IsTouching(Rectangle r1, Rectangle r2)
        {
            if (r1.Location.X + r1.Width < r2.Location.X)
                return false;
            if (r2.Location.X + r2.Width < r1.Location.X)
                return false;
            if (r1.Location.Y + r1.Height < r2.Location.Y)
                return false;
            if (r2.Location.Y + r2.Height < r1.Location.Y)
                return false;
            return true;
        }

        private void damageDisplayer_Tick(object sender, EventArgs e)
        {
            int winningXP = 0;
            if (messageSelection == messages.Count)
            {
                if (petCaptured)
                {
                    petCaptured = false;
                    displayDamage = false;
                    damageDisplayer.Enabled = false;
                    gameOver = true;
                    hasWon = true;
                    wins++;
                }
                //Keep fighting
                else if (activeList[selectedPet].CurrentHP > 0 && enemy.CurrentHP > 0)
                {
                    displayDamage = false;
                    damageDisplayer.Enabled = false;
                    messageSelection = 0;
                    messages.Clear();
                    countdownCounter = 30;
                    countdownTimer.Enabled = true;
                    parentMenu = true;
                    battleScreen.Invalidate();
                }
                //Current pet alive, enemy fainted
                else if (activeList[selectedPet].CurrentHP > 0 && enemy.CurrentHP <= 0)
                {
                    winningXP = r.Next(10, 100) * enemy.Level;
                    string s = "";
                    afterBattleMessages.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        s = "";
                        if (activeList[i].CurrentHP > 0)
                        {
                            int currentLevel = activeList[i].Level;
                            activeList[i].CurrentXP += winningXP;
                            s += activeList[i].Name + " gained " + winningXP + " XP!";
                            int deltaLevel = activeList[i].Level;
                            if (currentLevel != deltaLevel)
                            {
                                s += "|" + activeList[i].Name + " leveled up!";
                            }
                            afterBattleMessages.Add(s);
                        }
                    }
                    damageDisplayer.Enabled = false;
                    frmAfterBattle frm = new frmAfterBattle();
                    frm.ShowDialog();
                    gameOver = true;
                    hasWon = true;
                }

                //Current pet fainted, enemy alive, check for pet switch
                else if (activeList[selectedPet].CurrentHP <= 0 && enemy.CurrentHP > 0)
                {
                    messages.Add(activeList[selectedPet].Name + " has fainted!");
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != selectedPet && i < 3)
                        {
                            if (activeList[i].CurrentHP > 0)
                            {
                                selectedPet = i;
                                messages.Add("You sent out " + activeList[selectedPet].Name);
                                playerCurrentHP = activeList[selectedPet].CurrentHP;
                                displayDamage = true;
                                damageDisplayer.Enabled = true;
                                battleScreen.Invalidate();
                                break;
                            }
                        }
                        if (i == 3)
                        {
                            messages.TrimExcess();
                            damageDisplayer.Enabled = false;
                            gameOver = true;
                            losses++;
                            if (!testModeActive)
                            {
                                SaveStats();
                            }
                            afterBattleMessages.Clear();
                            afterBattleMessages.Add("All your pets ran out of HP!|Heal your pets and get back to fighting!");
                            frmAfterBattle frm = new frmAfterBattle();
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    displayDamage = false;
                    damageDisplayer.Enabled = false;
                    parentMenu = true;
                }
            }

            if (gameOver)
            {
                if (!testModeActive)
                {
                    SavePets();
                    SaveBattleLog();
                }
                
                if (hasWon)
                {                   
                    gameOver = false;
                    hasWon = false;
                    wins++;
                    if (!testModeActive)
                    {
                        SaveStats();
                    }
                    displayDamage = false;
                    damageDisplayer.Enabled = false;
                    wildPets[enemyIndex].Location = new Point(10000, 10000);
                    tc.SelectedIndex = 0;
                    gameLoop.Enabled = true;
                    petMover.Enabled = true;
                    invincibilitySeconds.Enabled = true;
                    invincibilityBlinker.Enabled = true;
                    battleLoop.Enabled = false;
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;
                }
                else
                {
                    gameOver = false;
                    displayDamage = false;
                    damageDisplayer.Enabled = false;
                    tc.SelectedIndex = 0;
                    gameLoop.Enabled = true;
                    petMover.Enabled = true;
                    invincibilitySeconds.Enabled = true;
                    invincibilityBlinker.Enabled = true;
                    battleLoop.Enabled = false;
                    movingDirectionLR = (int)Moving.Stop;
                    movingDirectionUD = (int)Moving.Stop;

                }
            }
            battleScreen.Invalidate();
        }

        private void pushBack_Tick(object sender, EventArgs e)
        {
            movingDirectionLR = (int)Moving.Stop;
            movingDirectionUD = (int)Moving.Stop;
            if (!(gameObjects[0].Location.X + objectSideLength > this.Width))
            {
                if (!(gameObjects[0].Location.X + objectSideLength / 2 < 0))
                {
                    if (!(gameObjects[0].Location.Y > this.Height - (objectSideLength * 2) + 50))
                    {
                        if (!(gameObjects[0].Location.Y < 5))
                        {
                            pushBack.Enabled = false;
                        }
                    }
                }
            }
        }

        private void invincibilitySeconds_Tick(object sender, EventArgs e)
        {
            invincibilityCounter++;
            if (invincibilityCounter < 10)
            {
                invincibilityBlinker.Enabled = false;
                invincibilitySeconds.Enabled = false;
                invincibleFlag = false;
                collisionChecker.Enabled = true;
            }
        }

        private void invincibilityBlinker_Tick(object sender, EventArgs e)
        {
            if (invincibleFlag)
            {
                invincibleFlag = false;
            }
            else
            {
                invincibleFlag = true;
            }
        }

        private void petMover_Tick(object sender, EventArgs e)
        {
            //Move pets
            for (int i = 0; i < wildPets.Length; i++)
            {
                wildPets[i].Location = new Point(wildPets[i].Location.X + (int)(r.Next(-5, 5) / 5), wildPets[i].Location.Y + (int)(r.Next(-5, 5) / 5));
            }
        }

        private void battleLoop_Tick(object sender, EventArgs e)
        {
            if (messageSelection > messages.Count)
            {
                messageSelection = messages.Count;
            }
            if (enemyCurrentHP < 0)
            {
                enemyCurrentHP = 0;
            }
            if (enemyCurrentHP < .35 * enemy.HP && captureEnabled)
            {
                captureActive = true;
            }
            else
            {
                captureActive = false;
            }
            if (playerCurrentHP < 0)
            {
                playerCurrentHP = 0;
            }

            //Starts off green
            ModifyProgressBarColor.SetState(progressBars[0], 1);
            ModifyProgressBarColor.SetState(progressBars[1], 1);

            progressBars[0].Maximum = enemy.HP;
            progressBars[1].Maximum = activeList[selectedPet].HP;

            progressBars[0].Value = enemyCurrentHP;
            if (playerCurrentHP <= progressBars[1].Maximum)
                progressBars[1].Value = playerCurrentHP;
            else
                progressBars[1].Value = progressBars[1].Maximum;

            //If below 35% turn yellow
            if (enemyCurrentHP <= .35 * (enemy.HP))
            {
                ModifyProgressBarColor.SetState(progressBars[0], 3);
            }
            if (playerCurrentHP <= .35 * (activeList[selectedPet].HP))
            {
                ModifyProgressBarColor.SetState(progressBars[1], 3);
            }

            //If below 10% turn red
            if (enemyCurrentHP <= .1 * (enemy.HP))
            {
                ModifyProgressBarColor.SetState(progressBars[0], 2);
            }
            if (playerCurrentHP <= .1 * (activeList[selectedPet].HP))
            {
                ModifyProgressBarColor.SetState(progressBars[1], 2);
            }
            battleScreen.Invalidate();
        }

        private void collisionChecker_Tick(object sender, EventArgs e)
        {
            //Check for pet collision
            for (int i = 0; i < wildPets.Length; i++)
            {
                Rectangle r1 = new Rectangle(wildPets[i].Location, new Size(objectSideLength, objectSideLength));
                Rectangle r2 = new Rectangle(gameObjects[0].Location, new Size(objectSideLength, objectSideLength));
                if (IsTouching(r1, r2))
                {
                    enemyIndex = i;
                    enemy = wildPets[enemyIndex];
                    if (activeList[0].CurrentHP > 0)
                    {
                        selectedPet = 0;
                        Collision();
                    }
                    else if (activeList[1].CurrentHP > 0)
                    {
                        selectedPet = 1;
                        Collision();
                    }
                    else if (activeList[2].CurrentHP > 0)
                    {
                        selectedPet = 2;
                        Collision();
                    }
                    else
                    {
                        afterBattleMessages.Clear();
                        afterBattleMessages.Add("All of your pets are out of HP!|Heal up and get back in there!");
                        frmAfterBattle frm = new frmAfterBattle();
                        if (movingDirectionLR == (int)Moving.Left)
                        {
                            gameObjects[0].Location = new Point(wildPets[i].Location.X + objectSideLength + 15, gameObjects[0].Location.Y);
                        }
                        if (movingDirectionLR == (int)Moving.Right)
                        {
                            gameObjects[0].Location = new Point(wildPets[i].Location.X - 70, gameObjects[0].Location.Y);
                        }
                        if (movingDirectionUD== (int)Moving.Up)
                        {
                            gameObjects[0].Location = new Point(gameObjects[0].Location.X, wildPets[i].Location.Y + objectSideLength + 10);
                        }
                        if (movingDirectionUD == (int)Moving.Down)
                        {
                            gameObjects[0].Location = new Point(gameObjects[0].Location.X, wildPets[i].Location.Y - 70);
                        }
                        movingDirectionLR = (int)Moving.Stop;
                        movingDirectionUD = (int)Moving.Stop;
                        collisionChecker.Enabled = false;
                        petMover.Enabled = false;
                        frm.ShowDialog();
                        collisionChecker.Enabled = true;
                        petMover.Enabled = true;
                    }
                }
            }
        }

        private void mapScreen_Paint_1(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Graphics g = e.Graphics;

            Image image = p.DisplayImage;
            Point[] points =
            {
                        new Point(p.Location.X, p.Location.Y),
                        new Point(p.Location.X + objectSideLength, p.Location.Y),
                        new Point(p.Location.X, p.Location.Y + objectSideLength)
                    };
            Rectangle rect = new Rectangle(p.Location, new Size(objectSideLength, objectSideLength));
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cmI = new ColorMatrix(invincibilityColorMatrix);

            if (invincibleFlag)
            {
                ia.SetColorMatrix(cmI, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(image, points, rect, GraphicsUnit.Pixel, ia);
            }
            else
            {
                g.DrawImage(image, p.Location);
            }
            for (int i = 0; i < wildPets.Length; i++)
            {
                g.DrawImage(petImages["Wild"], wildPets[i].Location.X, wildPets[i].Location.Y, objectSideLength, objectSideLength);
            }
        }


        private void menuScreen_Paint_1(object sender, PaintEventArgs e)
        {
            string[] menuItems0 =
            {
                "Player Stats",
                "View Journal",
                "Edit Roster",
                "Combat Log",
                "Tutorial",
                "Save and Exit"
            };
            Graphics g = e.Graphics;

            int menuHeightMin = 130;
            int menuHeightMax = 500;
            int menuWidthPoint = (Width / 2) - 10;
            double heightScale = (menuHeightMax - menuHeightMin) / (menuItems0.Length);

            using (System.Drawing.FontFamily fontFamily = new System.Drawing.FontFamily("Lucida Sans"))
            {
                using (Font menuFont = new Font(fontFamily, 28, FontStyle.Bold))
                {
                    using (System.Drawing.Brush notSelectedValid = new SolidBrush(System.Drawing.Color.Black))
                    {
                        using (System.Drawing.Brush notSelectedInvalid = new SolidBrush(System.Drawing.Color.DarkGray))
                        {
                            using (System.Drawing.Brush selected = new SolidBrush(System.Drawing.Color.White))
                            {


                                for (int i = 0; i < menuItems0.Length; i++)
                                {
                                    int height = menuHeightMin + (int)(heightScale * (i));
                                    int width = menuWidthPoint - ((int)(g.MeasureString(menuItems0[i], menuFont).Width) / 2);
                                    Point location = new Point(width, height);

                                    if (i != menuSelection)
                                    {
                                        g.DrawString(menuItems0[i], menuFont, notSelectedValid, location);
                                    }
                                    else
                                    {
                                        g.DrawString(menuItems0[i], menuFont, selected, location);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void battleScreen_Paint_1(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Graphics g = e.Graphics;
            System.Drawing.FontFamily fontFamily = new System.Drawing.FontFamily("Lucida Sans");
            Font menuFont = new Font(fontFamily, 22, FontStyle.Bold);
            using (System.Drawing.Brush notSelected = new SolidBrush(System.Drawing.Color.Black))
            {
                using (System.Drawing.Brush selected = new SolidBrush(System.Drawing.Color.Red))
                {
                    String s = "";
                    //menu drawing
                    for (int i = 0; i < mainMenuItems.Length; i++)
                    {
                        s = "Press ENTER to select";
                        g.DrawString("Press W/A/S/D to move cursor", new Font(fontFamily, 20, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), new Point(10, 10));
                        //main menu section
                        if (parentMenu)
                        {
                            if (i != 1)
                            {
                                if (i != battleSelection)
                                {
                                    g.DrawString(mainMenuItems[i], menuFont, notSelected, mainMenuPoints[i]);
                                }
                                else
                                {
                                    g.DrawString(mainMenuItems[i], menuFont, selected, mainMenuPoints[i]);
                                }
                            }
                            else
                            {
                                if (captureActive)
                                {
                                    if (i != battleSelection)
                                    {
                                        g.DrawString(mainMenuItems[i], menuFont, notSelected, mainMenuPoints[i]);
                                    }
                                    else
                                    {
                                        g.DrawString(mainMenuItems[i], menuFont, selected, mainMenuPoints[i]);
                                    }
                                }
                                else
                                {
                                    using (System.Drawing.Brush b = new SolidBrush(System.Drawing.Color.Gray))
                                    {
                                        g.DrawString(mainMenuItems[i], menuFont, b, mainMenuPoints[i]);
                                    }
                                }
                            }
                            this.Invalidate();
                        }
                        else if (!displayDamage)
                        {
                            if (abilityMenu)
                            {
                                for (int x = 0; x < 5; x += 2)
                                {
                                    System.Drawing.Brush b;
                                    if (x != abilitySelection)
                                    {
                                        b = notSelected;
                                    }
                                    else
                                    {
                                        b = selected;
                                    }
                                    g.DrawString("NAME", menuFont, new SolidBrush(System.Drawing.Color.Black), battlePoints[0]);
                                    g.DrawString("DMG", menuFont, new SolidBrush(System.Drawing.Color.Black), new Point(battlePoints[0].X + 400, battlePoints[0].Y));
                                    g.DrawString("ACC", menuFont, new SolidBrush(System.Drawing.Color.Black), new Point(battlePoints[0].X + 600, battlePoints[0].Y));
                                    g.DrawLine(new System.Drawing.Pen(new SolidBrush(System.Drawing.Color.Black), 5), new Point(50, 480), new Point(750, 480));
                                    if (x == 0)
                                    {
                                        g.DrawString(activeList[selectedPet].abilities[x].Name, menuFont, b, battlePoints[1]);
                                        g.DrawString(activeList[selectedPet].abilities[x].Damage.ToString(), menuFont, b, new Point(battlePoints[1].X + 400, battlePoints[1].Y));
                                        g.DrawString(activeList[selectedPet].abilities[x].Accuracy.ToString() + '%', menuFont, b, new Point(battlePoints[1].X + 600, battlePoints[1].Y));
                                    }
                                    else if (x == 2)
                                    {
                                        g.DrawString(activeList[selectedPet].abilities[x].Name, menuFont, b, battlePoints[2]);
                                        g.DrawString(activeList[selectedPet].abilities[x].Damage.ToString(), menuFont, b, new Point(battlePoints[2].X + 400, battlePoints[2].Y));
                                        g.DrawString(activeList[selectedPet].abilities[x].Accuracy.ToString() + '%', menuFont, b, new Point(battlePoints[2].X + 600, battlePoints[2].Y));
                                    }
                                    else if (x == 4)
                                    {
                                        g.DrawString(activeList[selectedPet].abilities[x].Name, menuFont, b, battlePoints[3]);
                                        g.DrawString(activeList[selectedPet].abilities[x].Damage.ToString(), menuFont, b, new Point(battlePoints[3].X + 400, battlePoints[3].Y));
                                        g.DrawString(activeList[selectedPet].abilities[x].Accuracy.ToString() + '%', menuFont, b, new Point(battlePoints[3].X + 600, battlePoints[3].Y));
                                    }
                                    this.Invalidate();
                                }
                            }
                            else if (petMenu)
                            {
                                for (int x = 0; x < 3; x++)
                                {
                                    System.Drawing.Brush b;
                                    if (x != petSelection)
                                    {
                                        b = notSelected;
                                    }
                                    else
                                    {
                                        b = selected;
                                    }
                                    if (x == selectedPet || activeList[x].CurrentHP == 0)
                                    {
                                        b = new SolidBrush(System.Drawing.Color.Gray);
                                    }
                                    g.DrawString(activeList[x].Name, menuFont, b, namePoints[x].X, namePoints[x].Y);
                                    g.DrawString("HP: " + activeList[x].CurrentHP + "/" + activeList[x].HP, menuFont, b, namePoints[x].X + 400, namePoints[x].Y);
                                }
                            }
                        }

                        else
                        {
                            if (i == 0)
                            {
                                //Damage displayer
                                for (int x = 0; x < messages.Count; x++)
                                {

                                    if (x == messageSelection)
                                    {

                                        if (messages[x].Length > 37)
                                        {
                                            menuFont = new Font(fontFamily, 20, FontStyle.Regular);
                                        }

                                        g.DrawString(messages[x], menuFont, notSelected, mainMenuPoints[0]);

                                        if (opponentNum == 0)
                                        {
                                            if (x == 1)
                                                playerCurrentHP = activeList[selectedPet].CurrentHP;
                                            if (x == 3)
                                                enemyCurrentHP = enemy.CurrentHP;
                                        }
                                        else if (playerNum == 0)
                                        {
                                            if (x == 1)
                                                enemyCurrentHP = enemy.CurrentHP;
                                            if (x == 3)
                                                playerCurrentHP = activeList[selectedPet].CurrentHP;
                                        }
                                        else if (opponentNum == 2)
                                        {
                                            if (x == 2)
                                            {
                                                playerCurrentHP = activeList[selectedPet].CurrentHP;
                                            }
                                        }
                                    }
                                }
                            }
                            g.DrawString(s, new Font(fontFamily, 20, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), new Point(490, 10));
                        }
                        g.DrawString(s, new Font(fontFamily, 20, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), new Point(490, 10));
                    }

                    //draw ui
                    using (Font uiFont = new Font(fontFamily, 20, FontStyle.Bold))
                    {
                        using (Font littleFont = new Font(fontFamily, 16, FontStyle.Regular))
                        {
                            using (System.Drawing.Brush uiBrush = new SolidBrush(System.Drawing.Color.Black))
                            {
                                using (System.Drawing.Brush playerNameBrush = new SolidBrush(activeList[selectedPet].GetColor()))
                                {
                                    using (System.Drawing.Brush enemyNameBrush = new SolidBrush(enemy.GetColor()))
                                    {
                                        g.DrawString("Name: ", uiFont, uiBrush, new Point(56, 87)); // enemy
                                        g.DrawString(enemy.Name, littleFont, enemyNameBrush, new Point(150, 89));
                                        g.DrawString("HP:", uiFont, uiBrush, new Point(56, 125));
                                        g.DrawString("Level: " + enemy.Level.ToString(), uiFont, uiBrush, new Point(56, 163));
                                        g.DrawString(enemyCurrentHP + "/" + enemy.HP, uiFont, uiBrush, new Point(320, 163));

                                        g.DrawString("Name: ", uiFont, uiBrush, new Point(312, 282)); // player
                                        g.DrawString(activeList[selectedPet].Name, littleFont, playerNameBrush, new Point(406, 285));
                                        g.DrawString("HP:", uiFont, uiBrush, new Point(312, 320));
                                        g.DrawString("Level: " + activeList[selectedPet].Level.ToString(), uiFont, uiBrush, new Point(312, 358));

                                        g.DrawString(countdownCounter.ToString(), new Font(fontFamily, 32, FontStyle.Bold), uiBrush, new Point(455 - (int)g.MeasureString(countdownCounter.ToString(), new Font(fontFamily, 32, FontStyle.Bold)).Width / 2, 4));

                                        g.DrawString("XP:", uiFont, uiBrush, new Point(312, 390));
                                        System.Drawing.Brush b2 = new SolidBrush(System.Drawing.Color.Blue);
                                        System.Drawing.Brush b3 = new SolidBrush(System.Drawing.Color.Black);
                                        int distance = 360;
                                        double cap = 0;
                                        for (int i = 0; i < activeList[selectedPet].Level; i++)
                                        {
                                            cap += (500 * (i + 1));
                                        }
                                        distance = (int)((double)distance * (double)activeList[selectedPet].CurrentXP / cap);
                                        g.DrawLine(new System.Drawing.Pen(b2, 22), new Point(365, 406), new Point(365 + distance, 406));
                                        g.DrawLine(new System.Drawing.Pen(b3, 2), new Point(725, 360), new Point(725, 417));
                                        g.DrawString("NEXT LEVEL", uiFont, uiBrush, new Point(550, 358));

                                        g.DrawImage(activeList[selectedPet].DisplayImage, 84, 232, 148, 176);
                                        g.DrawImage(enemy.DisplayImage, 564, 52, 148, 176);

                                        if (!captureEnabled)
                                        {
                                            g.DrawImage(images["cage"], 445, 203, 32, 32);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tc_KeyDown(object sender, KeyEventArgs e)
        {
            if (tc.SelectedIndex == 0)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    tc.SelectedIndex = 1;
                    mp.Pause();
                    collisionChecker.Enabled = false;
                    gameLoop.Enabled = false;
                    petMover.Enabled = false;
                }
                switch (e.KeyCode)
                {
                    //Move up
                    case (Keys.W):
                        movingDirectionUD = (int)Moving.Up;
                        p.DisplayImage = images["playerUp"];
                        break;
                    //Move Down
                    case (Keys.S):
                        movingDirectionUD = (int)Moving.Down;
                        p.DisplayImage = images["playerDown"];
                        break;
                    //Move Left
                    case (Keys.A):
                        movingDirectionLR = (int)Moving.Left;
                        p.DisplayImage = images["playerLeft"];
                        break;
                    //Move Right
                    case (Keys.D):
                        movingDirectionLR = (int)Moving.Right;
                        p.DisplayImage = images["playerRight"];
                        break;
                }
                switch (e.KeyData)
                {
                    case (Keys.Up):
                        movingDirectionUD = (int)Moving.Up;
                        p.DisplayImage = images["playerUp"];
                        break;
                    case (Keys.Down):
                        movingDirectionUD = (int)Moving.Down;
                        p.DisplayImage = images["playerDown"];
                        break;
                    case (Keys.Left):
                        movingDirectionLR = (int)Moving.Left;
                        p.DisplayImage = images["playerLeft"];
                        break;
                    case (Keys.Right):
                        movingDirectionLR = (int)Moving.Right;
                        p.DisplayImage = images["playerRight"];
                        break;
                }
            }
            else if (tc.SelectedIndex == 1)
            {
                if (e.KeyCode.Equals(Keys.W) || e.KeyData.Equals(Keys.Up))
                {
                    menuSelection--;
                    if (menuSelection < 0)
                    {
                        menuSelection = 0;
                    }

                }
                if (e.KeyCode.Equals(Keys.S) || e.KeyData.Equals(Keys.Down))
                {
                    menuSelection++;
                    if (menuSelection > 5)
                    {
                        menuSelection = 5;
                    }
                }
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    tc.SelectedIndex = 0;
                    collisionChecker.Enabled = true;
                    petMover.Enabled = true;
                    gameLoop.Enabled = true;
                    mp.Play();
                }
                menuScreen.Invalidate();
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (menuSelection == (int)MenuSelection.PlayerStats)
                    {
                        if (!testModeActive)
                        {
                            try
                            {
                                using (SqlConnection conn = new SqlConnection(GoldTeamRules.Properties.Settings.Default.cnDb))
                                {
                                    conn.Open();
                                    using (SqlCommand command = new SqlCommand("Select wins, losses From Logins Where UserID = @id", conn))
                                    {
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@id", userID);
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                if (reader.HasRows)
                                                {
                                                    afterBattleMessages.Clear();
                                                    afterBattleMessages.Add("Your record is " + reader[0] + "-" + reader[1] + ".");
                                                    frmAfterBattle frm = new frmAfterBattle();
                                                    frm.ShowDialog();
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message.ToString());
                            }
                        }
                        else
                        {
                            afterBattleMessages.Clear();
                            afterBattleMessages.Add("Player stats requires a server connection.");
                            frmAfterBattle frm = new frmAfterBattle();
                            frm.ShowDialog();
                        }
                    }
                    if (menuSelection == (int)MenuSelection.ViewPets)
                    {
                        frmPetJournal frm = new frmPetJournal();
                        frm.ShowDialog();
                        Focus();
                        if (!testModeActive)
                        {
                            SavePets();
                        }
                    }
                    if (menuSelection == (int)MenuSelection.EditRoster)
                    {
                        frmRoster frm = new frmRoster();
                        frm.ShowDialog();
                        activeList = new List<Pet>(3);
                        for (int i = 0; i < petList.Count; i++)
                        {
                            if (petList[i].RosterSlot != -1)
                            {
                                activeList.Add(petList[i]);
                            }
                        }
                        for (int i = 0; i < activeList.Count; i++)
                        {
                            for (int j = i + 1; j < activeList.Count; j++)
                            {
                                if (activeList[j].RosterSlot < activeList[i].RosterSlot)
                                {
                                    Pet temp = activeList[i];
                                    activeList[i] = activeList[j];
                                    activeList[j] = temp;
                                }
                            }
                        }
                    }
                    if (menuSelection == (int)MenuSelection.Log)
                    {
                        if (!testModeActive)
                        {
                            frmReport report = new frmReport();
                            report.ShowDialog();
                        }
                        else
                        {
                            afterBattleMessages.Clear();
                            afterBattleMessages.Add("Combat log requires a server connection.");
                            frmAfterBattle frm = new frmAfterBattle();
                            frm.ShowDialog();
                        }
                    }
                    if (menuSelection == (int)MenuSelection.Exit)
                    {
                        //Saving to Database
                        if (!testModeActive)
                        {
                            SavePets();
                            SaveBattleLog();
                            SaveStats();
                        }
                        this.Close();
                    }
                    if (menuSelection == (int)MenuSelection.Tutorial)
                    {
                        tc.SelectedIndex = 3;
                        tutorialScreen.BackgroundImage = images["tutorial1"];
                    }
                }
            }

            //Battle Screen Input Code
            else if (tc.SelectedIndex == 2)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    if (!parentMenu && !displayDamage)
                    {
                        parentMenu = true;
                        abilityMenu = false;
                        petMenu = false;
                        battleScreen.Invalidate();
                    }
                    else if (parentMenu && !displayDamage)
                    {
                        frmForfeit frm = new frmForfeit();
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (enemy.CurrentHP < enemy.HP)
                            {
                                wildPets[enemyIndex].Location = new Point(10000, 10000);
                            }
                            tc.SelectedIndex = 0;
                            gameLoop.Enabled = true;
                            petMover.Enabled = true;
                            invincibilitySeconds.Enabled = true;
                            invincibilityBlinker.Enabled = true;
                            battleLoop.Enabled = false;
                            movingDirectionLR = (int)Moving.Stop;
                            movingDirectionUD = (int)Moving.Stop;
                        }
                    }
                }
                //When in the parent menu (aka. main menu [fight, capture, pets, pass])
                else if (parentMenu)
                {
                    if (e.KeyCode.Equals(Keys.W) || e.KeyData.Equals(Keys.Up))
                    {
                        battleSelection -= 2;
                        if (battleSelection < 0)
                        {
                            battleSelection = 0;
                        }
                        if (battleSelection == 1 && !captureActive)
                        {
                            battleSelection = 0;
                        }

                    }
                    if (e.KeyCode.Equals(Keys.S) || e.KeyData.Equals(Keys.Down))
                    {
                        battleSelection += 2;
                        if (battleSelection > 3)
                        {
                            battleSelection = 3;
                        }
                    }
                    if (e.KeyCode.Equals(Keys.A) || e.KeyData.Equals(Keys.Left))
                    {
                        battleSelection--;
                        if (battleSelection < 0)
                        {
                            battleSelection = 0;
                        }
                        if (battleSelection == 1 && !captureActive)
                        {
                            battleSelection = 0;
                        }

                    }
                    if (e.KeyCode.Equals(Keys.D) || e.KeyData.Equals(Keys.Right))
                    {
                        battleSelection++;
                        if (battleSelection > 3)
                        {
                            battleSelection = 3;
                        }
                        if (battleSelection == 1 && !captureActive)
                        {
                            battleSelection = 2;
                        }
                    }

                    //Selecting menu option
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        parentMenu = false;
                        if (battleSelection == (int)BattleSelection.Abilities)
                        {
                            abilitySelection = 0;
                            abilityMenu = true;
                        }
                        else if (battleSelection == (int)BattleSelection.Pets)
                        {
                            petSelection = 0;
                            if (selectedPet == 0)
                            {
                                for(int i = 1; i < frmMain.petList.Count; i++)
                                {
                                    if(frmMain.petList[i].CurrentHP > 0)
                                    {
                                        petSelection = i;
                                        break;
                                    }
                                }
                            }
                            petMenu = true;
                            SendKeys.Send("W");
                        }
                        else if (battleSelection == (int)BattleSelection.Capture)
                        {
                            messages.Clear();
                            messages.Add("You attempted to capture!");
                            battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                            battleLog[roundNum - 1, 1] = activeList[selectedPet].Name;
                            battleLog[roundNum - 1, 2] = "Capture";                           

                            Random r = new Random();
                            if (r.Next(100) > 0)
                            {
                                petCaptured = true;
                                messages.Add("You captured the pet!");
                                battleLog[roundNum - 1, 3] = "Success";
                                battleLog[roundNum - 1, 4] = enemy.Name;
                                petList.Add(enemy);
                                AddCapturedPet(enemy);
                                displayDamage = true;
                                damageDisplayer.Enabled = true;
                            }
                            else
                            {
                                messages.Add("You failed!");
                                battleLog[roundNum - 1, 3] = "Failure";
                                battleLog[roundNum - 1, 4] = enemy.Name;
                                roundNum++;
                                battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                                battleLog[roundNum - 1, 1] = enemy.Name;
                                
                                Ability enemyAbility = enemy.abilities[r.Next(6)];
                                messages.Add(enemy.Name + " used " + enemyAbility.Name + "!");
                                battleLog[roundNum - 1, 2] = enemyAbility.Name;
                                bool onTarget = false;
                                if (enemyAbility.Accuracy >= r.Next(100))
                                {
                                    onTarget = true;
                                }
                                if (onTarget)
                                {
                                    activeList[selectedPet].CurrentHP -= (enemy.Attack + enemy.SelectedAbility.Damage) / r.Next(5, 7);
                                    messages.Add("The attack hit!");
                                    battleLog[roundNum - 1, 3] = "Success";
                                }
                                else
                                {
                                    messages.Add("The attack missed!");
                                    battleLog[roundNum - 1, 3] = "Failure";
                                }
                                battleLog[roundNum - 1, 4] = enemy.Name;
                            }

                            messageSelection = 0;
                            displayDamage = true;
                            damageDisplayer.Enabled = true;
                        }
                        else if (battleSelection == (int)BattleSelection.Pass)
                        {
                            messages.Add("You passed your turn!");
                            battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                            battleLog[roundNum - 1, 1] = activeList[selectedPet].Name;
                            battleLog[roundNum - 1, 2] = "Pass Turn";
                            battleLog[roundNum - 1, 3] = "Success";
                            battleLog[roundNum - 1, 4] = enemy.Name;
                            
                            roundNum++;
                            Ability enemyAbility = enemy.abilities[r.Next(6)];
                            messages.Add(enemy.Name + " used " + enemyAbility.Name + "!");
                            battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                            battleLog[roundNum - 1, 1] = enemy.Name;
                            battleLog[roundNum - 1, 0] = enemyAbility.Name;

                            bool onTarget = false;
                            if (enemyAbility.Accuracy >= r.Next(100))
                            {
                                onTarget = true;
                            }
                            if (onTarget)
                            {
                                activeList[selectedPet].CurrentHP -= (enemy.Attack + enemyAbility.Damage) / r.Next(5, 7);
                                messages.Add("The attack hit!");
                                battleLog[roundNum - 1, 3] = "Success";
                            }
                            else
                            {
                                messages.Add("The attack missed!");
                                battleLog[roundNum - 1, 3] = "Failure";
                            }
                            battleLog[roundNum - 1, 4] = activeList[selectedPet].Name;

                            displayDamage = true;
                            damageDisplayer.Enabled = true;
                            messageSelection = 0;
                        }
                    }
                    battleScreen.Invalidate();
                    battleScreen.Update();
                }

                //When in the move menu (selected fight from parent menu)
                else if (abilityMenu)
                {
                    if (e.KeyCode.Equals(Keys.W) || e.KeyData.Equals(Keys.Up))
                    {
                        abilitySelection -= 2;
                        if (abilitySelection < 0)
                        {
                            abilitySelection = 0;
                        }

                    }
                    if (e.KeyCode.Equals(Keys.S) || e.KeyData.Equals(Keys.Down))
                    {
                        abilitySelection += 2;
                        if (abilitySelection > 4)
                        {
                            abilitySelection = 4;
                        }
                    }
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        countdownTimer.Enabled = false;
                        abilityMenu = false;
                        Ability playerAbility = activeList[selectedPet].abilities[abilitySelection];
                        Ability enemyAbility = enemy.abilities[r.Next(6)];

                        combatants = new Pet[2];

                        if (activeList[selectedPet].Speed >= enemy.Speed)
                        {
                            playerNum = 0;
                            opponentNum = 1;
                        }
                        else
                        {
                            opponentNum = 0;
                            playerNum = 1;
                        }

                        combatants[playerNum] = activeList[selectedPet];
                        combatants[playerNum].SelectedAbility = playerAbility;

                        combatants[opponentNum] = enemy;
                        combatants[opponentNum].SelectedAbility = enemyAbility;

                        messages.Add(combatants[0].Name + " used " + combatants[0].SelectedAbility.Name + "!");

                        if (TakeTurn(0, 1))
                        {
                            messages.Add("The attack hit!");

                            battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                            battleLog[roundNum - 1, 1] = combatants[0].Name;
                            battleLog[roundNum - 1, 2] = combatants[0].SelectedAbility.Name;
                            battleLog[roundNum - 1, 3] = "Success";
                            battleLog[roundNum - 1, 4] = combatants[1].Name;
                        }
                        else
                        {
                            messages.Add("The attack missed!");

                            battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                            battleLog[roundNum - 1, 1] = combatants[0].Name;
                            battleLog[roundNum - 1, 2] = combatants[0].SelectedAbility.Name;
                            battleLog[roundNum - 1, 3] = "Failure";
                            battleLog[roundNum - 1, 4] = combatants[1].Name;
                        }

                        roundNum++;
                        if (combatants[1].CurrentHP > 0)
                        {
                            
                            messages.Add(combatants[1].Name + " used " + combatants[1].SelectedAbility.Name + "!");

                            if (TakeTurn(1, 0))
                            {
                                messages.Add("The attack hit!");

                                battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                                battleLog[roundNum - 1, 1] = combatants[1].Name;
                                battleLog[roundNum - 1, 2] = combatants[1].SelectedAbility.Name;
                                battleLog[roundNum - 1, 3] = "Success";
                                battleLog[roundNum - 1, 4] = combatants[0].Name;
                            }
                            else
                            {
                                messages.Add("The attack missed!");

                                battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                                battleLog[roundNum - 1, 1] = combatants[1].Name;
                                battleLog[roundNum - 1, 2] = combatants[1].SelectedAbility.Name;
                                battleLog[roundNum - 1, 3] = "Failure";
                                battleLog[roundNum - 1, 4] = combatants[0].Name;
                            }
                            roundNum++;
                        }

                        messages.TrimExcess();

                        if (!testModeActive)
                        {
                            SavePets();
                        }
                        displayDamage = true;
                        damageDisplayer.Enabled = true;

                        activeList[selectedPet] = combatants[playerNum];
                        enemy = combatants[opponentNum];
                    }
                    battleScreen.Invalidate();
                    battleScreen.Update();
                }

                else if (petMenu)
                {
                    if (e.KeyCode.Equals(Keys.W) || e.KeyData.Equals(Keys.Up))
                    {
                        petSelection--;
                        if (petSelection < 0)
                        {
                            petSelection = 0;
                        }
                        if (selectedPet == 1)
                        {
                            petSelection = 0;
                        }
                        if(activeList[petSelection].CurrentHP <= 0)
                        {
                            petSelection++;
                        }
                        if (petSelection == selectedPet)
                        {
                            petSelection++;
                        }                                         
                    }
                    if (e.KeyCode.Equals(Keys.S) || e.KeyData.Equals(Keys.Down))
                    {
                        petSelection++;                    
                        if (petSelection > 2)
                        {
                            petSelection = 2;
                        }
                        if (selectedPet == 1)
                        {
                            petSelection = 2;
                        }
                        if (activeList[petSelection].CurrentHP <= 0)
                        {
                            petSelection--;
                        }
                        if (petSelection == selectedPet)
                        {
                            petSelection--;
                        }
                    }
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                        battleLog[roundNum - 1, 1] = activeList[selectedPet].Name;
                        
                        //Switch pets, enemy still gets to attack
                        selectedPet = petSelection;
                        petMenu = false;
                        messages.Clear();
                        messages.Add("You sent out " + activeList[selectedPet].Name);
                        
                        battleLog[roundNum - 1, 2] = "Switch Pet";
                        battleLog[roundNum - 1, 3] = "Success";
                        battleLog[roundNum - 1, 4] = activeList[selectedPet].Name;

                        roundNum++;
                        Ability enemyAbility = enemy.abilities[r.Next(6)];
                        messages.Add(enemy.Name + " used " + enemyAbility.Name + "!");

                        battleLog[roundNum - 1, 0] = DateTime.Now.ToString();
                        battleLog[roundNum - 1, 1] = enemy.Name;
                        battleLog[roundNum - 1, 2] = enemyAbility.Name;
                        
                        opponentNum = 2;
                        bool onTarget = false;
                        if (enemyAbility.Accuracy >= r.Next(100))
                        {
                            onTarget = true;
                        }
                        if (onTarget)
                        {
                            activeList[selectedPet].CurrentHP -= (enemy.Attack + enemyAbility.Damage) / r.Next(5, 7);
                            messages.Add("The attack hit!");
                            battleLog[roundNum - 1, 3] = "Success";
                        }
                        else
                        {
                            messages.Add("The attack missed!");
                            battleLog[roundNum - 1, 3] = "Failure";
                        }
                        battleLog[roundNum - 1, 4] = activeList[selectedPet].Name;

                        displayDamage = true;
                        damageDisplayer.Enabled = true;
                        messageSelection = 0;
                    }
                    battleScreen.Update();
                    battleScreen.Invalidate();
                }
                else if (displayDamage && e.KeyCode.Equals(Keys.Enter))
                {
                    messageSelection++;
                }
            }

            //Tutorial Screen Input Code
            else if (tc.SelectedIndex == 3)
            {
                if (tutorialScreen.BackgroundImage.Equals(images["tutorial1"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial2"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial2"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial3"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial3"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial4"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial4"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial5"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial5"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial6"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial6"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial7"];
                    }
                }
                else if (tutorialScreen.BackgroundImage.Equals(images["tutorial7"]))
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tutorialScreen.BackgroundImage = images["tutorial8"];
                    }
                }
                else
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        tc.SelectedIndex = 0;
                        if (!gameLoop.Enabled)
                        {
                            collisionChecker.Enabled = true;
                            petMover.Enabled = true;
                            gameLoop.Enabled = true;
                        }
                    }
                }
            }
        }

        private void AddCapturedPet(Pet enemy)
        {
            string _cnDB = GoldTeamRules.Properties.Settings.Default.cnDb;

            if (!testModeActive)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_cnDB))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("dbo.usp_Add_New_CapturedPet", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@petID", enemy.PetID);
                        command.Parameters.AddWithValue("@currentXP", enemy.CurrentXP);
                        command.Parameters.AddWithValue("@currentHP", enemy.CurrentHP);
                        command.Parameters.AddWithValue("@rosterSlot", enemy.RosterSlot);
                        int numRows = command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
        }

        private void healTimer_Tick(object sender, EventArgs e)
        {
            if (counter == 1)
            {
                healTimer.Enabled = false;
                frmPetJournal.btnHeal.Enabled = true;
            }
            counter = 0;
            frmPetJournal.btnHeal.Enabled = false;
            if (healTimer.Enabled)
            {
                counter++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tc.SelectedIndex = 1;
            mp.Pause();
            collisionChecker.Enabled = false;
            petMover.Enabled = false;
            gameLoop.Enabled = false;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (movingDirectionLR == (int)Moving.Left)
            {
                if (p.DisplayImage.Equals(images["playerLeft"]))
                {
                    p.DisplayImage = images["playerWalkingLeft"];
                }
                else if (p.DisplayImage.Equals(images["playerWalkingLeft"]))
                {
                    p.DisplayImage = images["playerLeft"];
                }
            }
            else if (movingDirectionLR == (int)Moving.Right)
            {
                if (p.DisplayImage.Equals(images["playerRight"]))
                {
                    p.DisplayImage = images["playerWalkingRight"];
                }
                else if (p.DisplayImage.Equals(images["playerWalkingRight"]))
                {
                    p.DisplayImage = images["playerRight"];
                }
            }
        }

        private void tc_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.W) || e.KeyData.Equals(Keys.Up))
            {
                movingDirectionUD = (int)Moving.Stop;
                p.DisplayImage = images["playerUp"];
            }
            else if (e.KeyCode.Equals(Keys.S) || e.KeyData.Equals(Keys.Down))
            {
                movingDirectionUD = (int)Moving.Stop;
                p.DisplayImage = images["playerDown"];
            }
            else if (e.KeyCode.Equals(Keys.A) || e.KeyData.Equals(Keys.Left))
            {
                movingDirectionLR = (int)Moving.Stop;
                p.DisplayImage = images["playerLeft"];
            }
            else if (e.KeyCode.Equals(Keys.D) || e.KeyData.Equals(Keys.Right))
            {
                movingDirectionLR = (int)Moving.Stop;
                p.DisplayImage = images["playerRight"];
            }
        }

        private void tutorialScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (tutorialScreen.BackgroundImage.Equals(images["tutorial1"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.White), new Point(385, 550));
            }
            else if(tutorialScreen.BackgroundImage.Equals(images["tutorial2"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.White), new Point(385, 550));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial3"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.White), new Point(385, 550));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial4"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.White), new Point(385, 550));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial5"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), new Point(385, 550));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial6"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), new Point(385, 510));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial7"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.White), new Point(385, 550));
            }
            else if (tutorialScreen.BackgroundImage.Equals(images["tutorial8"]))
            {
                g.DrawString("Press ENTER to continue", new Font(new System.Drawing.FontFamily("Lucida Sans"), 24, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), new Point(385, 550));
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownCounter == 0)
            {
                countdownTimer.Enabled = false;
                messages.Clear();
                messages.Add("You passed your turn!");
                Ability enemyAbility = enemy.abilities[r.Next(6)];
                messages.Add(enemy.Name + " used " + enemyAbility.Name + "!");
                bool onTarget = false;
                if (enemyAbility.Accuracy >= r.Next(100))
                {
                    onTarget = true;
                }
                if (onTarget)
                {
                    activeList[selectedPet].CurrentHP -= (enemy.Attack + enemyAbility.Damage) / r.Next(5, 7);
                    messages.Add("The attack hit!");
                }
                else
                {
                    messages.Add("The attack missed!");
                }

                parentMenu = false;
                displayDamage = true;
                damageDisplayer.Enabled = true;
                messageSelection = 0;
                battleScreen.Invalidate();
            }
            else
            {
                countdownCounter--;
            }
            battleScreen.Invalidate();
        }
    }
}