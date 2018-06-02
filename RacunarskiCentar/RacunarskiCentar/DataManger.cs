﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class DataManger
    {
        static List<Ucionica> ucionice = new List<Ucionica>();
        static List<Smer> smerovi = new List<Smer>();
        static List<Software> softveri = new List<Software>();

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
            if( guiObject is Raspored)
            {
                addRaspored(guiObject as Raspored);
            }

            if (guiObject is Nedelja)
            {
                addNedelja(guiObject as Nedelja);
            }
        }

        private static void addRaspored(Raspored raspored)
        {
            raspored.Ucionica.Raspored = raspored;
            foreach (Nedelja ned in raspored.RadneNedelje)
            {
                addNedelja(ned);
            }
        }

        private static void addNedelja(Nedelja ned)
        {
            ned.Raspored.RadneNedelje.Add(ned);
            foreach (Termin ter in ned.Termini)
            {
                addTermin(ter);
            }

        }

        internal static void removeObject(GUIObject guiObject)
        {
            if (guiObject is Ucionica)
            {
                removeUcionica(guiObject as Ucionica);

            }
            if (guiObject is Termin)
            {
                removeTermin(guiObject as Termin);
            }
            if (guiObject is Smer)
            {
                smerovi.Remove(guiObject as Smer);
            }
            if (guiObject is Raspored)
            {
               removeRaspored(guiObject as Raspored);
            }

            if (guiObject is Nedelja)
            {
                removeNedelja(guiObject as Nedelja);
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

        public static void addTermin(Termin termin)
        {
            if(!termin.Nedelja.Termini.Contains(termin))
                termin.Nedelja.Termini.Add(termin);
            if (!termin.Predmet.Termini.Contains(termin))
                termin.Predmet.Termini.Add(termin);
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
        
        static public void removeTermin(Termin termin)
        {
            termin.Nedelja.Termini.Remove(termin);
            termin.Predmet.Termini.Remove(termin);
        }
        private static void removeRaspored(Raspored raspored)
        {
            raspored.Ucionica.Raspored = null;
        }

        static public void removeUcionica(Ucionica ucionica)
        {
            ucionice.Remove(ucionica);
        }

        public static void removeNedelja(Nedelja ned)
        {
            ned.Raspored.RadneNedelje.Remove(ned);
        }

    }

    
}
