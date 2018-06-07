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
    public partial class TerminControl : CustomControlBase<Termin>
    {
        public TerminControl(Termin termin, Panel panel) : base(termin, panel)
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            MouseDown += TerminControl_MouseDown;
            
        }

        private void TerminControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                DoDragDrop(GuiObject, DragDropEffects.All);
            }
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            
            base.OnPaint(pe);
        }
    }
}
