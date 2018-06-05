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
    public partial class RasporedControl : CustomControlBase<Raspored>
    {
        Panel datumPanel;
        Panel nedeljaPanel;
        NedeljaControl nedeljaControl;
        
        DateTimePicker dateTimePicker;

        const int  visinaDatePikera = 40;
        const int sirinaDatePikera = 115;

        Pen pen = new Pen(Color.Yellow, 3);
        public float visinaPodeoka=0;
        
        public RasporedControl(Raspored raspored, Panel panel): base(raspored, panel)
        {

            InitializeComponent();
           
            InitVremenaPanel();
            InitNedelja(new Nedelja(raspored,DateTime.Now));
            Resize += RasporedControl_Resize;
        }

        private void InitNedelja(Nedelja nedelja)
        {
            nedeljaPanel = new Panel();
            nedeljaPanel.Location = new Point(sirinaDatePikera, 0);
            nedeljaPanel.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            nedeljaPanel.Size = new Size((Width - sirinaDatePikera),Height);
            //nedeljaPanel.MinimumSize = new Size(200, 200);
            Controls.Add(nedeljaPanel);
           
            nedeljaControl = new NedeljaControl(nedelja, nedeljaPanel, pen, visinaDatePikera, this);

            nedeljaControl.Size = new Size(300, 300);
            nedeljaControl.Location = new Point(30, 30);
            nedeljaControl.Dock = DockStyle.Fill;
            
            nedeljaPanel.Controls.Add(nedeljaControl);
           

        }

        private void RasporedControl_Resize(object sender, EventArgs e)
        {
           // visinaPodeoka = (float)(Height - visinaDatePikera) / 16f;
           Refresh();
        }

        private void InitVremenaPanel()
        {
            //parentPanel.BackColor = Color.Red;
            datumPanel = new Panel();
            datumPanel.Width = sirinaDatePikera;
            
            datumPanel.Height = visinaDatePikera-2;
            datumPanel.Location = new Point(0, 0);
            datumPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top ;
            datumPanel.Controls.Add(dateTimePicker);

            dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = new Point(0, 0);
            dateTimePicker.Size = new Size((datumPanel.Width), (datumPanel.Height));
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd,MM, yy";
            dateTimePicker.Font = GraphicLoader.getFont(17);
            datumPanel.Controls.Add(dateTimePicker);
            Controls.Add(datumPanel);

        }



        protected override void OnPaint(PaintEventArgs pe)
        {
          
            PointF pointL;
            PointF pointR;
            visinaPodeoka = (Height-visinaDatePikera) / 16f ;
            if (datumPanel.Width == 0)
            {
                return;
            }

            string sat = "";
            string minute = ":00";
            string fulTime = "";
            SizeF size = new SizeF(datumPanel.Width, visinaPodeoka);
            PointF point = new PointF();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            Graphics g = pe.Graphics;
            
            for (int i = 0; i < 16; i++)
            {
                pointL = new PointF(0, (visinaPodeoka * i) + visinaDatePikera );
                pointR = new PointF(sirinaDatePikera, (visinaPodeoka * i) + visinaDatePikera );
                g.DrawLine(pen, pointL, pointR);
                sat = String.Format("{00:D2}", i + 7);
                fulTime = sat + minute;
                point = new PointF(0, (visinaPodeoka * i) + visinaDatePikera );
                g.DrawString(fulTime, GraphicLoader.getFontBold((float)(datumPanel.Width * 0.2)), new SolidBrush(Color.Black), new RectangleF(pointL, size), format);
            }
            pointL = new PointF(0, (visinaPodeoka * 16)-2 + visinaDatePikera );
            pointR = new PointF(Width, (visinaPodeoka * 16)-2 + visinaDatePikera);
            g.DrawLine(pen, pointL, pointR);

            base.OnPaint(pe);
        }
    }
}
