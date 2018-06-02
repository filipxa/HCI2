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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcionicaControl controla;
          

            Action action = new CreateAction(new Ucionica("Djoka", "Opis", 20));
                DataControllercs.addAction(action);
                uc =  (Ucionica)action.getGUIObject();
            
                controla = new UcionicaControl(uc, panel1);
                controla.Width = 300;
                controla.Height = 300;
                controla.Location = new Point(30, 30);
                controla.Invalidate();
           
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action action = new DeleteAction(uc);
            DataControllercs.addAction(action);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataControllercs.undoAction();
        }
    }
}
