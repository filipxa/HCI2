using System;
using System.Collections.Generic;
namespace RacunarskiCentar
{
    public class Software : GUIObject
    {
        string id;
        string ime;
        string proizvodjac;
        string url;
        string godina; //treba ograditit za godinu
        double cena;
        string opis;
        HashSet<UcionicaAssets> assets;
        public Software(string id, string name, string proizvodjac, string URL, string godina, double cena, string opis) {
            ID = id;
            Ime = ime;
            Proizvodjac = proizvodjac;
            URL = url;
            Godina = godina;
            Cena = cena;
            Opis = opis;
        }
        public string Proizvodjac
        {
            get => proizvodjac;
            set
            {
                proizvodjac = value;
                OnValueChanged(new EventArgs());
            }
        }

        public string URL
        {
            get => url;
            set
            {
                url = value;
                OnValueChanged(new EventArgs());
            }
        }
        public double Cena
        {
            get => cena;
            set
            {
                cena = value;
                OnValueChanged(new EventArgs());
            }
        }
        public string Godina
        {
            get => godina;
            set
            {
                godina = value;
                OnValueChanged(new EventArgs());
            }
        }
        public string ID
        {
            get => id;
            set
            {
                id = value;
                OnValueChanged(new EventArgs());
            }
        }
        public string Ime
        {
            get => ime;
            set
            {
                ime = value;
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
        public override GUIObject Copy()
        {
            throw new NotImplementedException();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}