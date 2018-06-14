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
    public partial class SoftwareFilterForm : Form
    {
        public SoftwareFilterForm()
        {
            InitializeComponent();
        }

        Regex cenaRegex = new Regex("[0-9]+");

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            DataManger.SoftverFilter.ID = textBoxID.Text;
            DataManger.SoftverFilter.Ime = textBoxIme.Text;
            DataManger.SoftverFilter.Proizvodjac = textBoxProizvodjac.Text;
            string poruka = "";
            
           
            if (!cenaRegex.IsMatch(textBoxCena.Text))
            {
                poruka += "#1" + ": Cena se mra sastojati samo od brojeva (0-9).\n";
            }
            if (poruka.Length > 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

        }
    }
}
