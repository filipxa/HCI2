using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class UcionicaControl : CustomControlBase<Ucionica>
    {
        public UcionicaControl(Ucionica ucionica, Panel panel) : base(ucionica, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            MouseClick += EditClick;
            MouseDown += UcionicaControl_MouseDown;
            AllowDrop = true;

        }

        private void UcionicaControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                DoDragDrop(this, DragDropEffects.All);
            }

        }

        public void EditClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                EditData();
            }
            

        }

        public void EditData()
        {
            UcionicaForm f = new UcionicaForm(GuiObject);
            f.ShowDialog();
            if(f.DialogResult==DialogResult.OK)
                 f.GetAction();
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;

            if (IsTutorial)
            {
                GraphicLoader.drawImages(g, rc, "Ucionica", "base", "Tut");
            }
            else
            {
                GraphicLoader.drawImages(g, rc, "Ucionica", "base");
            }

            GraphicLoader.drawImages(g, rc, "Ucionica");


            foreach (UcionicaAssets aset in GuiObject.Assets)
            {
                GraphicLoader.drawImages(g, rc, "Ucionica", "assets", ((int)aset).ToString());
            }

            Font font = GraphicLoader.getFontBold(20);
           
            PointF point = new PointF(rc.Width / 60f, rc.Height / 12f);
            SizeF size = new SizeF(rc.Width / 1.1f, rc.Height / 1.7F);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString(GuiObject.ID, font, new SolidBrush(Color.Black), new RectangleF(point, size), format);

            font = GraphicLoader.getFontBold(20);
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            point = new PointF(rc.Width / 100f, rc.Height / 10f * 7.15f );
            size = new SizeF(rc.Width / 4f, 26);
            g.DrawString(String.Format("{0:D2}",GuiObject.BrRadnihMesta), font, new SolidBrush(Color.Black), new RectangleF(point, size), format);
        }


    }
}
