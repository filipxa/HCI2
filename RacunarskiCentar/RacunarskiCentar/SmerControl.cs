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
        Panel predmetPanel;
        private const int predmetHeight = 20;
        private const int smerHeight = 30;
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
        public SmerControl(Smer smer, Panel panel): base(smer, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
            Width = 200;
            Height = smerHeight;
            smerRec = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);

            predmetPanel = new Panel();
            predmetPanel.Width = Width;
            predmetPanel.Location = new Point(0, smerHeight);
            predmetPanel.BackColor = Color.Black; // parentPanel.BackColor;
           

            refreshPanels();


            MouseDown += SmerControl_Click;
            
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
           if(smerRec.Contains(new Point(e.Location.X, e.Location.Y)))
            {
                IsColapsed = !isColapsed;
               
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
            List<Predmet> predmetiToAdd = new List<Predmet>();
            foreach (Predmet predmet in GuiObject.Predmeti)
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

            Pen pen = new Pen(new SolidBrush(Color.Black), 1);
            g.FillRectangle(new SolidBrush(Color.LightGray), smerRec);
            g.DrawRectangle(pen, smerRec);

            
            base.OnPaint(pe);

        }
    }
}
