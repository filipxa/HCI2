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

            numericUpDownBrRadnihMesta.ValueChanged += initTabela;
            textBoxID.TextChanged += initTabela;
            checkedListBox1.SelectedValueChanged += initTabela;
            checkedListBox2.SelectedValueChanged += initTabela;
        }


        private void initTabela(object sender, EventArgs e)
        {
            
            if (!this.Visible)
                return;

            DataManger.UcionicaFilter.ID = textBoxID.Text;
            DataManger.UcionicaFilter.BrRadnihMesta = Convert.ToInt32(numericUpDownBrRadnihMesta.Value);
            DataManger.UcionicaFilter.Assets = getUcionicaAssets();
            DataManger.UcionicaFilter.InstalledSoftware = getInstalledSoft();

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
            
            this.Hide();
        }

        private HashSet<Software> getInstalledSoft()
        {
            HashSet<Software> rets = new HashSet<Software>();
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {

                ComboValue item = ((ComboValue)itemChecked);
                rets.Add((Software)item.Value);

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
    }
}
