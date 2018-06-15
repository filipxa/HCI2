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
    public partial class SmerFilterForm : Form
    {
        public SmerFilterForm()
        {
            InitializeComponent();
            this.VisibleChanged += initTabela;
            textBox1.TextChanged += initTabela;
            textBoxIme.TextChanged += initTabela;
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void initTabela(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;

            dataGridView1.Rows.Clear();

            DataManger.SmerFilter.ID = textBox1.Text;
            DataManger.SmerFilter.Ime = textBoxIme.Text;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Datum uvodjenja";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Name = "opis";
            dataGridView1.ReadOnly = true;
            popunjavanjeTabele();
        }

        private void popunjavanjeTabele()
        {

            foreach (Smer p in DataManger.getSmers())
            {
                string[] row = { p.ID, p.Ime, p.DatumUvodjenja.ToString(), p.Opis };
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
