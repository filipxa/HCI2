using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class SoftwareFilterForm : Form
    {
        public SoftwareFilterForm()
        {
            InitializeComponent();
            this.VisibleChanged += initTabela;

            numericUpDown1.ValueChanged += initTabela;
            textBoxID.TextChanged += initTabela;
            textBoxIme.TextChanged += initTabela;
            textBoxProizvodjac.TextChanged += initTabela;

            DataControllercs.onAction += ActionExcuted;
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

        Regex cenaRegex = new Regex("^[0-9]*$");



        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {

            SoftwareForm f = new SoftwareForm(null);
            f.ShowDialog();
            DialogResult = DialogResult.None;
            initTabela(sender, e);
            //f.Dispose();
            //this.Hide();
        }
        private void initTabela(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;
            DataManger.SoftverFilter.ID = textBoxID.Text;
            DataManger.SoftverFilter.Ime = textBoxIme.Text;
            DataManger.SoftverFilter.Proizvodjac = textBoxProizvodjac.Text;
            DataManger.SoftverFilter.Cena = Convert.ToDouble(numericUpDown1.Value);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Ime";
            dataGridView1.Columns[2].Name = "Proizvodjac";
            dataGridView1.Columns[3].Name = "Url";
            dataGridView1.Columns[4].Name = "Godina";
            dataGridView1.Columns[5].Name = "Cena";
            dataGridView1.Columns[6].Name = "Opis";
            dataGridView1.ReadOnly = true;
            popunjavanjeTabele();
        }

        private void popunjavanjeTabele()
        {

            foreach (Software p in DataManger.getSoftware())
            {
                string[] row = { p.ID, p.Ime, p.Proizvodjac, p.URL, p.Godina ,Convert.ToString(p.Cena), p.Opis };
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonOrisi_Click(object sender, EventArgs e)
        {
            try {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string id = selectedRow.Cells[0].Value.ToString();
                System.Diagnostics.Debug.WriteLine(id);
                //brisanje ovde
                Software software = DataManger.GetSoftverID(id);
                DeleteAction d = new DeleteAction(software);
                DataControllercs.addAction(d);
                this.BringToFront();
            }
            catch {
                this.BringToFront();
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
                Software software = DataManger.GetSoftverID(id);
                SoftwareForm f = new SoftwareForm(software);
                f.ShowDialog();
                DialogResult = DialogResult.None;
                this.BringToFront();
            }
            catch
            {
                this.BringToFront();
            }
        }
    }
}
