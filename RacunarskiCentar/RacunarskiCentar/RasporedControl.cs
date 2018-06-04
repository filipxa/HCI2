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
        Panel vremenaPanel;
        Panel daniPanel;
        
        Pen pen = new Pen(Color.Yellow, 5);
        DateTimePicker dateTimePicker;
        const int  visinaDatePikera = 30;
        float visinaPodeoka;
        
        public RasporedControl(Raspored raspored, Panel panel): base(raspored, panel)
        {

            InitializeComponent();
            visinaPodeoka = (parentPanel.Height - visinaDatePikera) / 15;
            InitVremenaPanel();
        }

        private void InitVremenaPanel()
        {
            vremenaPanel = new Panel();
            vremenaPanel.Width = parentPanel.Width/8;
            vremenaPanel.Height = visinaDatePikera;
            vremenaPanel.Location = new Point(0, 0);
            dateTimePicker = new DateTimePicker();
            vremenaPanel.Controls.Add(dateTimePicker);
            dateTimePicker.Location = new Point(3, 3);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "HH:mm";
            dateTimePicker.ShowUpDown = true;

            Controls.Add(vremenaPanel);
            //vremenaPanel.Paint
           // vremenaPanel.Paint += new PaintEventHandler(vremenaPanel_Paint);
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            visinaPodeoka = (parentPanel.Height - visinaDatePikera) / 15;
            Font font = new Font("Arial",(float)(visinaPodeoka * 0.5) , FontStyle.Bold, GraphicsUnit.Pixel);
            string sat = "";
            string minute = ":00";
            string fulTime = "";
            SizeF size = new SizeF(vremenaPanel.Width, visinaPodeoka);
            PointF point = new PointF();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            Graphics g = pe.Graphics;
            for (int i = 0; i < 16; i++)
            {
                g.DrawLine(pen, 0, (visinaPodeoka * i) + visinaDatePikera, vremenaPanel.Width, (visinaPodeoka * i) + visinaDatePikera);
                sat = (i+7).ToString();

                if (sat.Length==1)
                {
                    sat = "0" + sat;
                }
                sat = String.Format("{000:D2}", sat);
                fulTime = sat + minute;
                point = new PointF(0, (visinaPodeoka * i) + visinaDatePikera);
                g.DrawString(fulTime, font, new SolidBrush(Color.Black), new RectangleF(point, size), format);
            }

            
        }
    }
}
