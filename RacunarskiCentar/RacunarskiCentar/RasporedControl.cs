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
        Panel satnicaPanel;
        Panel daniPanel;

        Nedelja nedelja;
        NedeljaControl nedeljaControl;
        
        DateTimePicker dateTimePicker;
        Panel nedeljaPanel;
        const int  visinaDatePikera = 40;
        const int sirinaDatePikera = 100;

        const int debljinaLinije = 3;
        Pen pen = new Pen(Color.Yellow, debljinaLinije);
        float visinaPodeoka;
        
        public RasporedControl(Raspored raspored, Panel panel): base(raspored, panel)
        {

            InitializeComponent();
            InitVremenaPanel();
            InitNedelja();
            Resize += RasporedControl_Resize;
        }

        private void InitNedelja()
        {
            nedeljaPanel = new Panel();
            nedeljaPanel.Location = new Point(sirinaDatePikera, 0);
            nedeljaPanel.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            nedeljaPanel.Size = new Size((int)(Width - sirinaDatePikera),Height);
            //nedeljaPanel.MinimumSize = new Size(200, 200);

            Controls.Add(nedeljaPanel);
            nedeljaControl = new NedeljaControl(nedelja, nedeljaPanel, pen,visinaPodeoka,debljinaLinije, visinaDatePikera);
            //ovaj panel poslati za nedelju
            //nedeljaControl = new NedeljaControl(nedelja,p);
        }

        private void RasporedControl_Resize(object sender, EventArgs e)
        {
           // visinaPodeoka = (float)(Height - visinaDatePikera) / 16f;
            Refresh();
        }

        private void InitVremenaPanel()
        {
            //parentPanel.BackColor = Color.Red;
            satnicaPanel = new Panel();
            satnicaPanel.Width = sirinaDatePikera;
            
            satnicaPanel.Height = visinaDatePikera-debljinaLinije-1;
            satnicaPanel.Location = new Point(0, 0);
            dateTimePicker = new DateTimePicker();
            satnicaPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top ;
            satnicaPanel.Controls.Add(dateTimePicker);
            dateTimePicker.Location = new Point(3, 3);
            //satnicaPanel.BackColor = Color.Chocolate;
            dateTimePicker.Size = new Size((int)(satnicaPanel.Width), (int)(satnicaPanel.Height));
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            //dateTimePicker.ShowUpDown = true;

            Controls.Add(satnicaPanel);
            //vremenaPanel.Paint
           // vremenaPanel.Paint += new PaintEventHandler(vremenaPanel_Paint);
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            PointF pointL;
            PointF pointR;
            visinaPodeoka = (float)(Height) / 17f-debljinaLinije;
            // visinaPodeoka = (parentPanel.Height - visinaDatePikera) / 15;
            if (satnicaPanel.Width == 0)
            {
                return;
            }
            Font font = new Font("Arial",(float)(satnicaPanel.Width * 0.2) , FontStyle.Bold, GraphicsUnit.Pixel);
            string sat = "";
            string minute = ":00";
            string fulTime = "";
            SizeF size = new SizeF(satnicaPanel.Width, visinaPodeoka);
            PointF point = new PointF();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            Graphics g = pe.Graphics;
            for (int i = 0; i < 16; i++)
            {
                //g.DrawLine(pen, 0, (visinaPodeoka * i) + visinaDatePikera - (i) , satnicaPanel.Width, (visinaPodeoka * i) + visinaDatePikera - i);
                pointL = new PointF(0, (visinaPodeoka * i) + visinaDatePikera - debljinaLinije);
                pointR = new PointF(Width, (visinaPodeoka * i) + visinaDatePikera - debljinaLinije);


                g.DrawLine(pen, pointL, pointR);
                sat = (i+7).ToString();

                if (sat.Length==1)
                {
                    sat = "0" + sat;
                }
                sat = String.Format("{00:D2}", sat);
                fulTime = sat + minute;
                point = new PointF(0, (visinaPodeoka * i) + visinaDatePikera - debljinaLinije);
                g.DrawString(fulTime, font, new SolidBrush(Color.Black), new RectangleF(pointL, size), format);
            }

            
        }
    }
}
