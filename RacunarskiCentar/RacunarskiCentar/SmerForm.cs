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
        Action editAction;
        bool actionAdded = false;
        public SmerForm(Smer smer)
        {
            DataControllercs.onAction += ActionExcuted;
            this.smer = smer;
            InitializeComponent();
            Disposed += SmerForm_Disposed;

            if (smer != null)
            {
                editAction = new EditAction(smer);
               
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
            listBoxPredmeti.Items.AddRange(smer.Predmeti.ToArray());

            
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
                smer.Predmeti = listBoxPredmeti.Items.Cast<Predmet>().ToList();

                action = new CreateAction(smer);
              
            }
            else
            {
                action = editAction;
                smer.ID = textBoxID.Text;
                smer.Ime = textBoxIme.Text;
                smer.DatumUvodjenja = Convert.ToDateTime(dateTimePicker1.Value);
                smer.Opis = richTextBoxOpis.Text;
                smer.Predmeti = listBoxPredmeti.Items.Cast<Predmet>().ToList();

               
            }
            if(!actionAdded)
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
            else if (e is DeleteAction)
            {
                Predmet p = e.getGUIObject() as Predmet;
                if (p != null)
                {
                    if (p.SmerPredmeta.Equals(smer))
                    {
                        
                        foreach (object o in listBoxPredmeti.Items)
                        {
                            if((o as Predmet).Equals(e.getGUIObject())){
                                listBoxPredmeti.Items.Remove(o);
                                break;
                            }
                        }
                    }
                }
            }
           
        }
        private void buttonDodajPredmet_Click(object sender, EventArgs e)
        {
            smer.ID = textBoxID.Text;
            PredmetForm pf = new PredmetForm(null, smer);
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK)
            {
                listBoxPredmeti.Items.Add(pf.GetAction().getGUIObject());
            }
            pf.Dispose();
        }

        private void buttonObrisiPredmet_Click(object sender, EventArgs e)
        {
            Predmet p = listBoxPredmeti.SelectedItem as Predmet;
            
            if (p!=null)
            {
                listBoxPredmeti.Items.Remove(p);
            }
            
        }

    }

}
