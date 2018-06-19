using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RacunarskiCentar

{
    public partial class SmerControl : CustomControlBase<Smer>
    {
        Rectangle smerRec;
        Ucionica ucionica;
        public Panel predmetPanel;
        private const int predmetHeight = 30;
        private const int smerHeight = 45;
        bool isColapsed = true;
        EventHandler colapseedChanged;

        public event EventHandler ColapseedChanged
        {
            add
            {
                colapseedChanged += value;
            }
            remove
            {
                colapseedChanged -= value;
            }
        }
        public void OnColapseedChanged(EventArgs e)
        {
            if (colapseedChanged != null)
            {
                colapseedChanged(this, e);
            }
        }

        public bool IsColapsed
        {
            get => isColapsed;
            set
            {
                if (value == isColapsed)
                    return;
                isColapsed = value;
                OnColapseedChanged(new EventArgs ());
                refreshPanels();
                Invalidate(); 
            }
        }
        public SmerControl(Smer smer, Panel panel, Ucionica ucionica): base(smer, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ucionica = ucionica;

            InitializeComponent();
            Width = 200;
            Height = smerHeight;
            smerRec = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);

            predmetPanel = new Panel();
            predmetPanel.Width = Width;
            predmetPanel.Location = new Point(0, smerHeight);
            predmetPanel.BackColor = Color.Transparent;

            refreshPanels();

            MouseClick += EditClick;
            MouseDown += SmerControl_Click;
            
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
            SmerForm f = new SmerForm(GuiObject);
            f.ShowDialog();

        }

        private void refreshPanels()
        {
            predmetPanel.Width = Width;
            smerRec.Width = Width;
            updatePredmetPanelSize();
            updatePredmetPanelElements();
        }



        private void SmerControl_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                if (smerRec.Contains(new Point(e.Location.X, e.Location.Y)))
                {
                    IsColapsed = !isColapsed;
                }
            }
           
        }

        private void updatePredmetPanelSize()
        {
            predmetPanel.Height = GuiObject.Predmeti.Count * predmetHeight;
          
            if (isColapsed)
            {
                if (Controls.Contains(predmetPanel))
                {
                    Controls.Remove(predmetPanel);
                }
                Height = smerHeight;
            } else
            {
                Height = smerHeight + GuiObject.Predmeti.Count() * predmetHeight;
                if (!Controls.Contains(predmetPanel))
                {
                    Controls.Add(predmetPanel);
                }
            }
        }

        private void updatePredmetPanelElements()
        {
            HashSet<Predmet> predmetiToAdd = new HashSet<Predmet>();
            foreach (Predmet predmet in GuiObject.getPredmetiPoUcionici(ucionica))
            {
                bool found = false;
                foreach (var predmetCon in predmetPanel.Controls)
                {
                    PredmetControl pc = (PredmetControl)predmetCon;
                    if (pc.GuiObject.Equals(predmet))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    predmetiToAdd.Add(predmet);
                }

            }
            foreach (Predmet predmet in predmetiToAdd)
            {
                PredmetControl pc = new PredmetControl(predmet, predmetPanel);
                pc.Width = predmetPanel.Width;
                pc.Height = predmetHeight;
                pc.Dock = DockStyle.Top;
                predmetPanel.Controls.Add(pc);
               
            }

        }

        protected override void onValueChaged(object sender, EventArgs e)
        {

            refreshPanels();
            base.onValueChaged(sender, e);
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {


            Graphics g = pe.Graphics;

           
            if (IsColapsed)
            {
                GraphicLoader.drawImages(g, smerRec, "Smer", "2");
            }
            else
            {
                GraphicLoader.drawImages(g, smerRec, "Smer", "0");
            }
            if (IsTutorial)
            {
                GraphicLoader.drawImages(g, smerRec, "Smer", "tut");
            }
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            g.DrawString(GuiObject.ID, GraphicLoader.getFontBold(20), new SolidBrush(Color.Black), smerRec, sf);
            base.OnPaint(pe);

        }
    }
}
