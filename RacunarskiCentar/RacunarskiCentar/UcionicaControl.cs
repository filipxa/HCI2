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
    public partial class UcionicaControl : CustomControlBase<Ucionica>
    {
        public UcionicaControl(Ucionica ucionica) : base(ucionica)
        {
            InitializeComponent();
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;
            rc.Width = 300;
            rc.Height = 200;
            Font f = new Font("Verdana", (float)rc.Height * 0.2f, FontStyle.Bold, GraphicsUnit.Pixel);
            g.FillRectangle(new SolidBrush(Color.Aqua), rc);
            g.DrawString(GuiObject.ID, f, new SolidBrush(Color.Black), new RectangleF(rc.Location, rc.Size)); 
            
            
        }
    }
}
