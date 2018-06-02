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
            controla.Click += Controla_Click;

        }

        private void Controla_Click(object sender, EventArgs e)
        {
            UcionicaControl uc = (UcionicaControl)sender;
            Action action = new DeleteAction(uc.GuiObject);
            DataControllercs.addAction(action);
            
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Ucionica uc = new Ucionica("DJOKA", "Stojko", 2);
            Action action = new CreateAction(uc);
            DataControllercs.addAction(action);
            Raspored r = new Raspored(uc);
            action = new CreateAction(r);
            DataControllercs.addAction(action);
            Nedelja ned = new Nedelja(r);
            action = new CreateAction(ned);
            DataControllercs.addAction(action);
          


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action action = DataControllercs.undoAction();
            if(action is CreateAction)
            {
                UcionicaControl controla;
                uc = (Ucionica)action.getGUIObject();
               controla = new UcionicaControl(uc, panel1);
                controla.Width = 300;
                controla.Height = 300;
                controla.Location = new Point(30, 30);
                controla.Invalidate();
            }
        }
    }
}
