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
    public partial class NedeljaControl : Control
    {
        private Nedelja nedelja;
        private List<Panel> dani;
        public NedeljaControl(Nedelja nedelja, Panel panel)
        {
            InitDani();
            InitializeComponent();

        }

        private void InitDani()
        {
            Panel p;
            for (int i = 0; i < 6; i++)
            {
                p = new Panel();
                p.Location = new Point(0,0);
            
                dani.Add(p);
            }

            throw new NotImplementedException();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
