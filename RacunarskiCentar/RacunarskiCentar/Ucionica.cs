﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    public class Ucionica : GUIObject
    {

        string id;
        string opis;
        int brMesta;
        HashSet<UcionicaAssets> assets;
        HashSet<Software> installedSoftware;
        Raspored raspored;

        public Ucionica(String id, string opis, int brMesta)
        {
            BrRadnihMesta = brMesta;
            ID = id;
            Opis = opis;
            this.Assets = new HashSet<UcionicaAssets>();
            this.InstalledSoftware = new HashSet<Software>();

        }
        public Ucionica(String id, string opis, int brMesta, HashSet<UcionicaAssets> assets, HashSet<Software> installedSoftware) : this(id, opis, brMesta)
        {

            if (assets != null)
            {
                this.Assets = new HashSet<UcionicaAssets>(assets);
            }
            if (installedSoftware != null)
            {
                this.InstalledSoftware = new HashSet<Software>(installedSoftware);

            }
        }

        public int BrRadnihMesta
        {
            get => brMesta;
            set
            {
                brMesta = value;
                OnValueChanged(new EventArgs());
            }
        }

        public string ID {
            get => id;
            set {
                id = value;
                OnValueChanged(new EventArgs());
            }
        }

        public string Opis
        {
            get => opis;
            set
            {
                opis = value;
                OnValueChanged(new EventArgs());
            }
        }
        public Raspored Raspored
        {
            get => raspored;
                set
            {
                raspored = value;
            }
        }

        public HashSet<UcionicaAssets> Assets { get => assets; set => assets = new HashSet<UcionicaAssets>(value); }
        public HashSet<Software> InstalledSoftware { get => installedSoftware; set => installedSoftware = new HashSet<Software>(value); }

        public override GUIObject Copy()
        {
            Ucionica c = new Ucionica(id, opis, brMesta, Assets, InstalledSoftware);
            if (raspored != null)
            c.raspored = (Raspored)raspored.Copy();
            return c;
        }

        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
        }


        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Ucionica ucionica = guiObject as Ucionica;
            if (ucionica == null)
            {
                throw new Exception("Ucionica null");
            }
            BrRadnihMesta = ucionica.brMesta;
            Assets = ucionica.assets;
            installedSoftware = ucionica.installedSoftware;
            ID = ucionica.id;
            raspored.restoreFromCopy(ucionica.raspored);
        }
    }

    public enum UcionicaAssets {Tabla,  Pametna_tabla, Projektor, Winows, Linux};

    static class UcionicaAssetsMethods
    {
       
        public static String getDisplayName(this UcionicaAssets asset)
        {
            string rets = Enum.GetName(typeof(UcionicaAssets), asset);
            rets = rets.Replace("_", " ");
            return rets;
        }
        
    }

}
