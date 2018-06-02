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

        public Ucionica(String id, string opis, int brMesta)
        {
            BrRadnihMesta = brMesta;
            ID = id;
            Opis = opis;
            this.assets = new HashSet<UcionicaAssets>();
            this.installedSoftware = new HashSet<String>();

        }
        public Ucionica(String id, string opis, int brMesta, HashSet<UcionicaAssets> assets, HashSet<String> installedSoftware) : this(id, opis, brMesta)
        {

            if (assets != null)
            {
                this.assets = new HashSet<UcionicaAssets>(assets);
            }
            if (installedSoftware != null)
            {
                this.installedSoftware = new HashSet<String>(installedSoftware);

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
