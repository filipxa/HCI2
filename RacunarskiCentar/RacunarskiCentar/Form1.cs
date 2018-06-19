using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    enum FormView
    {
        RACUNARSKI_CENTAR, UCIONICA
    }



    public partial class Form1 : Form
    {

        FormView currentView = FormView.RACUNARSKI_CENTAR;
        private const int toolWidth = 250;
        public Panel mainPanel;
        public Panel toolboxPanel;
        public ToolStrip tb = new ToolStrip();
        public StatusStrip sStrip = new StatusStrip();
        Ucionica aktivnaUcionica;

        UcionicaFilterForm uff = new UcionicaFilterForm();
        SmerFilterForm sff = new SmerFilterForm();
        SoftwareFilterForm soff = new SoftwareFilterForm();
        PredmetFilterForm pff = new PredmetFilterForm();

        List<ToolStripButton> undoButtons = new List<ToolStripButton>();
        List<ToolStripButton> redoButtons = new List<ToolStripButton>();
        List<ToolStripLabel> statusLabels = new List<ToolStripLabel>();
        
        public ToolStrip generateToolStrip()
        {
            ToolStripButton b;
            ToolStrip tb = new ToolStrip();
            b = new ToolStripButton
            {
                Text = "Nazad",
                Name = "nazad"
            };

            if (undoButtons.Count == 0)
            {
                b.Click += nazadButtonClick;
            }
            else
            {
                b.Click += filterFormaNazadKlik;
            }
            tb.Items.Add(b);


            ToolStripButton undoButton = new ToolStripButton
            {
                Text = "Undo",
                Name = "undo",
                Enabled = false
            };
            undoButton.Click += Undo_Click1;
            undoButtons.Add(undoButton);
            tb.Items.Add(undoButton);
            undoButton.ToolTipText = "Undo (CTRL+Z)";



            ToolStripButton redoButton = new ToolStripButton
            {
                Text = "Redo",
                Name = "redo",
                Enabled = false
            };
            redoButton.Click += Redo_Click1;
            tb.Items.Add(redoButton);
            redoButtons.Add(redoButton);
            redoButton.ToolTipText = "Redo (CTRL+Y)";



            if (undoButtons.Count == 1)
            {
                b = new ToolStripButton();
                b.Text = "Učionice";
                b.Click += ToolFilterUcionica;
                tb.Items.Add(b);
                b.ToolTipText="Učionice (CTRL+1)";

                b = new ToolStripButton();
                b.Text = "Smerovi";
                b.Click += ToolFilterSmera;
                tb.Items.Add(b);
                b.ToolTipText = "Smerovi (CTRL+2)";

                b = new ToolStripButton();
                b.Text = "Predmeti";
                b.Click += ToolFilterPredmeta;
                tb.Items.Add(b);
                b.ToolTipText = "Predmeti (CTRL+3)";

                b = new ToolStripButton();
                b.Text = "Softveri";
                b.Click += ToolFilterSoftvera;
                tb.Items.Add(b);
                b.ToolTipText = "Softveri (CTRL+4)";

                b = new ToolStripButton();
                b.Click += (object sender, EventArgs e) =>
                {
                    Tutorial t = new Tutorial(this);
                    t.nextStep();
                };
                b.Text = "Tutorijal";
                tb.Items.Add(b);
            }

            tb.BackColor = Color.DarkGray;
            return tb;
        }



        public StatusStrip generateStatusBar()
        {
            StatusStrip sb = new StatusStrip();
            sb.BackColor = Color.DarkGray;
            ToolStripLabel l = new ToolStripLabel();
            l.Font = GraphicLoader.getFontBold(10);
            l.BackColor = sb.BackColor;
            sb.Height = 20;
            l.Text = "";
            statusLabels.Add(l);
            sb.Items.Add(l);
            return sb;
        }

        private void filterFormaNazadKlik(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            Form f = (Form)button.GetCurrentParent().Parent;
            f.Hide();
            BringToFront();
        }

        public Form1()
        {
            undoButtons = new List<ToolStripButton>();
            redoButtons = new List<ToolStripButton>();
            DataManger.load();
            

            KeyDown += shortcutKeydown;
            KeyDown += Form1_KeyDown;
            tb = generateToolStrip();



            DataControllercs.onAction += ActionExcuted;
            KeyPreview = true;

            InitializeComponent();
            BackColor = GraphicLoader.getColorLightGray();
           

            Controls.Add(tb);
            initRCView();

            ClientSize = new Size(1000, 700);
            MinimumSize = Size;
            ResizeEnd += Form1_ResizeEnd;
            ResizeBegin += Form1_ResizeBegin;

            uff.BackColor = GraphicLoader.getColorLightGray();
            sff.BackColor = GraphicLoader.getColorLightGray();
            soff.BackColor = GraphicLoader.getColorLightGray();
            pff.BackColor = GraphicLoader.getColorLightGray();


            uff.Controls.Add(generateToolStrip());
            uff.Controls.Add(generateStatusBar());
            uff.KeyDown += shortcutKeydown;
            uff.KeyPreview = true;

            sff.Controls.Add(generateToolStrip());
            sff.Controls.Add(generateStatusBar());
            sff.KeyDown += shortcutKeydown;
            sff.KeyPreview = true;

            soff.Controls.Add(generateToolStrip());
            soff.Controls.Add(generateStatusBar());
            soff.KeyDown += shortcutKeydown;
            soff.KeyPreview = true;

            pff.Controls.Add(generateToolStrip());
            pff.Controls.Add(generateStatusBar());
            pff.KeyDown += shortcutKeydown;
            pff.KeyPreview = true;
            sStrip = generateStatusBar();
            Controls.Add(sStrip);

        }

        private void nazadButtonClick(object sender, EventArgs e)
        {
            if (currentView.Equals(FormView.UCIONICA))
            {
                initRCView();
            }
        }

        private void Redo_Click1(object sender, EventArgs e)
        {
            DataControllercs.redoAction();
        }

        private void ToolFilterSoftvera(object sender, EventArgs e)
        {
            if (!soff.Visible)
            {
                soff.Show();
            }
            else
            {
                soff.Hide();
            }
        }

        private void ToolFilterSmera(object sender, EventArgs e)
        {
            if (!sff.Visible)
            {
                sff.Show();
            }
            else
            {
                sff.Hide();
            }
        }

        private void ToolFilterPredmeta(object sender, EventArgs e)
        {
            if (!pff.Visible)
            {
                pff.Show();
            }
            else
            {
                pff.Hide();
            }
        }

        private void ToolFilterUcionica(object sender, EventArgs e)
        {

            if (!uff.Visible)
            {
                uff.Show();
            }
            else
            {
                uff.Hide();
            }
        }



        private void ActionExcuted(object sender, Action e)
        {
            if(e is CreateAction)
            {
                if (currentView == FormView.RACUNARSKI_CENTAR)
                {
                    Ucionica u = e.getGUIObject() as Ucionica;
                    if (u != null)
                    {
                        UcionicaControl c = new UcionicaControl(u, mainPanel);
                        dodajUcionicu(c);
                    }
                } else if(currentView == FormView.UCIONICA)
                {
                    Smer s = e.getGUIObject() as Smer;
                    if (s != null)
                    {
                        dodajSmerControl(s, aktivnaUcionica);   
                    }
                }
               
            } else if (e is EditAction)
            {
                 if(currentView == FormView.UCIONICA)
                {
                    Ucionica u = e.getGUIObject() as Ucionica;
                    if (u != null)
                    {
                        if (u == aktivnaUcionica)
                        {
                            initUcionicaView(u);
                        }
                    }
                }
            }
            foreach(ToolStripButton b in undoButtons)
            {
                b.Enabled = DataControllercs.UndoAvailable();
            }
            foreach (ToolStripButton b in redoButtons)
            {
                b.Enabled = DataControllercs.RedoAvailable();
            }
            foreach (ToolStripLabel l in statusLabels)
            {
                l.Text = e.ToString();
            }

        }

        private void Undo_Click1(object sender, EventArgs e)
        {
            if (DataControllercs.undoAvailable())
            {
                Action a = DataControllercs.undoAction();
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
            p.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            p.MinimumSize = new Size(ClientSize.Width - toolWidth, ClientSize.Height - tb.Height-20);
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
            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            p.MinimumSize = new Size(toolWidth, ClientSize.Height - tb.Height-20);
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


        public void initRCView()
        {
            currentView = FormView.RACUNARSKI_CENTAR;
            initMainPanelFlow();
            initToolPanel();

            Button button = new Button();
            button.Text = "Dodaj učionicu";
            button.Click += btDodajKlik;
            button.BackColor = Color.LightGray;
            button.Size = new Size(toolboxPanel.Width, 30);
            button.Dock = DockStyle.Top;

            Button button1 = new Button();
            button1.Text = "Dodaj smer";
            button1.Click += btSmerKlik;
            button1.BackColor = Color.LightGray;
            button1.Size = new Size(toolboxPanel.Width, 30);
            button1.Dock = DockStyle.Top;

            Button button2 = new Button();
            button2.Text = "Dodaj softver";
            button2.Click += btSoftverKlik;
            button2.BackColor = Color.LightGray;
            button2.Size = new Size(toolboxPanel.Width, 30);
            button2.Dock = DockStyle.Top;

            Button button3 = new Button();
            button3.Text = "Dodaj predmet";
            button3.Click += btPredmetKlik;
            button3.BackColor = Color.LightGray;
            button3.Size = new Size(toolboxPanel.Width, 30);
            button3.Dock = DockStyle.Top;

            toolboxPanel.Controls.Add(button);
            toolboxPanel.Controls.Add(button1);
            toolboxPanel.Controls.Add(button2);
            toolboxPanel.Controls.Add(button3);



            ucitajUcionice();

            
            ToolTip toolTip1 = new ToolTip();
            
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            
            toolTip1.ShowAlways = true;
            
            toolTip1.SetToolTip(button, "Dodaj učionicu (Alt+1)");
            toolTip1.SetToolTip(button1, "Dodaj smer (Alt+2)");
            toolTip1.SetToolTip(button2, "Dodaj softver (Alt+3)");
            toolTip1.SetToolTip(button3, "Dodaj predmet (Alt+4)");


        }

        private void btPredmetKlik(object sender, EventArgs e)
        {
            PredmetForm f = new PredmetForm(null, null);  //SREDITI STA SE PROSLEDJUJE
            f.ShowDialog();
            f.Dispose();
        }

        private void btSoftverKlik(object sender, EventArgs e)
        {
            SoftwareForm f = new SoftwareForm(null);
            f.ShowDialog();
            f.Dispose();
           
        }

        private void btSmerKlik(object sender, EventArgs e)
        {
            SmerForm f = new SmerForm(null);
            f.ShowDialog();
            f.Dispose();
        }

        private void btDodajKlik(object sender, EventArgs e)
        {
            UcionicaForm f = new UcionicaForm(null);
            f.ShowDialog();
            f.Dispose();

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

        

        private void Ucionica_DoubleClick(object sender, EventArgs e)
        {
            if (!DataControllercs.isTutorial)
            {
                UcionicaControl uc = (UcionicaControl)sender;
                initUcionicaView(uc.GuiObject);
            }
            
           
        }

    }




    /// <summary>
    /// Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica    Ucionica
    /// </summary>

    public partial class Form1
    {

        public void initUcionicaView(Ucionica ucionica)
        {
            aktivnaUcionica = ucionica;
            currentView = FormView.UCIONICA;
            initMainPanel();
            initToolPanelTable();

            populatePredmets(ucionica);

            Raspored r = ucionica.Raspored;
            RasporedControl rc = new RasporedControl(r, mainPanel);
            rc.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(rc);
            toolboxPanel.AutoScroll = true;

        }


        SmerControl selectedSmerControl = null;
        private void populatePredmets(Ucionica ucionica)
        {
            TableLayoutPanel t = (TableLayoutPanel)toolboxPanel;
            toolboxPanel.Padding = new Padding(13, 0, 0, 0);
            foreach (Smer smer in DataManger.getSmers())
            {
                dodajSmerControl(smer, ucionica);
            }
        }

        private void dodajSmerControl(Smer s, Ucionica ucionica)
        {
            TableLayoutPanel t = (TableLayoutPanel)toolboxPanel;
            SmerControl sc = new SmerControl(s, toolboxPanel, ucionica);
            sc.ColapseedChanged += Sc_ValueChanged;
            t.Controls.Add(sc);
        }

        private void Sc_ValueChanged(object sender, EventArgs e)
        {
            if ((SmerControl)sender == selectedSmerControl)
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

    // PRECICE  PRECICE PRECICE PRECICE PRECICE PRECICE PRECICE PRECICE PRECICE PRECICE
    public partial class Form1
    {
        private void shortcutKeydown(object sender, KeyEventArgs e)
        {

             if (e.Control && e.KeyCode == Keys.D1)
                ToolFilterUcionica(sender, e);
            else if (e.Control && e.KeyCode == Keys.D2)
                ToolFilterSmera(sender, e);
            else if (e.Control && e.KeyCode == Keys.D3)
                ToolFilterPredmeta(sender, e);
            else if (e.Control && e.KeyCode == Keys.D4)
                ToolFilterSoftvera(sender, e);

            else if (e.Alt && e.KeyCode == Keys.D1)
                btDodajKlik(sender, e);
            else if (e.Alt && e.KeyCode == Keys.D2)
                btSmerKlik(sender, e);
            else if (e.Alt && e.KeyCode == Keys.D3)
                btPredmetKlik(sender, e);
            else if (e.Alt && e.KeyCode == Keys.D4)
                btSoftverKlik(sender, e);

            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo_Click1(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo_Click1(null, null);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if(currentView == FormView.RACUNARSKI_CENTAR)
                {
                    DataManger.goToHelp("racunarskiCentarForma");
                } else
                {
                    DataManger.goToHelp("ucionicaForma");
                }
                
            }
               

        }
    }
    // Tutorial     Tutorial        Tutorial        Tutorial        Tutorial
    public partial class Form1
    {

    }






}
 