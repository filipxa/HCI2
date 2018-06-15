using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace RacunarskiCentar
{
    
    class Tutorial
    { 
        TutorialControl tc;
        Dictionary<Control, EventHandlerList> controlHandler = new Dictionary<Control, EventHandlerList>();
        private Level currentLevel = Level.Nista;
        Form1 form;
        private bool levelZavrsen = false;
        private enum Level
        {
            Nista, Pocetak, ToolBar, ToolBoxPanel, MainPanel, UcionicaDKlik, UcionicaView, UVToolBox, UVSmer, UVPredmet, TerminMove
        }
        public Tutorial(Form1 f)
        {
            form = f;
            currentLevel = Level.Nista;
            DataControllercs.isTutorial = true;
            DataControllercs.allowedTypes.Add(typeof(EditAction));
            DataControllercs.allowedTypes.Add(typeof(RestoreAction));
        }
        private void removeControl()
        {
            if (tc == null)
                return;
            form.Controls.Remove(tc);
            tc.Dispose();
        }
        private void createControl(string text, float fontSize)
        {
            tc = new TutorialControl(text, fontSize, form);

            tc.Location = new Point((form.Width - tc.Width) / 2, (form.Height - tc.Height) / 4 * 3);
            form.Controls.Add(tc);
            tc.BringToFront();
            

        }
        public void nextStep()
        {
            removeControl();
            if (currentLevel == Level.Nista)
            {
                initPocetak();
            }
            else if (currentLevel == Level.Pocetak)
            {
                initToolBar();
            }
            else if (currentLevel == Level.ToolBar)
            {
                initToolBoxPanel();
            }
            else if (currentLevel == Level.ToolBoxPanel)
            {
                initMainPanel();
            }
            else if (currentLevel == Level.MainPanel)
            {
                InitUcionicaDKlik();
            }
            else if (currentLevel == Level.UcionicaDKlik)
            {
                initUcionicaView();
            }
            else if (currentLevel == Level.UcionicaView)
            {
                initUVToolBox();
            }
            else if (currentLevel == Level.UVToolBox)
            {
                initUVPredmet();
            }
            else if (currentLevel == Level.UVPredmet)
            {
                initTerminMove();
            }
            else if (currentLevel == Level.TerminMove)
            {
                DataControllercs.isTutorial = false;
            }
        }

        private void initTerminMove()
        {
            currentLevel = Level.TerminMove;
            DataControllercs.allowedTypes.Add(typeof(ChainAction));
            createControl("Prevucite termin na drugi dan kako bi ste ga pomerili.", 20);
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                if (levelZavrsen)
                {
                    levelZavrsen = false;
                    nextStep();
                }

            });

            DataControllercs.onAction += ActionExcuted;
        }

        private void initUVPredmet()
        {
            currentLevel = Level.UVPredmet;
            
            SmerControl sc = (SmerControl)form.toolboxPanel.Controls[0];
            PredmetControl p = (PredmetControl)sc.predmetPanel.Controls[0];
            p.IsTutorial = true;
            createControl("Prevucite obeleženi predmet na raspored kako biste napravili novi termin.", 20);
            DataControllercs.allowedTypes.Add(typeof(Termin));
            DataControllercs.allowedTypes.Add(typeof(CreateAction));

            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                if (levelZavrsen)
                {
                    levelZavrsen = false;
                    nextStep();
                }

            });
            tc.TextChanged+= new EventHandler(delegate (Object o, EventArgs a)
            {
                p.IsTutorial = false;

            });
            DataControllercs.onAction += ActionExcuted;
         

        }
        private void ActionExcuted(object sender, Action e)
        {
            if (currentLevel == Level.UVPredmet)
            {
                if (e is CreateAction)
                {
                    if (e.getGUIObject() is Termin)
                    {
                        tc.Text = "Uspešno ste napravili termin. \n Za nastavak pritisnite na ovaj prozor.";
                        levelZavrsen = true;
                        DataControllercs.onAction -= ActionExcuted;
                    }
                }
            }

            if (currentLevel == Level.TerminMove)
            {
                if (e is ChainAction)
                {
                    tc.Text = "Uspešno ste premestili termin! Pritisnite na ovaj prozor kako biste završili tutorijal.";
                    levelZavrsen = true;
                    DataControllercs.onAction -= ActionExcuted;
                    DataControllercs.isTutorial = false;
                }
            }


        }

        private void initUVToolBox()
        {
            currentLevel = Level.UVToolBox;
            SmerControl sc = (SmerControl)form.toolboxPanel.Controls[0];
            if (!sc.IsColapsed)
            {
                nextStep();
                return;
            }
            createControl("Pritisnite na smer kako biste vam se prikazali predmeti tog smera i kako biste nastavili tutorijal.", 20);
            MouseEventHandler e = new MouseEventHandler(delegate (Object o, MouseEventArgs a)
            {
                if (a.Button == MouseButtons.Left && a.Clicks == 1)
                {
                    tc.Text = "Uspešno ste otvorili prozor za izmenu Učionice. \n Za nastavak zatvorite dialog za izmenu i pritisnite na ovaj prozor.";
                    sc.IsTutorial = false;
                    nextStep();
                }


            });
            sc.IsTutorial = true;
            sc.MouseDown += e;
           
           
        }

        private void initUcionicaView()
        {

            currentLevel = Level.UcionicaView;
            UcionicaControl ucionica = (UcionicaControl)form.mainPanel.Controls[0];
            createControl("Kako biste pristupili izmeni rasporeda konkretne učionice i nastavku tutorijala pritisnite dupli klik na obeleženu učionicu.", 20);
            EventHandler e = new EventHandler(delegate (Object o, EventArgs a)
            {
                tc.Text = "Uspešno ste otvorili prikaz Učionice. \n Za nastavak pritisnite na ovaj prozor.";
                levelZavrsen = true;
                ucionica.IsTutorial = false;

            });
            ucionica.DoubleClick += e;
            ucionica.IsTutorial = true;
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                if (levelZavrsen)
                {
                    levelZavrsen = false;
                    nextStep();
                }

            });
          

        }

        private void InitUcionicaDKlik()
        {
            currentLevel = Level.UcionicaDKlik;
            createControl("Izmenu učionice možete izvršiti i desnim klikom na učionicu.\n Za nastavak stistnite desni klik za izmenu obeležene učionice.", 20);
            UcionicaControl ucionica = (UcionicaControl)form.mainPanel.Controls[0];

            MouseEventHandler e = new MouseEventHandler(delegate (Object o, MouseEventArgs a)
            {
                if (a.Button == MouseButtons.Right && a.Clicks == 1)
                {
                    tc.Text = "Uspešno ste otvorili prozor za izmenu Učionice. \n Za nastavak zatvorite dialog za izmenu i pritisnite na ovaj prozor.";
                    ucionica.IsTutorial = false;
                    levelZavrsen = true;
                }
                    

            });

            ucionica.MouseDown += e;
            ucionica.IsTutorial = true;
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                if (levelZavrsen)
                {
                    levelZavrsen = false;
                    nextStep();
                }

            });

        }

        private void initMainPanel()
        {
            currentLevel = Level.MainPanel;
            Color oldColor = form.mainPanel.BackColor;
            form.mainPanel.BackColor = Color.Yellow;
            createControl("Glavni panel, trenutno obeležen žutom bojom, se nalazi na desnoj strani ekrana i trenutno prikazuje sve ucionice. \n Za nastavak pritisnite na ovaj prozor.", 20);
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                form.mainPanel.BackColor = oldColor;
                nextStep();

            });
        }
        private void initToolBoxPanel()
        {
            currentLevel = Level.ToolBoxPanel;
            Color oldColor = form.toolboxPanel.BackColor;
            form.toolboxPanel.BackColor = Color.Yellow;
            createControl("ToolBoxPanel, trenutno obeležen žutom bojom, se nalazi na levoj strani ekrana i trenutno prikazuje dugmiće za dodavanje podataka. \n Za nastavak pritisnite na ovaj prozor.", 20);
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                form.toolboxPanel.BackColor = oldColor;
                nextStep();

            });
        }
        private void initToolBar()
        {

            currentLevel = Level.ToolBar;
            Color oldColor = form.tb.BackColor;
            createControl("Opcije kao sto su Undo, Redo, Nazad kao i pristupanje dijalozima za izmenu podataka se mogu naći u toolbara na vrhu, toolbar je privremeno obeležen žutom bojom radi lakšeg uočavanja.\n .", 17);
            form.tb.BackColor = Color.Yellow;
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                form.tb.BackColor = oldColor;
                nextStep();

            });
        }
        private void initPocetak()
        {
            currentLevel = Level.Pocetak;
            createControl("Dobrodošli u interaktivni tutorijal!\n Kako biste nastavili pritisnite na ovaj prozorčić. ", 30);
            tc.Click += new EventHandler(delegate (Object o, EventArgs a)
            {
                nextStep();

            });
        }


    }


    public class TutorialControl : Control
    {

        float fontSize = 0;
        Font font;
        StringFormat sf = new StringFormat();
        public TutorialControl(string text, float fontSize, Form1 form)
        {
            this.Text = text;
            this.fontSize = fontSize;
            InitializeComponent();
            font = GraphicLoader.getFontBold(fontSize);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(form.Width / 2, form.Height / 4);

            sf.Alignment = StringAlignment.Center;
            BringToFront();
            TextChanged += TutorialControl_TextChanged;
            
        }

        private void TutorialControl_TextChanged(object sender, EventArgs e)
        {
            Invalidate();
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
