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
        public TerminForm(Nedelja nedelja, Predmet predmet, DateTime dan)
        {
            this.predmet = predmet;
            this.nedelja = nedelja;
            InitializeComponent();
            InicijalizacijaComboBoxBrCasova();
            InicijalizacijaUnosVremena();
            dateTimePicker1.MinDate = new DateTime(dan.Year, dan.Month, dan.Day, 7, 0, 0);
            dateTimePicker1.MaxDate = new DateTime(dan.Year, dan.Month, dan.Day, 22, 0, 0);

        }
        public TerminForm(Termin termin) : this(null, null,new  DateTime(2018,10,10))//termin.Nedelja, termin.Predmet)
        {
            this.termin = termin;
        }

        private void InicijalizacijaUnosVremena()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.ShowUpDown = true;
        }

        



        private void InicijalizacijaComboBoxBrCasova()
        {
            comboBoxC.DropDownStyle = ComboBoxStyle.DropDownList;
            // Verovatno ce trebati promeniti gornju granicu zavisi od razumevanja zadtaka
            //for (int i = termin.Predmet.BrCasova; i < (termin.Predmet.BrCasova * termin.Predmet.BrTermina); i++)
           // {
          //      comboBoxC.Items.Add(i);
//}
            //neophodno je i dodati da za poslednji izabrani predmet ne bude manji od minimalnog termina tj brinuti i o tom sranju

        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            DateTime ceoDatum;
            ceoDatum = nedelja.Ponedeljak;//ovde dodati datum iz nedelje
            TimeSpan ts = new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, 0);
            ceoDatum = ceoDatum.Date + ts;
            nedelja.isSlobodan(dateTimePicker1.Value, (int)comboBoxC.SelectedValue);

        }
    }

}
