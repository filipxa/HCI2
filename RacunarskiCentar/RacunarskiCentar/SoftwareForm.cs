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
    public partial class SoftwareForm : Form
    {
        private Software software;

        public SoftwareForm(Software software)
        {
            this.software = software;
            InitializeComponent();
        }

        public Action GetAction()
        {
            Action action;
            if(software == null)
            {
                software = new Software(textBoxID.Text, textBoxIme.Text, textBoxProizvodjac.Text, textBoxURL.Text, textBoxGodina.Text, Convert.ToDouble(textBoxCena.Text), richTextBoxOpis.Text);
                action = new CreateAction(software);
            }
            else
            {
                action = new EditAction(software);
                software.ID = textBoxID.Text;
                software.Ime = textBoxIme.Text;
                software.Proizvodjac = textBoxProizvodjac.Text;
                software.URL = textBoxURL.Text;
                software.Godina = textBoxGodina.Text;
                software.Cena = Convert.ToDouble(textBoxCena.Text);
                software.Opis = richTextBoxOpis.Text;
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
            if(textBoxID.Text.Length == 0)
            {
                poruka += "#" + rb +": Morate uneti ID softvera.\n";
                rb++;
            }
            if(!checkBox1.Checked && !checkBox2.Checked)
            {
                poruka += "#" + rb + ": Morate odabrati bar jedan operativni sistem.";
                rb++;
            }
            if (poruka.Length > 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }
        }

        private void textBoxIme_Validated(object sender, EventArgs e)
        {
            if (textBoxIme.Text.Length == 0)
            {
                labelIme.ForeColor = Color.Red;
            }
            else
            {
                labelIme.ForeColor = Color.Black;
            }
        }

       


       


    }
}
