﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class Predmet : GUIObject
    {   Sof
        string id;
        string ime;
        string smerPredmeta;
        string opis;
        int brLjudi;
        int brCasova;
        int brTermina;
        HashSet<UcionicaAssets> assets;
        HashSet<Software> installedSoftware;

        public Predmet(string id, string ime, string smerPredmeta, string opis,int brLjudi, int brCasova, int brTermina)
        {  
            ID =id;
            Ime = ime;
            SmerPredmeta = smerPredmeta;
            Opis = opis;
            BrLjudi = brLjudi;
            BrCasova = brCasova;
            BrTermina = brTermina;
            this.Assets = new HashSet<UcionicaAssets>();
            this.InstalledSoftware = new HashSet<String>();

        }

        public Predemet(string id, string ime, string smerPredmeta, string opis,int brLjudi, int brCasova, int brTermina, HashSet<UcionicaAssets> assets, HashSet<String> installedSoftware) : this(id, ime, smerPredmeta, opis,brLjudi, brCasova,brTermina)
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
        public string SmerPredmeta {
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

        public override GUIObject Copy()
        {
            Predmet p = new Ucionica(id, ime, smerPredmeta, opis,brLjudi, brCasova,brTermina, Assets, InstalledSoftware);
            return p;
        }

    }
}
