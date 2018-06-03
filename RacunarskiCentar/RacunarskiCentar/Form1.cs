﻿using System;
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

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void resetPanels()
        {
            mainPanel.Controls.Clear(); // DISPOSE IF TIME
            toolboxPanel.Controls.Clear();
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
            button.Click += addUcionica;
            button.Size = new Size(toolboxPanel.Width, 30);
            button.Dock = DockStyle.Top;
            mainPanel.FlowDirection = FlowDirection.LeftToRight;
            mainPanel.Padding = new Padding(15);
            toolboxPanel.Controls.Add(button);
        }

        private void addUcionica(object sender, EventArgs e)
        {
            UcionicaForm f = new UcionicaForm(null);
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                UcionicaControl c = new UcionicaControl((Ucionica)f.GetAction().getGUIObject(), mainPanel);
                c.Width = 200;
                c.Height = 100;
                c.Margin = new Padding(30);
                mainPanel.Controls.Add(c);
                c.DoubleClick += Ucionica_DoubleClick;
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



    public partial class Form1
    {
        List<Smer> smerovi = new List<Smer>();
        TreeView predmetiTree;
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
            predmetiTree.Dock = DockStyle.Top;
            toolboxPanel.Controls.Add(predmetiTree);
            predmetiTree.ItemDrag += PredmetiTree_ItemDrag;


        }

        private void PredmetiTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            System.Diagnostics.Debug.Write("VUCEM");
        }

        private void populatePredmets()
        {
            predmetiTree = new TreeView();

            foreach (Smer smer in smerovi)
            {
                
                SmerControl sc = new SmerControl(smer, mainPanel);
                sc.Width = 180;
                sc.Height = 35;
                sc.Dock = DockStyle.Top;
                toolboxPanel.Controls.Add(sc);
                TreeNodeObject smerNode = new TreeNodeObject(smer.ID, smer);

                foreach (Predmet pred in smer.Predmeti)
                {
                    TreeNodeObject t = new TreeNodeObject(pred.ID, pred);
                    smerNode.Nodes.Add(t);
                }
                predmetiTree.Nodes.Add(smerNode);
            }

        }

    }
}
