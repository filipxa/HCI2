using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class Smer : GUIObject
    {
        string id;
        string ime;
        DateTime datumUvodjenja;
        string opis;
        List<Predmet> predmeti;


        public Smer(string id, string ime, DateTime datumUvodjenja, string opis)
        {
            ID = id;
            Ime = ime;
            DatumUvodjenja = datumUvodjenja;
            Opis = opis;
            this.predmeti = new List<Predmet>();
        }

        public Smer(string id, string ime, DateTime datumUvodjenja, string opis,List<Predmet> predmeti): this(id, ime, datumUvodjenja, opis)
        {
            if(predmeti != null)
            {
                this.predmeti = new List<Predmet>(predmeti);
            }
        }

        public List<Predmet> Predmeti
        {
            get => predmeti;
            set
            {
                predmeti = new List<Predmet>(value);
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

        public DateTime DatumUvodjenja
        {
            get => datumUvodjenja;
            set
            {
                datumUvodjenja = value;
                OnValueChanged(new EventArgs());
            }
        }

        public override GUIObject Copy()
        {
            return new Smer(id, ime, datumUvodjenja, opis);
        }


        internal override void restoreFromCopy(GUIObject guiObject)
        { 
            Smer s = guiObject as Smer;
            if (s == null)
                throw new Exception("Smer null?");
            ID = s.id;
            DatumUvodjenja = s.DatumUvodjenja;
            Ime = s.Ime;
            Opis = s.Opis;
            Predmeti = s.Predmeti;
            
        }
    }
}
