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
            this.checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            this.checkBox1.Checked = true;
            this.checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            textBoxCena.Text = "0";
            if(software != null)
            {
                popuniPolja();
            }
        }

        private void popuniPolja()
        {
            textBoxID.Text = software.ID;
            textBoxIme.Text = software.Ime;
            bool prviCheckBox = software.Assets.Contains(UcionicaAssets.windows);
            bool drugiCheckBox = software.Assets.Contains(UcionicaAssets.linux);
            checkBox1.Checked = prviCheckBox;
            checkBox2.Checked = drugiCheckBox;
            textBoxProizvodjac.Text = software.Proizvodjac;
            textBoxURL.Text = software.URL;
            textBoxGodina.Text = software.Godina;
            textBoxCena.Text = Convert.ToString(software.Cena);
            richTextBoxOpis.Text = software.Opis;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
          
            if(!checkBox1.Checked && !checkBox2.Checked)
            {
                labelOS.ForeColor = Color.Red;
            }
            else
            {
                labelOS.ForeColor = Color.Black;
            }
            

        }

        public Action GetAction()
        {
            Action action;
            if(software == null)
            {
                software = new Software(textBoxID.Text, textBoxIme.Text, 
                    textBoxProizvodjac.Text, textBoxURL.Text, textBoxGodina.Text, Convert.ToDouble(textBoxCena.Text), richTextBoxOpis.Text);
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
        Regex idRegex = new Regex("[a-zA-Z0-9]+");
        Regex cenaRegex = new Regex("^[0-9]*$");
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

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            int rb = 1;
            string poruka = "";

            if (software == null)
            {
                foreach (Software s in DataManger.getSoftware())
                {
                    if (s.ID.Equals(textBoxID.Text))
                    {
                        poruka += "#" + rb + ": Sofver sa id-em " + textBoxID.Text + " vec postoji..\n";
                        rb++;
                        break;
                    }
                }
            }
            if (textBoxID.Text.Length == 0)
            {
                poruka += "#" + rb +": Morate uneti ID softvera.\n";
                rb++;
            }
            if(textBoxIme.Text.Length == 0)
            {
                labelIme.ForeColor = Color.Red;
                poruka += "#" + rb + ": Morate uneti naziv softvera.\n";
                rb++;
            }
            if(!checkBox1.Checked && !checkBox2.Checked)
            {
                labelOS.ForeColor = Color.Red;
                poruka += "#" + rb + ": Morate odabrati bar jedan operativni sistem.";
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

        private void textBoxCena_Validated(object sender, EventArgs e)
        {

            try
            {
                Convert.ToDouble(textBoxCena.Text);
            }
            catch (Exception)
            {

                textBoxCena.Text = "0";
            }
        }
    }
}
