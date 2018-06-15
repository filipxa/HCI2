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
    public partial class UcionicaFilterForm : Form
    {
        List<UcionicaAssets> OS = new List<UcionicaAssets>();
        public UcionicaFilterForm()
        {
            

            InitializeComponent();
            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }


            this.VisibleChanged += initTabela;

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            DataControllercs.onAction += ActionExcuted;
            numericUpDownBrRadnihMesta.ValueChanged += initTabela;
            textBoxID.TextChanged += initTabela;

            checkedListBox2.ItemCheck += initTabela;
            FormClosing += Form_Closing;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataManger.UcionicaFilter.ID = textBoxID.Text;
            DataManger.UcionicaFilter.BrRadnihMesta = Convert.ToInt32(numericUpDownBrRadnihMesta.Value);
            DataManger.UcionicaFilter.Assets = getUcionicaAssets();
            DataManger.UcionicaFilter.InstalledSoftware = getInstalledSoft();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            //dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Opis";
            dataGridView1.Columns[2].Name = "Br. mesta";
            dataGridView1.ReadOnly = true;
            popunjavanjeTabele();
            
        }

        private void popunjavanjeTabele()
        {
            foreach (Ucionica p in DataManger.getUcionice())
            {
                string[] row = { p.ID, p.Opis, Convert.ToString(p.BrRadnihMesta) };
                dataGridView1.Rows.Add(row);
            }
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboValue cv = (ComboValue)checkedListBox1.Items[e.Index];
            if (cv.Value.Equals(UcionicaAssets.windows) || cv.Value.Equals(UcionicaAssets.linux))
            {
                if (e.NewValue == CheckState.Checked)
                {
                    OS.Add((UcionicaAssets)cv.Value);
                }
                else
                {
                    OS.Remove((UcionicaAssets)cv.Value);
                }

                popuniSoftvere();
            }


            initTabela(null,null);
        }

        // desni checkBox
        private void popuniSoftvere()
        {
            checkedListBox2.Items.Clear();
            List<UcionicaAssets> listaSistema = new List<UcionicaAssets>();

            foreach (Software s in DataManger.softverOperativanSistemFiltiriranje(OS))
            {
                bool postoji = false;
                if (DataManger.UcionicaFilter != null)
                {
                    postoji = DataManger.UcionicaFilter.InstalledSoftware.Contains(s);
                }
                checkedListBox2.Items.Add(s, postoji);
            }

        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            UcionicaForm f = new UcionicaForm(null);
            f.ShowDialog();
            DialogResult = DialogResult.None;
          
        }

        private HashSet<Software> getInstalledSoft()
        {
            HashSet<Software> rets = new HashSet<Software>();
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {
                rets.Add((Software)itemChecked);

            }
            return rets;
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

        private void datagridview1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["you have to mention you cell  corresponding column name"].Value);


            }
        }
        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);
                //brisanje ovde
                Ucionica ucionica = DataManger.GetUcionicaID(id);
                DeleteAction d = new DeleteAction(ucionica);
                DataControllercs.addAction(d);
                this.BringToFront();
            }
            catch
            {
                this.BringToFront();
            }
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);
                
                Ucionica ucionica = DataManger.GetUcionicaID(id);
                DeleteAction d = new DeleteAction(ucionica);
                DataControllercs.addAction(d);
                BringToFront();
            }
            catch
            {
                this.BringToFront();
            }
           
            //brisanje ovde
        }
    }
}
