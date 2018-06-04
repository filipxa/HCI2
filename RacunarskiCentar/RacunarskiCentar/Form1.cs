using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            initRCView();
            toolboxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            toolboxPanel.VerticalScroll.Minimum =0;


        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void resetPanels()
        {
            mainPanel.Controls.Clear(); // DISPOSE IF TIME
            toolboxPanel.Controls.Clear();
            toolboxPanel.VerticalScroll.Maximum = 0;
            
        }

    }

    /// <summary>
    /// RC RC        RC RC        RC RC        RC RC        RC RC
    /// </summary>
    public partial class Form1
    {
        private void initRCView()
        {
            toolboxPanel.Controls.Clear();
            mainPanel.Controls.Clear();
            Button button = new Button();
            button.Text = "Dodaj učionicu";
            button.Click += btDodajKlik;
            button.Size = new Size(toolboxPanel.Width, 30);
            button.Dock = DockStyle.Top;
            mainPanel.FlowDirection = FlowDirection.LeftToRight;
            mainPanel.Padding = new Padding(15);
            toolboxPanel.Controls.Add(button);

            
            ucitajUcionice();
        }

        private void ucitajUcionice()
        {
            foreach (Ucionica u in DataManger.getUcionice())
            {
                UcionicaControl c = new UcionicaControl(u, mainPanel);
                dodajUcionicu(c);
            }
        }

        private void dodajUcionicu(UcionicaControl c)
        {
            c.Width = 200;
            c.Height = 100;
            c.Margin = new Padding(30);
            mainPanel.Controls.Add(c);
            c.DoubleClick += Ucionica_DoubleClick;
        }

        private void btDodajKlik(object sender, EventArgs e)
        {
            UcionicaForm f = new UcionicaForm(null);
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                UcionicaControl c = new UcionicaControl((Ucionica)f.GetAction().getGUIObject(), mainPanel);
                dodajUcionicu(c);
            }

        }

        private void Ucionica_DoubleClick(object sender, EventArgs e)
        {
            UcionicaControl uc = (UcionicaControl)sender;
            initUcionicaView(uc.GuiObject);
        }




    }

    class TreeNodeObject : TreeNode
    {
        GUIObject o;
        public GUIObject GuiObject
        {
            get => o;
            set => o = value;
        }
        public TreeNodeObject(String name, GUIObject gui) : base(name)
        {
            GuiObject = gui;
        }
    }


    /// <summary>
    /// Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica
    /// </summary>

    public partial class Form1
    {
        List<Smer> smerovi = new List<Smer>();
        
        private void initUcionicaView(Ucionica ucionica)
        {
            Smer s = new Smer("SW", "SOft kobas", DateTime.Now, "");
            for (int i = 0; i < 10; i++)
            {
                Predmet p = new Predmet("p" + i.ToString(), "", "", "", 0, 0, 0);
                s.Predmeti.Add(p);
            }
            smerovi.Add(s);
            resetPanels();
            
            populatePredmets();
            toolboxPanel.AutoScroll = true;

        }



        private void populatePredmets()
        {

            for (int i = 0; i < 15; i++)
            {
                foreach (Smer smer in smerovi)
                {

                     SmerControl sc = new SmerControl(smer, toolboxPanel);

                    sc.Dock = DockStyle.Top;
                    
                    toolboxPanel.Controls.Add(sc);


                }
            }
            
            

        }

    }
}
