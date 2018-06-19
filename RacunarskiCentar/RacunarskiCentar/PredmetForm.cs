﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static RacunarskiCentar.UcionicaForm;

namespace RacunarskiCentar
{
    public partial class PredmetForm : Form
    {
        private Predmet predmet;
        private Smer smer;
        public enum Rezim
        {
            Izmena, Dodavanje, DodavanjeNovomSmeru
        };

        Rezim rezimRada;
        

        public PredmetForm(Predmet predmet, Smer smer)
        {
            this.smer = smer;
            this.predmet = predmet;
            InitializeComponent();
            comboBoxSmer.SelectedValueChanged += ComboBoxSmer_SelectedIndexChanged;

            if (predmet != null)
            {
                popuniPolja();
                comboBoxSmer.Text = predmet.SmerPredmeta.ToString();
                comboBoxSmer.Enabled = false;
                rezimRada = Rezim.Izmena;
            }
            else
            {
                if (smer == null)
                {
                    rezimRada = Rezim.Dodavanje;
                    foreach (Smer s in DataManger.getSmers())
                    {
                        comboBoxSmer.Items.Add(s);
                    }
                    if (comboBoxSmer.Items.Count == 0)
                        comboBoxSmer.Enabled = false;
                    else
                    {
                        comboBoxSmer.SelectedIndex = 0;
                    }
                }
                else
                {
                    rezimRada = Rezim.DodavanjeNovomSmeru;
                    comboBoxSmer.Items.Add(smer);
                    comboBoxSmer.SelectedIndex = 0;
                    comboBoxSmer.Enabled = false;
                }
            }
            popuniOpremaBox();
            KeyPreview = true;
            KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (rezimRada == Rezim.Dodavanje || rezimRada == Rezim.DodavanjeNovomSmeru)
                    {
                        DataManger.goToHelp("dodavanjePredmet");
                    }
                    else
                    {
                        DataManger.goToHelp("izmenaPredmet");
                    }

                }
            };
        }

        private void ComboBoxSmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            smer = (Smer)comboBoxSmer.SelectedItem;
        }

        private void popuniOpremaBox()
        {
            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                bool postoji = false;
                if(predmet != null)
                {
                    postoji = predmet.Assets.Contains(aset);
                }
                checkedListBox1.Items.Add(new ComboValue(aset), postoji);
            }
        }

        private void popuniPolja()
        {
            textBoxID.Text = predmet.ID;
            textBoxNaziv.Text = predmet.Ime;
            numericUpDownBrojLjudi.Value = Convert.ToInt32(predmet.BrLjudi);
            numericUpDownDuzinaTermina.Value = Convert.ToInt32(predmet.BrCasova);
            numericUpDownBrojTermina.Value = Convert.ToInt32(predmet.BrTermina);
            richTextBoxOpis.Text = predmet.Opis;

        }

        public Action GetAction()
        {
            Action action;
            if(predmet == null)
            {
                predmet = new Predmet(textBoxID.Text, textBoxNaziv.Text, smer, richTextBoxOpis.Text, 
                    Convert.ToInt32(numericUpDownBrojLjudi.Value), Convert.ToInt32(numericUpDownDuzinaTermina.Value), 
                    Convert.ToInt32(numericUpDownBrojTermina.Value));
                predmet.Assets = getUcionicaAssets();

                action = new CreateAction(predmet);
            }
            else
            {
                action = new EditAction(predmet);
                predmet.ID = textBoxID.Text;
                predmet.Ime = textBoxNaziv.Text;
                predmet.BrLjudi = Convert.ToInt32(numericUpDownBrojLjudi.Value);
                predmet.BrCasova = Convert.ToInt32(numericUpDownDuzinaTermina.Value);
                predmet.BrTermina = Convert.ToInt32(numericUpDownBrojTermina.Value);
                predmet.Opis = richTextBoxOpis.Text;
                predmet.Assets = getUcionicaAssets();
                predmet.SmerPredmeta = smer;

                
            }
            if (rezimRada==Rezim.Izmena || rezimRada == Rezim.Dodavanje)
            {
                DataControllercs.addAction(action);
            }
            
            return action;
        }

        private HashSet<UcionicaAssets> getUcionicaAssets()
        {
            HashSet<UcionicaAssets> rets = new HashSet<UcionicaAssets>();
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {

                ComboValue item = ((ComboValue)itemChecked);
                rets.Add((UcionicaAssets)item.Value);

            }
            return rets;
        }

        private void PredmetForm_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

        }
        Regex idRegex = new Regex("[a-zA-Z0-9]");

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!idRegex.IsMatch(textBoxID.Text))
            {
                labelID.ForeColor = Color.Red;
            }
            else
            {
                labelID.ForeColor = Color.Black;
            }
        }

        private void textBoxNaziv_Validated(object sender, EventArgs e)
        {
            if(textBoxNaziv.Text.Length == 0 )
            {
                labelNaziv.ForeColor = Color.Red;
            }
            else
            {
                labelNaziv.ForeColor = Color.Black;
            }
        }



        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            int rb = 1;
            string poruka = "";

            if (predmet == null)
            {
               if( DataManger.getPredmetByID(textBoxID.Text)!=null)
                 {
                    poruka += "#" + rb + ": Predmet sa id-em " + textBoxID.Text + " vec postoji..\n";
                    rb++;
                }
            }
            if (textBoxID.Text.Length == 0)
            {
                poruka += "#" + rb + ": Morate uneti ID predmeta.\n";
                rb++;
            }
            if(textBoxNaziv.Text.Length==0)
            {
                labelNaziv.ForeColor = Color.Red;
                poruka += "#" + rb + ": Morate uneti naziv predmeta.\n";
                rb++;
            }
            
            if (poruka.Length > 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            GetAction();
          

        }


    }
}
