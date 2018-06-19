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
    public partial class BrisanjeForm : Form
    {
        public BrisanjeForm(List<GUIObject> objects)
        {
            InitializeComponent();
            foreach(GUIObject o in objects)
            {
                listBox1.Items.Add(o);
            }
        }

        private void buttonIzbrisi_Click(object sender, EventArgs e)
        {
            // predmet, ucionica, , smer
            //if(listBox1.SelectedItem is )
            //{

            //}
        }
    }
}
