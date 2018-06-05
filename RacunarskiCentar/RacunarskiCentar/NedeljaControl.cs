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
    public partial class NedeljaControl : CustomControlBase<Nedelja>
    {
        Dictionary<Panel, int> dani = new Dictionary<Panel, int>();
        Pen pen;
        float visinaNazivaDana;
        RasporedControl parentRaspored;
        Panel dan;
        Panel daniPanel;
        public NedeljaControl(Nedelja nedelja, Panel panel,Pen pen,float visinaNazivaDana, RasporedControl rasporedControl) : base(nedelja,panel)
        {
            
            InitializeComponent();
            parentRaspored = rasporedControl;
            this.pen = pen;
            this.visinaNazivaDana = visinaNazivaDana;
            daniPanel = new Panel();
            
           
            daniPanel.Dock = DockStyle.Fill;
            daniPanel.BackColor = Color.Green;
            daniPanel.Padding = new Padding(0);
            daniPanel.Margin = new Padding(0);
            Controls.Add(daniPanel);
            InitDani(nedelja);
            Layout += NedeljaControl_Layout;
        }

        private void NedeljaControl_Layout(object sender, LayoutEventArgs e)
        {
            resizeAllDani();
        }


        private void resizeAllDani()
        {
            foreach (KeyValuePair<Panel, int> pair in dani)
            {
                dan = pair.Key;
                float rbr = pair.Value;
                dan.Width =  Convert.ToInt32( Math.Round((float)Width /  6));
                dan.Location = new Point(Convert.ToInt32(Math.Round(Width * rbr / 6)), 0);
                dan.Height = Height;
                dan.Paint += Dan_Paint;
            }

        }
        enum Dani
        {
            PON, UTO, SRED, ČET, PET, SUB
        }
        private void Dan_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            dan = (Panel)sender;
            PointF pointL;
            PointF pointR;
            float visinaPodeoka = parentRaspored.visinaPodeoka;
            Rectangle rec = new Rectangle(0, 0, dan.Width, (int)visinaNazivaDana);
            StringFormat sf = new StringFormat ();
           
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(((Dani)dani[dan]).ToString(), GraphicLoader.getFontBold(15), new SolidBrush(Color.Black), rec, sf);



            for (int i = 0; i < 16; i++)
            {
                pointL = new PointF(0, (visinaPodeoka * i) + visinaNazivaDana);
                pointR = new PointF(dan.Width, (visinaPodeoka * i) + visinaNazivaDana);
                g.DrawLine(pen, pointL, pointR);
              

            }
            pointL = new PointF(0, (visinaPodeoka * 16) - 2 + visinaNazivaDana);
            pointR = new PointF(Width, (visinaPodeoka * 16) - 2 + visinaNazivaDana);
            g.DrawLine(pen, pointL, pointR);
            g.DrawLine(pen,1, 1, 1, Height-1);
            sf.Dispose();
        }

        private void InitDani(Nedelja nedelja)
        {
            daniPanel.Controls.Clear();
            foreach (KeyValuePair<int, List<Termin>> pair in nedelja.getDanTermine())
            {
                int rbr = pair.Key;
                dan = new Panel();
                dan.BackColor = GraphicLoader.getColorLightGray();
                dan.Location = new Point(0, 0);
                daniPanel.Controls.Add(dan);
                dani.Add(dan, rbr);
                List<Termin> termini = pair.Value;
                foreach(Termin termin in termini)
                {
                    //NAPRAVI TERMINE
                }

            }
          

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


    }
}
