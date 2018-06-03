using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class UcionicaControl : CustomControlBase<Ucionica>
    {
        public UcionicaControl(Ucionica ucionica, Panel panel) : base(ucionica, panel)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            MouseClick += EditClick;
            MouseDown += UcionicaControl_MouseDown;
        }

        private void UcionicaControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                DoDragDrop(this, DragDropEffects.All);
            }

        }

        public void EditClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                EditData();
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                EditData();
            }

        }

        public void EditData()
        {
            UcionicaForm f = new UcionicaForm(GuiObject);
            f.ShowDialog();
            f.GetAction();
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle rc = ClientRectangle;
            rc.Width = Width;
            rc.Height = Height;
            Font f = new Font("Verdana", (float)rc.Height * 0.2f, FontStyle.Bold, GraphicsUnit.Pixel);

  

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string p = Path.Combine(path, "Panel");
          

            string[] fileEntries = Directory.GetFiles(p);
            string assetsPath = Path.Combine(path, "Panel" , "assets");

            foreach (string fileName in fileEntries)
            {
                Bitmap bmp = new Bitmap(fileName);




                g.DrawImage(bmp, rc);
            }
            foreach (string fileName in Directory.GetFiles(assetsPath))
            {
                Bitmap bmp = new Bitmap(fileName);
                string number = Path.GetFileName(fileName);
                number = number.Substring(0, number.IndexOf("."));
                UcionicaAssets test =(UcionicaAssets)Convert.ToInt32(number);
                if (GuiObject.Assets.Contains(test))
                    g.DrawImage(bmp, rc);
            }


        }


    }
}
