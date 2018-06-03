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
        public UcionicaControl(Ucionica ucionica, Panel panel) : base(ucionica, panel)
        {
            InitializeComponent();
            MouseDoubleClick += DoubleClick;
            MouseDown += UcionicaControl_MouseDown;

        }

        private void UcionicaControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                DoDragDrop(this, DragDropEffects.All);
            }

        }

        public new void DoubleClick(object sender, EventArgs e)
        {
            EditData();
        }

        public void EditData()
        {
            UcionicaForm f = new UcionicaForm(GuiObject);
            f.ShowDialog();
            f.GetAction();

        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;
            rc.Width = Width;
            rc.Height = Height;
            Font f = new Font("Verdana", (float)rc.Height * 0.2f, FontStyle.Bold, GraphicsUnit.Pixel);
            g.FillRectangle(new SolidBrush(Color.Aqua), rc);
            g.DrawString(GuiObject.ID, f, new SolidBrush(Color.Black), new RectangleF(rc.Location, rc.Size));
            g.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(15, 15), new Point(75, 75));
            
        }
        
        
    }
}
