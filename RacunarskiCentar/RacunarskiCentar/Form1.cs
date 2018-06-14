using System;
using System.Collections.Generic;
using System.Drawing;
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
        Panel mainPanel;
        Panel toolboxPanel;
        ToolStrip tb = new ToolStrip();

        UcionicaFilterForm uff = new UcionicaFilterForm();
        SmerFilterForm sff = new SmerFilterForm();
        //PredmetFilterForm pff = new PredmetFilterForm();
        SoftwareFilterForm soff = new SoftwareFilterForm();
        ToolStripButton undoButton;
        ToolStripButton redoButton;

        public Form1()
        {
            DataManger.load();
            ToolStripButton b;

            KeyDown += Form1_KeyDown;
            b = new ToolStripButton();
            b.Click += nazadButtonClick;
            b.Text = "Nazad";
            tb.Items.Add(b);

            undoButton = new ToolStripButton();
            undoButton.Text = "Undo";
            undoButton.Click += Undo_Click1;
            undoButton.Enabled = false;
            tb.Items.Add(undoButton);

            redoButton = new ToolStripButton();
            redoButton.Text = "Redo";
            redoButton.Enabled = false;
            redoButton.Click += Redo_Click1;
            tb.Items.Add(redoButton);




            b = new ToolStripButton();
            b.Text = "Filter ucionica";
            b.Click += ToolFilterUcionica;
            tb.Items.Add(b);

            b = new ToolStripButton();
            b.Text = "Filter smera";
            b.Click += ToolFilterSmera;
            tb.Items.Add(b);

            b = new ToolStripButton();
            b.Text = "Filter predmeta";
            b.Click += ToolFilterPredmeta;
            tb.Items.Add(b);

            b = new ToolStripButton();
            b.Text = "Filter softvera";
            b.Click += ToolFilterSoftvera;
            tb.Items.Add(b);

            FormClosing += Form1_FormClosing;

            DataControllercs.onAction += ActionExcuted;
            KeyPreview = true;

            InitializeComponent();
            BackColor = GraphicLoader.getColorLightGray();
            tb.BackColor = Color.DarkGray;

            Controls.Add(tb);
            initRCView();

            ClientSize = new Size(1000, 800);
            MinimumSize = Size;
            ResizeEnd += Form1_ResizeEnd;
            ResizeBegin += Form1_ResizeBegin;

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
            soff.ShowDialog();
        }

        private void ToolFilterSmera(object sender, EventArgs e)
        {
            sff.ShowDialog();
        }

        private void ToolFilterPredmeta(object sender, EventArgs e)
        {
            PredmetFilterForm pff = new PredmetFilterForm();
            pff.ShowDialog();
        }

        private void ToolFilterUcionica(object sender, EventArgs e)
        {
            uff.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManger.save();
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
                        dodajSmerControl(s);   
                    }
                }
            }
            redoButton.Enabled = DataControllercs.RedoAvailable();
            undoButton.Enabled = DataControllercs.UndoAvailable();
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
            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
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



        private void initUcionicaView(Ucionica ucionica)
        {
            currentView = FormView.UCIONICA;
            initMainPanel();
            initToolPanelTable();

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
            toolboxPanel.Padding = new Padding(13, 0, 0, 0);
            foreach (Smer smer in DataManger.getSmers())
            {
                dodajSmerControl(smer);
            }
        }

        private void dodajSmerControl(Smer s)
        {
            TableLayoutPanel t = (TableLayoutPanel)toolboxPanel;
            SmerControl sc = new SmerControl(s, toolboxPanel);
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
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
                btDodajKlik(null, null);
            else if (e.KeyCode == Keys.F2)
                btSoftverKlik(null, null);
            else if (e.KeyCode == Keys.F3)
                btSmerKlik(null, null);
            else if (e.KeyCode == Keys.F4)
                btSmerKlik(null, null);
            else if (e.KeyCode == Keys.F9)
                MessageBox.Show("Help");
            else if (e.KeyCode == Keys.Back)
                MessageBox.Show("Back");

            if (e.Control && e.KeyCode == Keys.Z)
                MessageBox.Show("Undo");
        }
    }
    // Tutorial     Tutorial        Tutorial        Tutorial        Tutorial
    public partial class Form1
    {
        
        



    }






}
 