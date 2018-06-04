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
    public partial class PredmetControl : CustomControlBase<Predmet>
    {
        public PredmetControl(Predmet predmet, Panel panel) : base(predmet, panel)
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
        }
    }
}
