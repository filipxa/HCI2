﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


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

        public Ucionica()
        {
            raspored = new Raspored(this);
            Assets = new HashSet<UcionicaAssets>();
            InstalledSoftware = new HashSet<Software>();
        }
        public Ucionica(string id, string opis, int brMesta) : this()
        {
            BrRadnihMesta = brMesta;
            ID = id;
            Opis = opis;
           

        }

        public Ucionica(String id, string opis, int brMesta, HashSet<UcionicaAssets> assets, HashSet<Software> installedSoftware) : this(id, opis, brMesta)
        {
            if (assets != null)
            {
                Assets = new HashSet<UcionicaAssets>(assets);
            }
            if (installedSoftware != null)
            {
                InstalledSoftware = new HashSet<Software>(installedSoftware);

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

        public HashSet<UcionicaAssets> Assets {
            get => assets;
            set {
                assets = new HashSet<UcionicaAssets>(value);
                OnValueChanged(new EventArgs());
            }
        }

        public void addAsset(UcionicaAssets asset)
        {
            assets.Add(asset);
            OnValueChanged(new EventArgs());
        }
        public HashSet<Software> InstalledSoftware
        {
            get => installedSoftware;
            set
            {
                installedSoftware = new HashSet<Software>(value);
                OnValueChanged(new EventArgs());
            }
        }

        public override GUIObject Copy()
        {
            Ucionica c = new Ucionica(id, opis, brMesta, Assets, InstalledSoftware);
            if (raspored != null)
            c.raspored = (Raspored)raspored.Copy();
            return c;
        }

        public override void OnDelete(EventArgs e)
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
            if(ucionica.raspored!=null)
             raspored.restoreFromCopy(ucionica.raspored);
        }
    }

    public enum UcionicaAssets {tabla = 1,  pametna_tabla, projektor, windows, linux};

    static class UcionicaAssetsMethods
    { 
        public static String getDisplayName(this UcionicaAssets asset)
        {
            string rets = Enum.GetName(typeof(UcionicaAssets), asset);
            rets = rets.Replace("_", " ");
            return rets;
        }

        public static String getDisplayNames(HashSet<UcionicaAssets> assets)
        {
            string asetsiSvi = "";
            string rets = "";
            foreach (var item in assets)
            {
                rets = Enum.GetName(typeof(UcionicaAssets), item);
                rets = rets.Replace("_", " ");
                asetsiSvi += rets;
                asetsiSvi += ", ";
            }
            if (asetsiSvi.Length > 0)
            {
                asetsiSvi.Substring(asetsiSvi.Length - 2);
            }
           
            return asetsiSvi;
        }

    }

}
