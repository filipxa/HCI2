using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RacunarskiCentar
{
    public class Termin : GUIObject
    {
        DateTime pocetakTermina;
        DateTime krajTermina;
        Predmet predmet;
        Nedelja nedelja;
        int duzinaTermina; // Broj casova termina

        public Termin()
        {

        }
        public Termin(DateTime pocetakTermina, int duzinaTermina,Predmet predmet, Nedelja nedelja)
        {
            PocetakTermina = pocetakTermina;
            this.duzinaTermina = duzinaTermina;
            Predmet = predmet;
            Nedelja = nedelja;
            KrajTermina = PocetakTermina.AddMinutes(45 * duzinaTermina);
        }

        public Termin(DateTime pocetakTermina, DateTime krajTermina, Predmet predmet, Nedelja nedelja)
        {
            PocetakTermina = pocetakTermina;
            Predmet = predmet;
            Nedelja = nedelja;
            KrajTermina = krajTermina;
            duzinaTermina = (int)(krajTermina - pocetakTermina).TotalMinutes / 45;
        }
        //Proverava da li je bilo koji datum iz liste 
        private bool DateBetween(DateTime date1, DateTime date2, params DateTime[] datesToCheck)
        {
            foreach(DateTime date in datesToCheck)
            {
                if (date1 <= date && date2 >= date)
                {
                    return true;
                }
            }
            return false;
           
        }

        public bool IsTerminIntersec(Termin t)
        {
            return DateBetween(t.pocetakTermina, t.krajTermina, pocetakTermina, krajTermina) || DateBetween(pocetakTermina, krajTermina, t.pocetakTermina, t.krajTermina);

        }

        public bool IsTerminIntersec(DateTime pocetak, DateTime kraj)
        {
            return DateBetween(pocetak, kraj, pocetakTermina, krajTermina) || DateBetween(pocetakTermina, krajTermina, pocetak, kraj);

        }
        [XmlIgnoreAttribute]
        public Nedelja Nedelja
        {
            get => nedelja;
            set => nedelja = value;
        }
        [XmlIgnoreAttribute]
        public Predmet Predmet
        {
            get => predmet;
            set => predmet = value;
        }
        [XmlElement("Predmet")]
        public string PredmetSerialised
        {
            get { return Predmet.ID; }
            set { predmet = DataManger.getPredmetByID(value); }
        }
        public DateTime PocetakTermina
        {
            get => pocetakTermina;
            set => pocetakTermina = value;
        }
        public DateTime KrajTermina
        {
            get => krajTermina;
            set => krajTermina = value;
        }
        public override GUIObject Copy()
        {
            return new Termin(pocetakTermina, duzinaTermina, predmet, nedelja);
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Termin t = guiObject as Termin;
            if(t == null)
            {
                throw new Exception("Termin null");
            }
            pocetakTermina = t.pocetakTermina;
            duzinaTermina = t.duzinaTermina;
            Predmet = predmet;
            Nedelja = nedelja;
            krajTermina = t.krajTermina;
        }


    }
}