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
        Rectangle predmetRec;
        Panel predmetPanel;
        private const int predmetHeight = 20;
        private const int smerHeight = 30;
        
        public SmerControl(Smer smer, Panel panel): base(smer, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            Width = 200;
            Height = smerHeight;
            smerRec = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            predmetPanel = new Panel();
            predmetPanel.Width = Width;
            predmetPanel.Height = GuiObject.Predmeti.Count() * predmetHeight;
            predmetPanel.Location = new Point(0, smerHeight);
            predmetPanel.BackColor = parentPanel.BackColor;
            Height = smerHeight + GuiObject.Predmeti.Count() * predmetHeight;
            Controls.Add(predmetPanel);
        }

        protected override void onValueChaged(object sender, EventArgs e)
        {
            predmetPanel.Height = GuiObject.Predmeti.Count * predmetHeight;
            Height = smerHeight + GuiObject.Predmeti.Count() * predmetHeight;
            
            base.onValueChaged(sender, e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {


            Graphics g = pe.Graphics;

            Pen pen = new Pen(new SolidBrush(Color.Black), 1);

            g.FillRectangle(new SolidBrush(Color.Pink), ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.LightGray), smerRec);
            g.DrawRectangle(pen, smerRec);
            int inc = 1;
            foreach (Predmet pred in GuiObject.Predmeti)
            {

                g.DrawLine(pen, new Point(0, smerHeight + predmetHeight * inc), new Point(Width, smerHeight + predmetHeight * inc));
                inc++;
            }

            base.OnPaint(pe);

        }
    }
}
