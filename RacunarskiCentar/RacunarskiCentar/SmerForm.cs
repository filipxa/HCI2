using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class SmerForm : Form
    {
        bool isCreate = false;
        private Smer smer;
        public SmerForm(Smer smer)
        {
            DataControllercs.onAction += ActionExcuted;
            this.smer = smer;
            InitializeComponent();
            Disposed += SmerForm_Disposed;
            if(smer != null)
            {
                popuniPolja();
            }else
            {
                isCreate = true;
                this.smer = new Smer();
            }
        }

        private void SmerForm_Disposed(object sender, EventArgs e)
        {
            DataControllercs.onAction -= ActionExcuted;
        }

        private void popuniPolja()
        {
            textBoxID.Text = smer.ID;
            textBoxIme.Text = smer.Ime;
            dateTimePicker1.Value = Convert.ToDateTime(smer.DatumUvodjenja);
            richTextBoxOpis.Text = smer.Opis;
            listBoxPredmeti.DataSource = smer.Predmeti;
        }

        public Action GetAction()
        {
            Action action;
            if(isCreate)
            {
                smer.ID = textBoxID.Text;
                smer.Ime = textBoxIme.Text;
                smer.DatumUvodjenja = Convert.ToDateTime(dateTimePicker1.Value);
                smer.Opis = richTextBoxOpis.Text;
                smer.Predmeti.Clear();
                foreach (Predmet p in listBoxPredmeti.Items)
                {
                    smer.Predmeti.Add(p);
                }

                action = new CreateAction(smer);
            }
            else
            {
                action = new EditAction(smer);
                smer.ID = textBoxID.Text;
                smer.Ime = textBoxIme.Text;
                smer.DatumUvodjenja = Convert.ToDateTime(dateTimePicker1.Value);
                smer.Opis = richTextBoxOpis.Text;
                foreach(Predmet p in listBoxPredmeti.Items)
                {
                    smer.Predmeti.Add(p);
                }
               
            }
            DataControllercs.addAction(action);
            return action;
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

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {

            int rb = 1;
            string poruka = "";
            if(smer == null)
            {
                foreach(Smer s in DataManger.getSmers())
                {
                    if(s.ID.Equals(smer.ID))
                    {
                        poruka += "#" + rb + ": Smer sa id-em " + textBoxID.Text + " vec postoji..\n";
                        rb++;
                        break;
                    }
                }
            }
            if (textBoxID.Text.Length == 0)
            {
                poruka += "#" + rb + ": Morate uneti ID softvera.\n";
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

        private void ActionExcuted(object sender, Action e)
        {
            if (e is CreateAction)
            {

                Predmet p = e.getGUIObject() as Predmet;
                if (p != null)
                {
                    if (p.SmerPredmeta.Equals(smer))
                    {
                        listBoxPredmeti.Items.Add(p);
                    }
                }
            }
           
        }
        private void buttonDodajPredmet_Click(object sender, EventArgs e)
        {
            PredmetForm pf = new PredmetForm(null, smer);
            pf.ShowDialog();
            
        }
    }

}
