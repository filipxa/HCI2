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

            this.VisibleChanged += initTabela;
            textBoxID.TextChanged += initTabela;
            textBoxNaziv.TextChanged += initTabela;
            numericUpDownBrojLjudi.ValueChanged += initTabela;
            numericUpDownBrojTermina.ValueChanged += initTabela;
            numericUpDownDuzinaTermina.ValueChanged += initTabela;

            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
            //checkedListBox1.ItemCheck += initTabela;
            checkedListBox1.SelectedValueChanged += initTabela;


        }

        private void initTabela(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;

            DataManger.PredmetFiler.ID = textBoxID.Text;
            DataManger.PredmetFiler.BrLjudi = Convert.ToInt32(numericUpDownBrojLjudi.Value);
            DataManger.PredmetFiler.Ime = textBoxNaziv.Text;
            DataManger.PredmetFiler.BrCasova = Convert.ToInt32(numericUpDownDuzinaTermina.Value);
            DataManger.PredmetFiler.BrTermina = Convert.ToInt32(numericUpDownBrojTermina.Value);
            DataManger.PredmetFiler.Assets = getUcionicaAssets();

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Smer";
            dataGridView1.Columns[3].Name = "Opis";
            dataGridView1.Columns[4].Name = "Br. ljudi";
            dataGridView1.Columns[5].Name = "Br. casova";
            dataGridView1.Columns[6].Name = "Br. termina";
            dataGridView1.ReadOnly = true;

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
