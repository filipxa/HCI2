using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class Form1 : Form
    {
        Ucionica uc;
        public Form1()
        {
            InitializeComponent();
            initUcionicaView();
            toolboxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

        }

        private void initUcionicaView()
        {


            Button button = new Button();
            button.Text = "Dodaj ucionicu";
            button.Click += addUcionica;
            button.Size = new Size(toolboxPanel.Width, 30);
            button.Dock = DockStyle.Top;

            toolboxPanel.Controls.Add(button);

        }

        private void addUcionica(object sender, EventArgs e)
        {
            
            UcionicaForm f = new UcionicaForm(null);
          
            DialogResult result = f.ShowDialog();
            if(result == DialogResult.OK)
            {
                UcionicaControl c = new UcionicaControl((Ucionica)f.GetAction().getGUIObject(), MainPanel);
                c.Width = 200;
                c.Height = 100;
                c.Location = new Point(30, 30);
                MainPanel.Controls.Add(c);
                c.Invalidate();
            }

        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
