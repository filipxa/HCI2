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
            initTabela();
        }

        Regex cenaRegex = new Regex("^[0-9]*$");

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            DataManger.SoftverFilter.ID = textBoxID.Text;
            DataManger.SoftverFilter.Ime = textBoxIme.Text;
            DataManger.SoftverFilter.Proizvodjac = textBoxProizvodjac.Text;
            string poruka = "";
            

            if (!cenaRegex.IsMatch(textBoxCena.Text))
            {
                poruka += "#1" + ": Cena se mra sastojati samo od brojeva (0-9).\n";
            }
            if (poruka.Length > 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            DataManger.SoftverFilter.Cena = Convert.ToDouble(textBoxCena.Text);
            
            //this.Hide();
        }
        private void initTabela()
        {
            dataGridView1.ColumnCount = 7;

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
    }
}
