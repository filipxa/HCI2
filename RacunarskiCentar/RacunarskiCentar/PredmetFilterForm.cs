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
            dataGridView1.ColumnCount = 7;

            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Smer";
            dataGridView1.Columns[3].Name = "Opis";
            dataGridView1.Columns[4].Name = "Br. ljudi";
            dataGridView1.Columns[5].Name = "Br. casova";
            dataGridView1.Columns[6].Name = "Br. termina";


            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
            popunjavanjeTabele();


        }

        private void popunjavanjeTabele()
        {
            foreach (Predmet p in DataManger.getPredmeti())
            {
                string[] row = { p.ID, p.Ime, p.SmerPredmeta.Ime, p.Opis, Convert.ToString(p.BrLjudi), Convert.ToString(p.BrCasova), Convert.ToString(p.BrTermina) };
                dataGridView1.Rows.Add(row);
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
