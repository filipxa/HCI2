using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class DataManger
    {
        static List<Ucionica> ucionice;
        static List<Smer> smerovi;

        public static void addObject(GUIObject guiObject)
        {
            if (guiObject is Ucionica)
            {
                addUcionica(guiObject as Ucionica);
                
            }
            if(guiObject is Termin)
            {
                addTermin(guiObject as Termin);
            }
            if (guiObject is Smer)
            {
                addSmer(guiObject as Smer);
            }
        }

        private static void addSmer(Smer smer)
        {
            smerovi.Add(smer);
        }

        private static void addUcionica(Ucionica ucionica)
        {
            ucionice.Add(ucionica);

        }

        public List<Raspored> getRasporedi()
        {
            List<Raspored> rets = new List<Raspored>();
            foreach (Ucionica ucionica in ucionice)
            {
                rets.Add(ucionica.Raspored);

            }
            return rets;
               
        }
        public List<Nedelja> getNedelje()
        {
            List<Nedelja> rets = new List<Nedelja>();
            foreach(Raspored ras in getRasporedi())
            {
                rets.AddRange(ras.RadneNedelje);
            }
            return rets;
        }

        public List<Predmet> getPredmeti()
        {
            List<Predmet> rets = new List<Predmet>();
            foreach (Smer smer in smerovi)
            {
                rets.AddRange(smer.Predmeti);
            }
            return rets;
        }
        public static void addTermin(Termin termin)
        {
            termin.Nedelja.Termini.Add(termin);
            termin.Predmet.Termini.Add(termin);
        }
        public void removeTermin(Termin termin)
        {
            termin.Nedelja.Termini.Remove(termin);
            termin.Predmet.Termini.Remove(termin);
        }

    }

    
}
