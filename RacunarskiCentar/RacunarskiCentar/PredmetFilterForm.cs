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
        HashSet<UcionicaAssets> uAssets = new HashSet<UcionicaAssets>();
        public PredmetFilterForm()
        {
            InitializeComponent();

            this.dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top  | AnchorStyles.Left ;
            MinimumSize = Size;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            FormBorderStyle = FormBorderStyle.Sizable;

            this.VisibleChanged += initTabela;
            textBoxID.TextChanged += initTabela;
            textBoxNaziv.TextChanged += initTabela;
            textBoxSmer.TextChanged += initTabela;
            numericUpDownBrojLjudi.ValueChanged += initTabela;
            numericUpDownBrojTermina.ValueChanged += initTabela;
            numericUpDownDuzinaTermina.ValueChanged += initTabela;


            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
           

            DataControllercs.onAction += ActionExcuted;
            FormClosing += Form_Closing;
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboValue cv = (ComboValue)checkedListBox1.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                uAssets.Add((UcionicaAssets)cv.Value);
            }
            else
            {
                uAssets.Remove((UcionicaAssets)cv.Value);
            }


            initTabela(null, null);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ActionExcuted(object sender, Action e)
        {
            initTabela(sender, new EventArgs());
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
            DataManger.PredmetFiler.SmerPredmeta = new Smer(textBoxSmer.Text, "", DateTime.MinValue, "", null);

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Smer";
            dataGridView1.Columns[3].Name = "Opis";
            dataGridView1.Columns[4].Name = "Br. ljudi";
            dataGridView1.Columns[5].Name = "Br. casova";
            dataGridView1.Columns[6].Name = "Br. termina";
            dataGridView1.Columns[7].Name = "Inventar";
            dataGridView1.ReadOnly = true;

            popunjavanjeTabele();
        }

        private void popunjavanjeTabele()
        {
            foreach (Predmet p in DataManger.getPredmetiFilterr())
            {
                string[] row = { p.ID, p.Ime, p.SmerPredmeta.ID, p.Opis, Convert.ToString(p.BrLjudi), Convert.ToString(p.BrCasova), Convert.ToString(p.BrTermina), UcionicaAssetsMethods.getDisplayNames(p.Assets) };
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            PredmetForm f = new PredmetForm(null, null);
            f.ShowDialog();
            f.Dispose();
        }

        private HashSet<UcionicaAssets> getUcionicaAssets()
        {
           
            return uAssets;
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);
                Predmet predmet = DataManger.getPredmetByID(id);
                DeleteAction d = new DeleteAction(predmet);
                DataControllercs.addAction(d);
            }
            catch 
            {

            }
           
        }

        private void Izmeni_Click(object sender, EventArgs e)
        {

                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);

                Predmet predmet = DataManger.getPredmetByID(id);
                PredmetForm f = new PredmetForm(predmet,predmet.SmerPredmeta);
                f.ShowDialog();
                f.Dispose();

            
           
        }
    }
}
