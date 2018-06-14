using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace RacunarskiCentar
{
    
    class Tutorial
    {
        TutorialControl tc;
        private Level currentLevel = Level.Nista;
        Form1 form;
        private enum Level
        {
            Nista, Pocetak
        }
        public Tutorial(Form1 f)
        {
            form = f;
            currentLevel = Level.Nista;
        }
        public void nextStep()
        {
            if (currentLevel == Level.Nista)
            {
                
                initPocetak();
            }
        }

        private void initPocetak()
        {

            tc = new TutorialControl("Dobrodošli u interaktivni tutorijal!\n Kako biste nastavili pritisnite na ovaj prozorčić. ", 30);
            form.Controls.Add(tc);
            tc.BringToFront();
            tc.Location = new Point((form.Width-tc.Width)/2, (form.Height-tc.Height)/2);
        }
    }


    public class TutorialControl : Control
    {

        float fontSize = 0;
        Font font;
        StringFormat sf = new StringFormat();
        public TutorialControl(string text, float fontSize)
        {
            this.Text = text;
            this.fontSize = fontSize;
            InitializeComponent();
            font = GraphicLoader.getFontBold(fontSize);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = TextRenderer.MeasureText(Text, font, Size, TextFormatFlags.HorizontalCenter | TextFormatFlags.TextBoxControl);
            Width += (int)fontSize;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            BringToFront();
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                
            }
            font.Dispose();
            sf.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle rec = ClientRectangle;
            Graphics g = pe.Graphics;
            Pen p = new Pen(Color.Black, 2);
          
            g.DrawString(Text, font, new SolidBrush(Color.Yellow), rec, sf);
            Rectangle frame = new Rectangle(1, 1, Width - 2, Height - 2);
            g.DrawRectangle(p, frame);
            
            base.OnPaint(pe);

        }


    }

    }
