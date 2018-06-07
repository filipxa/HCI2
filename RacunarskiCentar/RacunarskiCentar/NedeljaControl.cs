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
        float visinaNazivaDana;
        RasporedControl parentRaspored;
        Panel daniPanel;

        private Panel getPanelFromDan(int dan)
        {
            foreach (KeyValuePair<Panel, int> entry in dani)
            {
                if (entry.Value == dan)
                {
                    return entry.Key;
                }
            }
            return null;
        }

        public NedeljaControl(Nedelja nedelja, Panel panel, float visinaNazivaDana, RasporedControl rasporedControl) : base(nedelja,panel)
        {
            
            InitializeComponent();
            parentRaspored = rasporedControl;
            this.visinaNazivaDana = visinaNazivaDana;
            daniPanel = new Panel();

            daniPanel.Dock = DockStyle.Fill;
            Controls.Add(daniPanel);
            InitDani(nedelja);
            Layout += NedeljaControl_Layout;
        }

        private void InitDani(Nedelja nedelja)
        {
            Panel dan;
            daniPanel.Controls.Clear();
            foreach (KeyValuePair<int, List<Termin>> pair in nedelja.getDanTermine())
            {
                int rbr = pair.Key;
                dan = new Panel();
                dan.Paint += Dan_Paint;
                dan.DragDrop += Dan_DragDrop;
                dan.BackColor = GraphicLoader.getColorLightGray();
                dan.Location = new Point(0, 0);
                daniPanel.Controls.Add(dan);
                dani.Add(dan, rbr);
                dan.DragEnter += Dan_DragEnter;
                dan.AllowDrop = true;
                List<Termin> termini = pair.Value;
                foreach (Termin termin in termini)
                {
                    //NAPRAVI TERMINE
                }

            }


        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void NedeljaControl_Layout(object sender, LayoutEventArgs e)
        {
            resizeAllDani();
        }




        private void resizeAllDani()
        {
            Panel dan;
            foreach (KeyValuePair<Panel, int> pair in dani)
            {
                dan = pair.Key;
                float rbr = pair.Value;
                dan.Width =  Convert.ToInt32( Math.Round((float)Width /  6));
                dan.Location = new Point(Convert.ToInt32(Math.Round(Width * rbr / 6)), 0);
                dan.Height = Height;
                foreach(Control c in dan.Controls)
                {
                    TerminControl termin = c as TerminControl;
                    if (termin != null)
                    {
                        termin.Width = dan.Width;
                        termin.Location = new Point(3, getYFromDateTime(termin.GuiObject.PocetakTermina, dan) + 5);
                        termin.Size = new Size(dan.Width - 3, getYFromDateTime(termin.GuiObject.KrajTermina, dan) - getYFromDateTime(termin.GuiObject.PocetakTermina, dan));
                    }
                }
               
            }

        }
        enum Dani
        {
            PON, UTO, SRED, ČET, PET, SUB
        }
        private void Dan_Paint(object sender, PaintEventArgs e)
        {
            Panel dan;
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

            Pen pen = new Pen(Color.Yellow, RasporedControl.sirinaOlovke);

            Pen penBold = new Pen(Color.Yellow, RasporedControl.sirinaOlovke * 3);
            DateTime pocetak = new DateTime(1, 1, 1, 8, 0, 0);
            for (int i = 0; i < RasporedControl.brPodeoka; i++)
            {
                
                pointL = new PointF(0, (visinaPodeoka * i) + visinaNazivaDana);
                pointR = new PointF(dan.Width, (visinaPodeoka * i) + visinaNazivaDana);
                if (pocetak.Minute == 0)
                {
                    g.DrawLine(penBold, pointL, pointR);
                } else
                {
                    g.DrawLine(pen, pointL, pointR);
                }

                pocetak = pocetak.AddMinutes(15);

            }

            pointL = new PointF(0, (visinaPodeoka * RasporedControl.brPodeoka) - 2 + visinaNazivaDana);
            pointR = new PointF(dan.Width, (visinaPodeoka * RasporedControl.brPodeoka) - 2 + visinaNazivaDana);
            g.DrawLine(penBold, pointL, pointR);
            g.DrawLine(penBold, 0,0, dan.Width, 0);
            g.DrawLine(penBold, 0, 0, 0, Height);
            if (dani[dan] == (int) Dani.SUB)
            {
                g.DrawLine(penBold, dan.Width, 0, dan.Width, Height);
            }
            sf.Dispose();
            pen.Dispose();
            penBold.Dispose();
        }



        private void Dan_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Dan_DragDrop(object sender, DragEventArgs e)
        {
            var formats = e.Data.GetFormats();
            var data = e.Data.GetData(typeof(Predmet));
            
            Predmet p = data as Predmet;
            data = e.Data.GetData(typeof(Termin));
            Termin t = data as Termin;
            DateTime pocetakTermina = getDateTimeFromMousePoint((Panel)sender, e.X, e.Y);
            if (p != null)
            {

                Termin termin = new Termin(pocetakTermina, p.BrCasova,p,GuiObject);
                if (GuiObject.isSlobodan(termin))
                {
                    DataControllercs.addAction(new CreateAction(termin));
                    CreateTerminControl(termin, (Panel)sender);
                }

            }
            if (t != null)
            {
                Termin termin = t;
                TimeSpan ts = t.KrajTermina - t.PocetakTermina;
                DateTime krajTermina = pocetakTermina.Add(ts);
                if (GuiObject.isSlobodan(pocetakTermina, krajTermina, t))
                {
                   
                    transferTerminToNewDate((Panel)sender, termin, pocetakTermina, krajTermina);
                   
                }
            }
           
        }
  

        private void transferTerminToNewDate(Panel currentPanel, Termin termin, DateTime pocetakTermina, DateTime krajTermina)
        {
            ChainAction chainAction = new ChainAction();
            Termin novi = new Termin(pocetakTermina, krajTermina, termin.Predmet, GuiObject);
            chainAction.actions.Add(new DeleteAction(termin));

            chainAction.actions.Add(new CreateAction(novi));

            int dan = novi.PocetakTermina.Day -GuiObject.Ponedeljak.Day;

            CreateTerminControl(novi, getPanelFromDan(dan));
            DataControllercs.addAction(chainAction);

        }

        private DateTime getDateTimeFromMousePoint(Panel p, int x, int y)
        {
            Point clientPoint = p.PointToClient(new Point(x, y));
            return getDateFromY(p, clientPoint.Y);

        }
        private DateTime getDateFromY(Panel p, int y)
        {
            float visinaPodeoka = parentRaspored.visinaPodeoka;
            int vreme = y - (int)visinaNazivaDana;
            vreme = vreme / (int)visinaPodeoka;
            vreme = vreme * 15;
            return GuiObject.Ponedeljak.AddMinutes(vreme).AddDays(dani[p]);
        }

        private int getYFromDateTime(DateTime time, Panel p)
        {
            int hours = time.Hour;
            int minutes = time.Minute;
            hours -= 8;
            float visinaPodeoka = (p.Height - visinaNazivaDana) / RasporedControl.brPodeoka;

            return (hours*4 + minutes/15) * (int)visinaPodeoka + (int)visinaNazivaDana;
        }

        private void CreateTerminControl(Termin termin, Panel dan)
        {
            TerminControl t = new TerminControl(termin, dan);
            dan.Controls.Add(t);
            t.Width = dan.Width;
            t.Location = new Point(3, getYFromDateTime(termin.PocetakTermina, dan) +5);
            t.Size = new Size(dan.Width-3, getYFromDateTime(termin.KrajTermina, dan) - getYFromDateTime(termin.PocetakTermina, dan));
            
        }

        

 

 


    }
}
