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
        private Smer smer;
        public SmerForm(Smer smer)
        {
            this.smer = smer;
            InitializeComponent();
            if(smer != null)
            {
                popuniPolja();
            }
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
            if(smer == null)
            {
                smer = new Smer(textBoxID.Text, textBoxIme.Text, Convert.ToDateTime(dateTimePicker1.Value), richTextBoxOpis.Text);
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


            //Console.WriteLine(DataManger.getSmers().Count);
            //foreach(Smer s in DataManger.getSmers())
            //{
            //    Console.WriteLine(s.ID + "  " + s.Ime);
            //}


        }

        private void buttonDodajPredmet_Click(object sender, EventArgs e)
        {
            PredmetForm pf = new PredmetForm(null, smer);
            pf.ShowDialog();
        }
    }

}
