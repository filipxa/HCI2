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
        List<UcionicaAssets> uAssets = new List<UcionicaAssets>();
        HashSet<Software> softwares = new HashSet<Software>();
        
        public UcionicaFilterForm()
        {
            

            InitializeComponent();
            dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            MinimumSize = Size;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            FormBorderStyle = FormBorderStyle.Sizable;


            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }


            this.VisibleChanged += initTabela;

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;



            DataControllercs.onAction += ActionExcuted;
            numericUpDownBrRadnihMesta.ValueChanged += initTabela;
            textBoxID.TextChanged += initTabela;

            checkedListBox2.ItemCheck += CheckedListBox2_ItemCheck;


            FormClosing += Form_Closing;
            KeyPreview = true;
            KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                     DataManger.goToHelp("ucionica");
                }
            };

        }


        private void CheckedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Software soft = (Software)checkedListBox2.Items[e.Index];
            if (e.NewValue==CheckState.Checked)
            {
                softwares.Add(soft);
            }
            else
            {
                softwares.Remove(soft);
            }
            initTabela(sender, e);
            
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
            DataManger.UcionicaFilter.ID = textBoxID.Text;
            DataManger.UcionicaFilter.BrRadnihMesta = Convert.ToInt32(numericUpDownBrRadnihMesta.Value);
            DataManger.UcionicaFilter.Assets = new HashSet<UcionicaAssets>(uAssets);
            DataManger.UcionicaFilter.InstalledSoftware = getInstalledSoft();
            
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Opis";
            dataGridView1.Columns[2].Name = "Br. mesta";
            dataGridView1.Columns[3].Name = "Inventar";
            dataGridView1.ReadOnly = true;
            popunjavanjeTabele();
            
        }

        private void popunjavanjeTabele()
        {
            foreach (Ucionica p in DataManger.ucionicaFilterisanje())
            {
                string[] row = { p.ID, p.Opis, Convert.ToString(p.BrRadnihMesta), UcionicaAssetsMethods.getDisplayNames(p.Assets) };
                dataGridView1.Rows.Add(row);
            }
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
            if (cv.Value.Equals(UcionicaAssets.windows) || cv.Value.Equals(UcionicaAssets.linux))
            {
               

                popuniSoftvere();
            }


            initTabela(null,null);
        }

        // desni checkBox
        private void popuniSoftvere()
        {
            checkedListBox2.Items.Clear();
            List<UcionicaAssets> listaSistema = new List<UcionicaAssets>();
            listaSistema = uAssets.Where(x => x.Equals(UcionicaAssets.windows) || x.Equals(UcionicaAssets.linux)).ToList();

            foreach (Software s in DataManger.softverOperativanSistemFiltiriranje(listaSistema))
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
           
            return softwares;
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
        private void buttonObrisi_Click(object sender, EventArgs e)
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

            }
            catch
            {
               
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
                UcionicaForm uf = new UcionicaForm(ucionica);
                
                uf.ShowDialog();
                uf.Dispose();
            }
            catch
            {
              
            }
           
            //brisanje ovde
        }
    }
}
