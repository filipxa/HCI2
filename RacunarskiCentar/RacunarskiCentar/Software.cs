using System;
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
        public Software(string id, string name, string proizvodjac, string URL, string godina, double cena, string opis) {

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
        string Godina
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