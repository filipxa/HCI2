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

        public const float sirinaOlovke = 1.5f; 
        public float visinaPodeoka=0;
        public const int brPodeoka = 60;
        //Velicina podeoka u minutama
        public const int velicinaPodeoka = 15;
        
        
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
            Controls.Add(nedeljaPanel);
           
            nedeljaControl = new NedeljaControl(nedelja, nedeljaPanel, visinaDatePikera, this);

            nedeljaControl.Dock = DockStyle.Fill;
            
            nedeljaPanel.Controls.Add(nedeljaControl);
           

        }

        private void RasporedControl_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void InitVremenaPanel()
        {
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
            visinaPodeoka = (Height-visinaDatePikera) / (float) brPodeoka ;
            if (datumPanel.Width == 0)
            {
                return;
            }

            SizeF size = new SizeF(datumPanel.Width, visinaPodeoka * (60f / velicinaPodeoka));
            PointF point = new PointF();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            Graphics g = pe.Graphics;
            Pen penBold = new Pen(Color.Yellow, sirinaOlovke*3);
            DateTime pocetak = new DateTime(1, 1, 1, 7, 0, 0);
            
            for (int i = 0; i <= brPodeoka; i++)
            {
                if(pocetak.Minute == 0)
                {
                    pointL = new PointF(0, (visinaPodeoka * i) + visinaDatePikera);
                    pointR = new PointF(sirinaDatePikera, (visinaPodeoka * i) + visinaDatePikera);
                    g.DrawLine(penBold, pointL, pointR);


                    point = new PointF(0, (visinaPodeoka * i) + visinaDatePikera);
                    g.DrawString(pocetak.ToString("HH:mm"), GraphicLoader.getFontBold(size.Height/3f), new SolidBrush(Color.Black), new RectangleF(point, size), format);
                   
                }

                pocetak = pocetak.AddMinutes(15);
            }
            pointL = new PointF(0, (visinaPodeoka * brPodeoka) -2 + visinaDatePikera );
            pointR = new PointF(Width, (visinaPodeoka * brPodeoka) -2 + visinaDatePikera);
            g.DrawLine(penBold, pointL, pointR);
            base.OnPaint(pe);
        }
    }
}
