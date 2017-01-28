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
    public partial class frmRoster : Form
    {
        public frmRoster()
        {
            InitializeComponent();
        }

        internal static List<Pet> list;
        internal static int stay, go;

        private void frmRoster_Load(object sender, EventArgs e)
        {
            list = new List<Pet>();
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < frmMain.petList.Count; z++)
                {
                    if (frmMain.petList[z].RosterSlot == (i + 1))
                    {
                        list.Add(frmMain.petList[z]);
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                int z = i + 1;
                foreach (ProgressBar pb in this.Controls.OfType<ProgressBar>())
                {
                    if (pb.Name.Equals("xp" + (z)))
                    {
                        int cap = 0;
                        for (int y = 0; y < list[i].Level; y++)
                        {
                            cap += (500 * (y + 1));
                        }
                        pb.Maximum = cap;
                        pb.Value = list[i].CurrentXP;
                    }
                }
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {

                    if (pb.Name.Equals("pb" + (z)))
                    {
                        pb.BackgroundImage = list[i].DisplayImage;
                    }

                }
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    if (tb.Name.Equals("tbtLevel" + z))
                    {
                        tb.Text = list[i].Level.ToString();
                    }
                    else if (tb.Name.Equals("tbtHP" + z))
                    {
                        tb.Text = list[i].CurrentHP + "/" + list[i].HP.ToString();
                    }
                }
                foreach (Label l in this.Controls.OfType<Label>())
                {
                    if (l.Name.Equals("lblPet" + z))
                    {
                        l.Text = list[i].Name;
                    }
                }
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (cb.Name.Equals("cb" + (x + 1) + "pet" + z))
                        {
                            int y;
                            int w;
                            if (x == 0)
                            {
                                w = 0;
                                y = 1;
                            }
                            else if (x == 1)
                            {
                                w = 2;
                                y = 3;
                            }
                            else
                            {
                                w = 4;
                                y = 5;
                            }
                            cb.Items.Add(list[i].abilities[w].Name + " | " + list[i].abilities[w].Damage + " | " + list[i].abilities[w].Accuracy + "%");
                            cb.Items.Add(list[i].abilities[y].Name + " | " + list[i].abilities[y].Damage + " | " + list[i].abilities[y].Accuracy + "%");
                            cb.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (frmMain.petList.Count > 3)
            {
                frmPetRoster frm = new frmPetRoster();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < frmMain.petList.Count; i++)
                    {
                        if (frmMain.petList[i].Equals(list[0]))
                        {
                            go = i;
                        }
                    }
                    frmMain.petList[stay].RosterSlot = 1;
                    frmMain.petList[go].RosterSlot = -1;
                }
            }
            updateCBs();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (frmMain.petList.Count > 3)
            {
                frmPetRoster frm = new frmPetRoster();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < frmMain.petList.Count; i++)
                    {
                        if (frmMain.petList[i].Equals(list[1]))
                        {
                            go = i;
                        }
                    }
                    frmMain.petList[stay].RosterSlot = 2;
                    frmMain.petList[go].RosterSlot = -1;
                }
            }
            updateCBs();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (frmMain.petList.Count > 3)
            {
                frmPetRoster frm = new frmPetRoster();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < frmMain.petList.Count; i++)
                    {
                        if (frmMain.petList[i].Equals(list[2]))
                        {
                            go = i;
                        }
                    }
                    frmMain.petList[stay].RosterSlot = 3;
                    frmMain.petList[go].RosterSlot = -1;
                }
            }
            updateCBs();
        }

        private void updateCBs()
        {
            list.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < frmMain.petList.Count; z++)
                {
                    if (frmMain.petList[z].RosterSlot == (i + 1))
                    {
                        list.Add(frmMain.petList[z]);
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                int z = i + 1;
                foreach (ProgressBar pb in this.Controls.OfType<ProgressBar>())
                {
                    if (pb.Name.Equals("xp" + (z)))
                    {
                        int cap = 0;
                        for (int y = 0; y < list[i].Level; y++)
                        {
                            cap += (500 * (y + 1));
                        }
                        pb.Maximum = cap;
                        pb.Value = list[i].CurrentXP;
                    }
                }
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
                {

                    if (pb.Name.Equals("pb" + (z)))
                    {
                        pb.BackgroundImage = list[i].DisplayImage;
                    }

                }
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    if (tb.Name.Equals("tbtLevel" + z))
                    {
                        tb.Text = list[i].Level.ToString();
                    }
                    else if (tb.Name.Equals("tbtHP" + z))
                    {
                        tb.Text = list[i].CurrentHP + "/" + list[i].HP.ToString();
                    }
                }
                foreach (Label l in this.Controls.OfType<Label>())
                {
                    if (l.Name.Equals("lblPet" + z))
                    {
                        l.Text = list[i].Name;
                    }
                }
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (cb.Name.Equals("cb" + (x + 1) + "pet" + z))
                        {
                            int y;
                            int w;
                            if (x == 0)
                            {
                                w = 0;
                                y = 1;
                            }
                            else if (x == 1)
                            {
                                w = 2;
                                y = 3;
                            }
                            else
                            {
                                w = 4;
                                y = 5;
                            }
                            cb.Items.Add(list[i].abilities[w].Name + " | " + list[i].abilities[w].Damage + " | " + list[i].abilities[w].Accuracy + "%");
                            cb.Items.Add(list[i].abilities[y].Name + " | " + list[i].abilities[y].Damage + " | " + list[i].abilities[y].Accuracy + "%");
                            cb.SelectedIndex = 0;
                        }
                    }
                }
            }
            foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
            {
                cb.Items.Clear();
            }

            for (int i = 0; i < 3; i++)
            {
                int z = i + 1;
                foreach (ComboBox cb in this.Controls.OfType<ComboBox>())
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (cb.Name.Equals("cb" + (x + 1) + "pet" + z))
                        {
                            int y;
                            int w;
                            if (x == 0)
                            {
                                w = 0;
                                y = 1;
                            }
                            else if (x == 1)
                            {
                                w = 2;
                                y = 3;
                            }
                            else
                            {
                                w = 4;
                                y = 5;
                            }
                            cb.Items.Add(list[i].abilities[w].Name + " | " + list[i].abilities[w].Damage + " | " + list[i].abilities[w].Accuracy + "%");
                            cb.Items.Add(list[i].abilities[y].Name + " | " + list[i].abilities[y].Damage + " | " + list[i].abilities[y].Accuracy + "%");
                            cb.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void cb1pet1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cb1pet1.SelectedIndex == 1)
            {
                Ability temp = list[0].abilities[0];
                list[0].abilities[0] = list[0].abilities[1];
                frmMain.activeList[0].abilities[1] = temp;
                updateCBs();
            }
        }

        private void cb2pet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb2pet1.SelectedIndex == 1)
            {
                Ability temp = list[0].abilities[2];
                list[0].abilities[2] = list[0].abilities[3];
                list[0].abilities[3] = temp;
                updateCBs();
            }
        }

        private void cb3pet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb3pet1.SelectedIndex == 1)
            {
                Ability temp = list[0].abilities[4];
                list[0].abilities[4] = list[0].abilities[5];
                list[0].abilities[5] = temp;
                updateCBs();
            }
        }

        private void cb1pet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1pet2.SelectedIndex == 1)
            {
                Ability temp = list[1].abilities[0];
                list[1].abilities[0] = list[1].abilities[1];
                list[1].abilities[1] = temp;
                updateCBs();
            }
        }

        private void cb2pet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb2pet2.SelectedIndex == 1)
            {
                Ability temp = list[1].abilities[2];
                list[1].abilities[2] = list[1].abilities[3];
                list[1].abilities[3] = temp;
                updateCBs();
            }
        }

        private void cb3pet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb3pet2.SelectedIndex == 1)
            {
                Ability temp = list[1].abilities[4];
                list[1].abilities[4] = list[1].abilities[5];
                list[1].abilities[5] = temp;
                updateCBs();
            }
        }

        private void cb1pet3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1pet3.SelectedIndex == 1)
            {
                Ability temp = list[2].abilities[0];
                list[2].abilities[0] = list[2].abilities[1];
                list[2].abilities[1] = temp;
                updateCBs();
            }
        }

        private void cb2pet3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb2pet3.SelectedIndex == 1)
            {
                Ability temp = list[2].abilities[2];
                list[0].abilities[2] = list[0].abilities[3];
                list[0].abilities[3] = temp;
                updateCBs();
            }
        }

        private void cb3pet3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb3pet3.SelectedIndex == 1)
            {
                Ability temp = list[2].abilities[4];
                list[2].abilities[4] = list[2].abilities[5];
                list[2].abilities[5] = temp;
                updateCBs();
            }
        }

        private void btnPet1To2_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(1))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(2))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for(int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 2;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 1;
                }
            }

            updateCBs();
        }

        private void btnPet1to3_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(1))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(3))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 3;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 1;
                }
            }

            updateCBs();
        }

        private void btnPet2To1_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(2))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(1))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 1;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 2;
                }
            }

            updateCBs();
        }

        private void btnPet2To3_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(2))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(3))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 3;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 2;
                }
            }

            updateCBs();
        }

        private void btnPet3To1_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(3))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(1))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 1;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 3;
                }
            }

            updateCBs();
        }

        private void btnPet3To2_Click(object sender, EventArgs e)
        {
            int idIn = 0;
            int idOut = 0;
            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].RosterSlot.Equals(3))
                {
                    idOut = frmMain.petList[i].PetID;
                }
                if (frmMain.petList[i].RosterSlot.Equals(2))
                {
                    idIn = frmMain.petList[i].PetID;
                }
            }

            for (int i = 0; i < frmMain.petList.Count; i++)
            {
                if (frmMain.petList[i].PetID.Equals(idOut))
                {
                    frmMain.petList[i].RosterSlot = 2;
                }
                if (frmMain.petList[i].PetID.Equals(idIn))
                {
                    frmMain.petList[i].RosterSlot = 3;
                }
            }

            updateCBs();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}