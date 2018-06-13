using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        Raspored raspored;
        DateTime ponedeljak;

        [XmlIgnoreAttribute]
        public Raspored Raspored
        {
            get => raspored;
            set => raspored = value;
        }
        public Nedelja()
        {

        }

        public Nedelja(Raspored raspored, DateTime ponedeljak)
        {
            Termini = new List<Termin>();
            Raspored = raspored;
            Ponedeljak = ponedeljak;
            
        }
        public Nedelja(Raspored raspoerd, List<Termin> termini,DateTime ponedeljak) : this(raspoerd,ponedeljak)
        {
            if (termini != null)
            {
                this.termini = new List<Termin>(termini);
            }
        }
        public List<Termin> Termini
        {
            get => termini;
            set
            {
                termini = new List<Termin>(value);
            }
        }
        public DateTime Ponedeljak
        {
            get => ponedeljak;
            set
            {
                
                int diff = (7 + (value.DayOfWeek - DayOfWeek.Monday)) % 7;

                ponedeljak = new DateTime(value.Year, value.Month, value.Day - 1 * diff, 7, 0, 0);

            }
        }
        public bool isSlobodan(Termin termin)
        {
            
            return isSlobodan(termin.PocetakTermina, termin.KrajTermina);

        }

        public bool isSlobodan(DateTime pocetakTermina, DateTime krajTermina, Termin ignoreTermin)
        {
            if(pocetakTermina.Hour<7 || krajTermina.Hour > 22 || krajTermina.Date>pocetakTermina.Date)
            {
                return false;
            }
            if (krajTermina.Hour == 22 && (krajTermina.Minute > 0 || krajTermina.Second > 0))
                return false;
            foreach (Termin t in termini)
            {
                if (t.Equals(ignoreTermin))
                    continue;
                if (t.IsTerminIntersec(pocetakTermina, krajTermina))
                {
                    return false;
                }
            }
            return true;
        }
        public bool isSlobodan(DateTime pocetakTermina, DateTime krajTermina)
        {
            return isSlobodan(pocetakTermina,krajTermina,null);
        }


        internal Dictionary<int, List<Termin>> getDanTermine()
        {

            Dictionary<int, List<Termin>> rets = new Dictionary<int, List<Termin>>();
            int dan;
            for(int i = 0; i < 6; i++)
            {
                rets.Add(i, new List<Termin>());
            }
            foreach (Termin t in termini)
            {
                dan = t.PocetakTermina.Day - ponedeljak.Day;
                rets[dan].Add(t);
            }

            return rets;
        }

        public override GUIObject Copy()
        {
            return new Nedelja(raspored, termini,ponedeljak);

        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Nedelja ned = guiObject as Nedelja;
            if (ned == null)
            {
                throw new Exception("Nedelja null");
            }
            Raspored = ned.Raspored;
            Termini = ned.Termini;
            Ponedeljak = ned.Ponedeljak;
        }
    }
}