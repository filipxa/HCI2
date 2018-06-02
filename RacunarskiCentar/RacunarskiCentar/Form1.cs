using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class Form1 : Form
    {
        UcionicaControl controla;
        Ucionica uc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controla == null)
            {
                uc = new Ucionica("Djoka", "Opis", 20);
                controla = new UcionicaControl(uc);
                controla.Width = 300;
                controla.Height = 300;
                controla.Location = new Point(30, 30);
                controla.Invalidate();

            }
            
            Controls.Add(controla);
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uc.ID = DateTime.Now.ToLongTimeString();
        }
    }
}
