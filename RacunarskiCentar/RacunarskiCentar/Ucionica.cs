using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
   public  class Ucionica  : GUIObject
    {
        
        string id;
        string opis;
        int brMesta;
        HashSet<UcionicaAssets> assets;
        HashSet<String> installedSoftware;
        Raspored raspored;

        public Ucionica(String id, string opis, int brMesta)
        {
            BrRadnihMesta = brMesta;
            ID = id;
            Opis = opis;
            this.Assets = new HashSet<UcionicaAssets>();
            this.InstalledSoftware = new HashSet<String>();

        }
        public Ucionica(String id, string opis, int brMesta, HashSet<UcionicaAssets> assets, HashSet<String> installedSoftware) : this(id, opis, brMesta)
        {

            if (assets != null)
            {
                this.Assets = new HashSet<UcionicaAssets>(assets);
            }
            if (installedSoftware != null)
            {
                this.InstalledSoftware = new HashSet<String>(installedSoftware);

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

        public HashSet<UcionicaAssets> Assets { get => assets; set => assets = new HashSet<UcionicaAssets>(value); }
        public HashSet<string> InstalledSoftware { get => installedSoftware; set => installedSoftware = new HashSet<String>(value); }

        public override GUIObject Copy()
        {
            Ucionica c = new Ucionica(id, opis, brMesta, Assets, InstalledSoftware);
            c.raspored = (Raspored)raspored.Copy();
            return c;
        }

        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
            raspored.Delete();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Ucionica ucionica = guiObject as Ucionica;
            BrRadnihMesta = ucionica.brMesta;
            Assets = ucionica.assets;
            
            ID = ucionica.id;
            
        }
    }

   public enum UcionicaAssets {Tabla,  Pametna_tabla, Winows, Linux};
    static class UcionicaAssetsMethods
    {
       
        public static String getDisplayName(this UcionicaAssets asset)
        {
            string rets = Enum.GetName(typeof(UcionicaAssets), asset);
            rets.Replace("_", " ");
            return rets;

        }
    }

}
