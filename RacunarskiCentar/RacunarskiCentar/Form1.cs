using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class Form1 : Form
    {
        GUIObject activeObject = null;
        private const int toolWidth = 250;
        Panel mainPanel;
        Panel toolboxPanel;
        ToolStrip tb = new ToolStrip();
       
        public Form1()
        {
            ToolStripButton b = new ToolStripButton();
            b.Text = "Nazad";
            b.Click += B_Click;
            tb.Items.Add(b);
            b = new ToolStripButton();
            b.Text = "Undo";
            
            tb.Items.Add(b);
            b.Click += B_Click1;
            
            InitializeComponent();
            BackColor = GraphicLoader.getColorLightGray();
            tb.BackColor = Color.DarkGray;
            
            Controls.Add(tb);
            initRCView();
         
            
            ClientSize = new Size(1000,800);
            MinimumSize = Size;
            ResizeEnd += Form1_ResizeEnd;
            ResizeBegin += Form1_ResizeBegin;

        }

        private void B_Click1(object sender, EventArgs e)
        {
            if (DataControllercs.undoAvailable())
            {
                Action a = DataControllercs.undoAction();
                initCurrentView();
              
            }
            else
            {
                MessageBox.Show("Undo nije dostupan!");
            }
           
        }

        private void initCurrentView()
        {
            if (activeObject == null)
            {
                initRCView();
            } else if(activeObject.GetType().Equals(typeof(Ucionica)))
            {
                initUcionicaView((Ucionica)activeObject);
            }
        }

        private void B_Click(object sender, EventArgs e)
        { 

            if (activeObject!=null && activeObject.GetType().Equals(typeof(Ucionica)))
            {
                initRCView();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            mainPanel.ResumeLayout(true);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            mainPanel.SuspendLayout();
        }



        private void initMainPanelFlow()
        {
            FlowLayoutPanel p = new FlowLayoutPanel();
            p = new FlowLayoutPanel();
            p.Padding = new Padding(15);
            p.FlowDirection = FlowDirection.LeftToRight;
            p.AutoScroll = true;
            p.VerticalScroll.Visible = false;
            initMainPanel(p);
        }

        private void initMainPanel()
        {
            initMainPanel(new Panel());

        }


        private void initMainPanel(Panel p)
        {
            p.Anchor = AnchorStyles.Right |AnchorStyles.Top  | AnchorStyles.Bottom | AnchorStyles.Left;
            p.MinimumSize = new Size(ClientSize.Width - toolWidth, ClientSize.Height - tb.Height);
            p.Location = new Point(toolWidth, tb.Height);
            p.BackColor = GraphicLoader.getColorLightGray();


            Controls.Add(p);

            if (mainPanel != null)
            {
                mainPanel.Dispose();
                Controls.Remove(mainPanel);
            }
            mainPanel = p;

        }

        private void initToolPanel(Panel p)
        {
            if (toolboxPanel != null)
                toolboxPanel.Dispose();
            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom ;
            p.MinimumSize = new Size(toolWidth, ClientSize.Height - tb.Height);
            p.Location = new Point(0, tb.Height);
         
            p.BackColor = GraphicLoader.getColorDarkGray();
            Controls.Add(p);
            toolboxPanel = p;


        }
        private void initToolPanel()
        { 
            initToolPanel(new Panel());
        }

        private void initToolPanelTable()
        {
            Panel p = new TableLayoutPanel();
           
            initToolPanel(p);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



    }

    /// <summary>
    /// RC RC        RC RC        RC RC        RC RC        RC RC
    /// </summary>
    public partial class Form1
    {

        
        private void initRCView()
        {
             activeObject = null;
            initMainPanelFlow();
            initToolPanel();
            Button button = new Button();
            button.Text = "Dodaj učionicu";
            button.Click += btDodajKlik;
            button.BackColor = Color.LightGray;
            button.Size = new Size(toolboxPanel.Width, 30);

            button.Dock = DockStyle.Top;
          
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
            c.Height = 150;
            c.Margin = new Padding(15);
            
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
            activeObject = ucionica;
            initMainPanel();
            initToolPanelTable();
            Smer s = new Smer("SW", "SOft kobas", DateTime.Now, "");
            for (int i = 0; i < 10; i++)
            {
                Predmet p = new Predmet("p" + i.ToString(), "", s, "", 0, i, 0);
                s.Predmeti.Add(p);
            }
            smerovi.Add(s);

            populatePredmets();


            Raspored r = new Raspored(ucionica);
            RasporedControl rc = new RasporedControl(r, mainPanel);
            rc.Dock = DockStyle.Fill;


            mainPanel.Controls.Add(rc);
            toolboxPanel.AutoScroll = true;

        }


        SmerControl selectedSmerControl = null;
        private void populatePredmets()
        {
            TableLayoutPanel t = (TableLayoutPanel)toolboxPanel;
            toolboxPanel.Padding = new Padding(15,0,0,0) ;
            for (int i = 0; i < 8; i++)
            {
                foreach (Smer smer in smerovi)
                {
                    
                    SmerControl sc = new SmerControl(smer, toolboxPanel);
                    sc.ColapseedChanged += Sc_ValueChanged;
                    t.Controls.Add(sc);

                }
            }



        }

        private void Sc_ValueChanged(object sender, EventArgs e)
        {
            if((SmerControl)sender == selectedSmerControl)
            {
                return;
            }
            if (selectedSmerControl != null && selectedSmerControl.IsColapsed == false)
            {
                selectedSmerControl.IsColapsed = true;
            }
            selectedSmerControl = (SmerControl)sender;

        }
    }
}
