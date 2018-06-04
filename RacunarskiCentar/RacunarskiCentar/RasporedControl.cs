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
        Graphics g;
        Pen pen = new Pen(Color.Yellow, 1);
        float visinaDatePikera = 20;
        public RasporedControl(Raspored raspored, Panel panel): base(raspored, panel)
        {

            InitializeComponent();
            InitVremenaPanel();
        }

        private void InitVremenaPanel()
        {
            vremenaPanel = new Panel();
            vremenaPanel.Width = parentPanel.Width;
            vremenaPanel.Height = parentPanel.Height / 10;
            vremenaPanel.Location = new Point(0, 0);

            DateTimePicker picker = new DateTimePicker();
            vremenaPanel.Controls.Add(picker);
            picker.Location = new Point(3, 3);
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "HH:mm";
            picker.ShowUpDown = true;




            Controls.Add(vremenaPanel);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
             
            float visinaPodeoka = (vremenaPanel.Height - visinaDatePikera) / 15;
            Font font = new Font("Arial",(float)(visinaPodeoka * 0.8) , FontStyle.Bold, GraphicsUnit.Pixel);
            string sat = "";
            string minute = ":00";
            string fulTime = "";
            SizeF size = new SizeF(vremenaPanel.Width-((int)visinaPodeoka / 10), vremenaPanel.Height);
            Point point = new Point();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            for (int i = 1; i < 16; i++)
            {
                g.DrawLine(pen, 0, (visinaPodeoka * i) + visinaDatePikera, vremenaPanel.Width, (visinaPodeoka * i) + visinaDatePikera);
                sat = i.ToString();
                sat = String.Format("{0:D2}", sat);
                fulTime = sat + minute;
                point = new Point(((i - 1) * (int)visinaPodeoka)-(int)visinaPodeoka/10,(int)(vremenaPanel.Width/10));
            }
            g.DrawString(fulTime, font, new SolidBrush(Color.Black), new RectangleF(point, size), format);



        }
    }
}
