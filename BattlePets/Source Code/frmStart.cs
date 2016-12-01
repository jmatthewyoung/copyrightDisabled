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
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        internal static List<Pet> startingList;

        private void frmStart_Load(object sender, EventArgs e)
        {
            startingList = new List<Pet>();
            Random r = new Random();
            startingList.Add(new Pet(r.Next(1, 10), 3001, 1, true));
            startingList.Add(new Pet(r.Next(10, 20), 3001, 2, true));
            startingList.Add(new Pet(r.Next(20, 31), 3001, 3, true));

            for(int i = 0; i < 3; i++)
            {
                int z = i + 1;
                foreach(PictureBox pb in this.Controls.OfType<PictureBox>())
                {
                    if(pb.Name.Equals("pb" + (z)))
                    {
                        pb.BackgroundImage = startingList[i].DisplayImage;
                    }
                }
                foreach(Label l in this.Controls.OfType<Label>())
                {
                    for(int x = 0; x < 6; x++)
                    {
                        if(l.Name.Equals("lbl" + (x + 1) + "pet" + z))
                        {
                            l.Text = startingList[i].abilities[x].Name;
                        }
                    }
                    if(l.Name.Equals("lblPet" + z))
                    {
                        l.Text = startingList[i].Name;
                    }
                }
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    if(tb.Name.Equals("tbtLevel" + z))
                    {
                        tb.Text = startingList[i].Level.ToString();
                    }
                    else if (tb.Name.Equals("tbtHP" + z))
                    {
                        tb.Text = startingList[i].CurrentHP + "/" + startingList[i].HP.ToString();
                    }
                    else if (tb.Name.Equals("tbtAtk" + z))
                    {
                        tb.Text = startingList[i].Attack.ToString();
                    }
                    else if (tb.Name.Equals("tbtSpeed" + z))
                    {
                        tb.Text = startingList[i].Speed.ToString();
                    }
                    else if (tb.Name.Equals("tbtRarity" + z))
                    {
                        tb.Text = startingList[i].Rarity.ToString();
                    }
                    else if (tb.Name.Equals("tbtID" + z))
                    {
                        tb.Text = startingList[i].PetID.ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
