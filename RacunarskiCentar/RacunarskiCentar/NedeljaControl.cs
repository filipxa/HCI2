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
    public partial class NedeljaControl : Control
    {
        List<Panel> dani = new List<Panel>();
        private Nedelja nedelja;
        Pen pen;
        float visinaPodeoka;
        int debljinaLinije;
        float visinaNazivaDana;
        Panel dan;
        public NedeljaControl(Nedelja nedelja, Panel panel,Pen pen, float visinaPodeoka, int debljinaLinije,float visinaNazivaDana)
        {
            InitDani();
            InitializeComponent();
            this.pen = pen;
            this.visinaPodeoka = visinaPodeoka;
            this.debljinaLinije = debljinaLinije;
            this.visinaNazivaDana = visinaNazivaDana;
        }

        private void InitDani()
        {
            dan = new Panel();

            dan.Width = Width / 6;
            dan.Height = Height;
            dan.BackColor = Color.Red;
            dan.Location = new Point(0, 0);
            dan.MinimumSize = new Size(200, 200);
            dan.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            Controls.Add(dan);
            dani.Add(dan);

            /*for (int i = 0; i < 1; i++)
            {
                dan = new Panel();

                dan.Width = Width/6;
                dan.Height = Height;
                dan.BackColor = Color.Red;
                dan.Location = new Point(dan.Width*i, 0);
                dan.MinimumSize = new Size(200, 200);
                dan.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                Controls.Add(dan);
                dani.Add(dan);
            }*/

            //throw new NotImplementedException();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            PointF pointL;
            PointF pointR;
            Graphics g = pe.Graphics;
            for (int i = 0; i < 16; i++)
            {
                pointL = new PointF(0, (visinaPodeoka * i) + visinaNazivaDana - debljinaLinije);
                pointR = new PointF(Width, (visinaPodeoka * i) + visinaNazivaDana - debljinaLinije);
                g.DrawLine(pen, pointL, pointR);

            }
        }

        private void RasporedControl_Resize(object sender, EventArgs e)
        {
            // visinaPodeoka = (float)(Height - visinaDatePikera) / 16f;
            Refresh();
        }
    }
}
