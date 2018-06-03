using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar

{
    public partial class SmerControl : CustomControlBase<Smer>
    {
        public SmerControl(Smer smer, Panel panel): base(smer, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle rec = ClientRectangle;
            Pen pen = new Pen(new SolidBrush(Color.Black),1);
           
            g.FillRectangle(new SolidBrush(Color.LightGray), rec);
            g.DrawRectangle(pen, rec);


        }
    }
}
