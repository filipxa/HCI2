using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RacunarskiCentar.UcionicaForm;

namespace RacunarskiCentar
{
    public partial class PredmetFilterForm : Form
    {
        public PredmetFilterForm()
        {
            InitializeComponent();
            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
        }

      

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            DataManger.PredmetFiler.ID = textBoxID.Text;
            DataManger.PredmetFiler.BrLjudi = Convert.ToInt32(numericUpDownBrojLjudi.Value);
            DataManger.PredmetFiler.Ime = textBoxNaziv.Text;
            DataManger.PredmetFiler.BrCasova = Convert.ToInt32(numericUpDownDuzinaTermina.Value);
            DataManger.PredmetFiler.BrTermina = Convert.ToInt32(numericUpDownBrojTermina.Value);
            DataManger.PredmetFiler.Assets = getUcionicaAssets();
            this.Hide();
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
    }
}
