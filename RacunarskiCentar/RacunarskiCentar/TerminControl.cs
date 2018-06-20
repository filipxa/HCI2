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

            string toolText = "";
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolText += "Pocetak: "+termin.PocetakTermina.ToShortDateString() + Environment.NewLine  + "Kraj: " + termin.KrajTermina.ToShortDateString();
            toolTip1.SetToolTip(this, toolText);
            MouseDown += TerminControl_MouseDown;
            MouseClick += EditTermin;
            BackColor = GraphicLoader.getColorDarkGray();
            
        }

        private void EditTermin(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                EditData();
            }

        }

        public void EditData()
        {
            TerminForm f = new TerminForm(GuiObject);
            f.ShowDialog();

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
            Graphics g = pe.Graphics;
            Pen pen = new Pen(Color.Black, RasporedControl.sirinaOlovke * 3);
            Pen penTanji = new Pen(GraphicLoader.getColorLightGray(), RasporedControl.sirinaOlovke * 2);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            PointF pointPredmet = new PointF(ClientRectangle.Location.X, ClientRectangle.Location.Y + 2);
            PointF pointSmer = new PointF(ClientRectangle.Location.X, ClientRectangle.Location.Y + (ClientRectangle.Height / (GuiObject.DuzinaTermina)/2));
            SizeF size = new SizeF(ClientRectangle.Width, ClientRectangle.Height / (GuiObject.DuzinaTermina * 2));

            Point goreLevo = ClientRectangle.Location;
            Point goreDesno = new Point(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y);
            Point doleLevo = new Point(ClientRectangle.X, ClientRectangle.Y + ClientRectangle.Height);
            Point doleDesno = new Point(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y + ClientRectangle.Height);



            Point levaTackaCasa = new Point(ClientRectangle.X, ClientRectangle.Y + (ClientRectangle.Height / (GuiObject.DuzinaTermina)));
            Point desnaTackaCasa = new Point(ClientRectangle.X + ClientRectangle.Width, ClientRectangle.Y + (ClientRectangle.Height / (GuiObject.DuzinaTermina)));

            for (int i = 0; i < GuiObject.DuzinaTermina; i++)
            {
                if((i+1) < GuiObject.DuzinaTermina)
                    g.DrawLine(penTanji, levaTackaCasa,desnaTackaCasa);

                levaTackaCasa.Y = levaTackaCasa.Y + (int)Math.Round(((float)ClientRectangle.Height / (float)(GuiObject.DuzinaTermina)));
                desnaTackaCasa.Y = desnaTackaCasa.Y + (int)Math.Round(((float)ClientRectangle.Height / (float)(GuiObject.DuzinaTermina)));

                g.DrawString(GuiObject.Predmet.ID, GraphicLoader.getFontBold(11), new SolidBrush(Color.Yellow), new RectangleF(pointPredmet, size), sf);
                g.DrawString(GuiObject.Predmet.SmerPredmeta.ID, GraphicLoader.getFontBold(7), new SolidBrush(Color.Yellow), new RectangleF(pointSmer, size), sf);
                pointPredmet.Y = pointPredmet.Y + (int)Math.Round(((float)ClientRectangle.Height / (float)(GuiObject.DuzinaTermina)));
                pointSmer.Y = pointSmer.Y + (int)Math.Round(((float)ClientRectangle.Height / (float)(GuiObject.DuzinaTermina)));
                
            }

            g.DrawLine(pen, goreLevo, doleLevo);
            g.DrawLine(pen, goreDesno, doleDesno);
            g.DrawLine(pen, goreLevo, goreDesno);
            g.DrawLine(pen, doleLevo, doleDesno);

            base.OnPaint(pe);
            pen.Dispose();
            penTanji.Dispose();
        }
    }
}
