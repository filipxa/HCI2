﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RacunarskiCentar.UcionicaForm;

namespace RacunarskiCentar
{
    public partial class PredmetForm : Form
    {
        private Predmet predmet;
        private Smer smer;
        public PredmetForm(Predmet predmet, Smer smer)
        {
            this.smer = smer;
            this.predmet = predmet;
            InitializeComponent();
            if(smer != null)
                textBoxSmer.Text = smer.Ime;
            if(predmet != null)
            {
                popuniPolja();
            }
            popuniOpremaBox();
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
                predmet = new Predmet(textBoxID.Text, textBoxNaziv.Text, smer, richTextBoxOpis.Text, Convert.ToInt32(numericUpDownBrojLjudi), Convert.ToInt32(numericUpDownDuzinaTermina), Convert.ToInt32(numericUpDownBrojTermina));

                action = new CreateAction(predmet);
            }
            else
            {
                action = new EditAction(predmet);
                predmet.ID = textBoxID.Text;
                predmet.Ime = textBoxNaziv.Text;
                predmet.BrLjudi = Convert.ToInt32(numericUpDownBrojLjudi);
                predmet.BrCasova = Convert.ToInt32(numericUpDownDuzinaTermina);
                predmet.BrTermina = Convert.ToInt32(numericUpDownBrojTermina);
                predmet.Opis = richTextBoxOpis.Text;
                predmet.Assets = getUcionicaAssets();
            }

            DataControllercs.addAction(action);
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
            //foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            //{
            //    checkedListBox1.Items.Add(new ComboValue(aset), false);
            //}
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
                // TO-DO: proveriti da li vec postoji id u bazi
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

                //Predmet pp = new Predmet("", "", null, "", -1, -1, -1);
                //DataManger.addObject(pp);

            }
        }

      
    }
}
