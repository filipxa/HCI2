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
    public partial class TerminForm : Form
    {
        private Termin termin;
        private Nedelja nedelja;
        private Predmet predmet;
        public TerminForm(Nedelja nedelja, Predmet predmet, DateTime dan, Termin termin)
        {
            this.termin = termin;
            this.predmet = predmet;
            this.nedelja = nedelja;
            InitializeComponent();
            InicijalizacijaCasovaUnos();
            InicijalizacijaUnosVremena();

            DateTime ponedeljak = (nedelja == null) ? dan : nedelja.Ponedeljak;
            dateTimePicker1.MinDate = new DateTime(ponedeljak.Year, ponedeljak.Month, dan.Day, 7, 0, 0);
            dateTimePicker1.MaxDate = new DateTime(ponedeljak.Year, ponedeljak.Month, dan.Day, 22, 0, 0);

        }
        public TerminForm(Termin termin) : this(termin.Nedelja, termin.Predmet, termin.PocetakTermina,termin)
        {
            this.termin = termin;
        }

        private void InicijalizacijaUnosVremena()
        {
            DateTime ponedeljak = (termin.Nedelja == null) ? termin.PocetakTermina : termin.Nedelja.Ponedeljak;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = termin.PocetakTermina;
            Controls.Add(dateTimePicker1);
        }

        private void InicijalizacijaCasovaUnos()
        {
            numericUpDown1.Minimum = termin.Predmet.BrCasova;
            numericUpDown1.Value = termin.DuzinaTermina;
        }

        private Termin getTerminFromFields()
        {
            termin = new Termin(dateTimePicker1.Value, (int)numericUpDown1.Value, predmet, nedelja);
            return termin;
        }

        private void TerminForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime krajTermina = dateTimePicker1.Value.AddMinutes(45 * (int)numericUpDown1.Value);

            if(termin.Nedelja.isSlobodan(dateTimePicker1.Value, krajTermina, termin))
            {
                Action action;
                
                termin.PocetakTermina = dateTimePicker1.Value;
                termin.KrajTermina = krajTermina;
                termin.DuzinaTermina = (int)numericUpDown1.Value;
                action = new EditAction(termin);
                DataControllercs.addAction(action);

            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Izabrano vreme je zauzeto", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }

}
