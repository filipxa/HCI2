using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            DataManger.SoftverFilter.ID = textBoxID.Text;
            DataManger.SoftverFilter.Ime = textBoxIme.Text;
            DataManger.SoftverFilter.Proizvodjac = textBoxProizvodjac.Text;
            DataManger.SoftverFilter.Cena = Convert.ToInt32(textBoxCena);

        }
    }
}
