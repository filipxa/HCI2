using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            BackColor = Color.Transparent;
            MouseDown += PredmetControl_MouseDown;
        }

        private void PredmetControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                DoDragDrop(GuiObject, DragDropEffects.All);
            }

        }
    

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            GraphicLoader.drawImages(g, ClientRectangle, "Predmet");
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            RectangleF textRec = new RectangleF(0, 0, Width / 4 * 3, Height/4*3.5f);
            g.DrawString(GuiObject.ID, GraphicLoader.getFontBold(14), new SolidBrush(Color.Black), textRec, sf);
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            RectangleF casRec = new RectangleF(Width / 4 * 3 + 7, 0, Width / 4, Height);
            g.DrawString(GuiObject.BrCasova.ToString(), GraphicLoader.getFontBold(14), new SolidBrush(Color.Black), casRec, sf);
        }
    }
}
