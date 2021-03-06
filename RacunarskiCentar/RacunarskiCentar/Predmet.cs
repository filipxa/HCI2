﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RacunarskiCentar
{
    public class Predmet : GUIObject
    {   
        string id;
        string ime;
        Smer smerPredmeta;
        string opis;
        int brLjudi;
        int brCasova;
        int brTermina;
        HashSet<UcionicaAssets> assets;

        HashSet<Software> installedSoftware;

        public Predmet()
        {
            this.Assets = new HashSet<UcionicaAssets>();
            this.InstalledSoftware = new HashSet<Software>();
        }
        public Predmet(string id, string ime, Smer smerPredmeta, string opis,int brLjudi, int brCasova, int brTermina)
        {  
            ID =id;
            Ime = ime;
            SmerPredmeta = smerPredmeta;
            Opis = opis;
            BrLjudi = brLjudi;
            BrCasova = brCasova;
            BrTermina = brTermina;
            this.Assets = new HashSet<UcionicaAssets>();
            this.InstalledSoftware = new HashSet<Software>();

        }

        public Predmet(string id, string ime, Smer smerPredmeta, string opis,int brLjudi, int brCasova, int brTermina, 
            HashSet<UcionicaAssets> assets, HashSet<Software> installedSoftware) : this(id, ime, smerPredmeta, opis,brLjudi, brCasova,brTermina)
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


        public string ID {
            get => id;
            set {
                id = value;
                OnValueChanged(new EventArgs());
            }
        }

       public string Ime {
            get => ime;
            set {
                ime = value;
                OnValueChanged(new EventArgs());
            }
        
        }
        public int  BrLjudi {
            get => brLjudi;
            set {
                brLjudi = value;
                OnValueChanged(new EventArgs());
            }
        }
        public int  BrTermina {
            get => brTermina;
            set {
                brTermina = value;
                OnValueChanged(new EventArgs());
            }
        }
        public int  BrCasova {
            get => brCasova;
            set {
                brCasova = value;
                OnValueChanged(new EventArgs());
            }
        }
        [XmlIgnore]
        public Smer SmerPredmeta {
            get => smerPredmeta;
            set {
                smerPredmeta = value;
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

        [XmlIgnore]
        public HashSet<Software> InstalledSoftware { get => installedSoftware; set => installedSoftware = new HashSet<Software>(value); }

        [XmlElement("Software")]
        public string SoftwareSerialised
        {
            get
            {
                string rets = "";
               foreach (Software s in installedSoftware)
                {
                    rets += s.ID + "*";
                }
               if(rets.Length>0)
                    rets = rets.Substring(0, rets.Length - 1);
                return rets;
            }
            set {
                foreach(string id in value.Split('*'))
                {
                    Software s = DataManger.GetSoftverID(id);
                    if(s!=null)
                    installedSoftware.Add(s);
                }
            }
        }

        public override GUIObject Copy()
        {
            Predmet p = new Predmet(id, ime, smerPredmeta, opis,brLjudi, brCasova,brTermina, Assets, InstalledSoftware);
            return p;
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Predmet pred = guiObject as Predmet;
            if (pred == null)
            {
                throw new Exception("Predmet null");
            }
            ID = pred.ID;
            Ime = pred.Ime;
            SmerPredmeta = pred.SmerPredmeta;
            Opis = pred.Opis;
            BrLjudi = pred.BrLjudi;
            BrCasova = pred.BrCasova;
            BrTermina = pred.brTermina;
            Assets = pred.Assets;
            InstalledSoftware = pred.InstalledSoftware;
            
            
        }
        public override string ToString()
        {
            return ID;
        }

    }
    
}
