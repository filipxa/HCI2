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
        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
            List<Predmet> predmeti = new List<Predmet>(Predmeti);
            foreach (Predmet pred in predmeti)
                pred.Delete();
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
