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
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            DataManger.SmerFilter.ID = textBox1.Text;
            DataManger.SmerFilter.Ime = textBoxIme.Text;
        }
    }
}
