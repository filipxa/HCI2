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

            dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            MinimumSize = Size;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            FormBorderStyle = FormBorderStyle.Sizable;

            this.VisibleChanged += initTabela;
            textBox1.TextChanged += initTabela;
            textBoxIme.TextChanged += initTabela;
            DataControllercs.onAction += ActionExcuted;
            FormClosing += Form_Closing;
            KeyPreview = true;
            KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.F1)
                {
                    DataManger.goToHelp("smer");
                }
            };

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
        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            SmerForm f = new SmerForm(null);
            f.ShowDialog();
            f.Dispose();
        }
        private void initTabela(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;

            dataGridView1.Rows.Clear();

            DataManger.SmerFilter.ID = textBox1.Text;
            DataManger.SmerFilter.Ime = textBoxIme.Text;


            dataGridView1.ColumnCount = 4;
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

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);
                Smer smer = DataManger.GetSmerID(id);
                DeleteAction d = new DeleteAction(smer);
                DataControllercs.addAction(d);
            }
            catch
            {
            }
        }

        private void buttonIzmena_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);

                Smer smer = DataManger.GetSmerID(id);
                SmerForm f = new SmerForm(smer);
                f.ShowDialog();
                f.Dispose();
            }
            catch
            {

            }
        }

        private void SmerFilterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
