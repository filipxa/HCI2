using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class DataManger
    {
        List<Ucionica> ucionice;
        List<Smer> smerovi;

        public void addObject(GUIObject guiObject)
        {
            if (guiObject is Ucionica)
            {
                addUcionica(guiObject as Ucionica);
                
            }
            if(guiObject is Termin)
            {
                addTermin(guiObject as Termin);
            }
        }

        private void addUcionica(Ucionica ucionica)
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
        public void addTermin(Termin termin, Nedelja nedelja)
        {
            nedelja.Termini.Add(termin);
            foreach(Predmet predmet in getPredmeti())
            {
                if(termin.Predmet == predmet)
                {
                    predmet.Termini.Add(termin);
                }
            }
        }
    }

    
}
