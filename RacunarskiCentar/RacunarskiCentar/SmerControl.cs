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
        Rectangle smerRec;
        public SmerControl(Smer smer, Panel panel): base(smer, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            Width = 200;
            Height = 45;
            smerRec = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            Height = GuiObject.Predmeti.Count() * 15;
        }
        

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
            Graphics g = pe.Graphics;
         
            Pen pen = new Pen(new SolidBrush(Color.Black),1);
            g.FillRectangle(new SolidBrush(Color.Pink), ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.LightGray), smerRec);
            g.DrawRectangle(pen, smerRec);



        }
    }
}
