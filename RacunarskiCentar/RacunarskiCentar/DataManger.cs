using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RacunarskiCentar
{
    public partial class DataManger
    {
        static List<Ucionica> ucionice = new List<Ucionica>();
        static List<Smer> smerovi = new List<Smer>();
        static List<Software> softveri = new List<Software>();

        


        internal static List<Smer> getSmers()
        {
            return smerFilterisanje();
        }
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
            if(guiObject is Software)
            {
                addSoftware(guiObject as Software);
            }
            if( guiObject is Raspored)
            {
                addRaspored(guiObject as Raspored);
            }
            if(guiObject is Predmet)
            {
                addPredmet(guiObject as Predmet);
            }

            if (guiObject is Nedelja)
            {
                addNedelja(guiObject as Nedelja);
            }
        }

        private static void addPredmet(Predmet predmet)
        {
            predmet.SmerPredmeta.Predmeti.Add(predmet);
        }

        private static void addSoftware(Software software)
        {
            softveri.Add(software);
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

        internal static List<Ucionica> getUcionice()
        {
            return ucionicaFilterisanje();
        }
        internal static List<Software> getSoftware()
        {
            return softverFiltriranje();
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
        }



       static public List<Raspored> getRasporedi()
        {
            List<Raspored> rets = new List<Raspored>();
            foreach (Ucionica ucionica in ucionice)
            {
                rets.Add(ucionica.Raspored);

            }
            return rets;
               
        }

      

        static public List<Nedelja> getNedelje()
        {
            List<Nedelja> rets = new List<Nedelja>();
            foreach(Raspored ras in getRasporedi())
            {
                rets.AddRange(ras.RadneNedelje);
            }
            return rets;
        }

        static public List<Predmet> getPredmetiFilterr()
        {
            List<Predmet> rets = new List<Predmet>();
            foreach (Smer smer in smerovi) // da filtriranje radi za isfiltirirane smerove 
            {
                rets.AddRange(predmetFiltriranje(smer.Predmeti));// i predmete
            }
            return rets;
        }

        static public List<Predmet> getPredmeti()
        {
            List<Predmet> rets = new List<Predmet>();
            foreach (Smer smer in smerovi) // da filtriranje radi za isfiltirirane smerove 
            {
                rets.AddRange(smer.Predmeti);// i predmete
            }
            return rets;
        }

        internal static Predmet getPredmetByID(string id)
        {
            foreach (Predmet p in getPredmeti())
            {
                if (p.ID.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        static public List<Termin> getTerminsBySmer(Smer s)
        {
            List<Termin> rets = new List<Termin>();
            foreach (Predmet pred in s.Predmeti)
            {
                rets.AddRange(getTerminsByPredmet(pred));
            }
            return rets;
        }

        static public List<Termin> getTerminsByPredmet(Predmet p)
        {
            List<Termin> rets = new List<Termin>();
            foreach(Nedelja ned in getNedelje())
            {
                 foreach (Termin ter in ned.Termini)
                {
                    if(ter.Predmet == p)
                    {
                        rets.Add(ter);
                    }
                }
            }
            return rets;
        }
        static public Ucionica GetUcionicaID(string id)
        {
            foreach (Ucionica u in ucionice)
            {
                if (u.ID.ToLower().Trim().Equals(id.ToLower().Trim()))
                    return u;
            }
            return null;
        }

        static public Software GetSoftverID(string id)
        {
            foreach (Software u in softveri)
            {
                if (u.ID.ToLower().Trim().Equals(id.ToLower().Trim()))
                    return u;
            }
            return null;
        }

        static public Smer GetSmerID(string id)
        {
            foreach (Smer u in smerovi)
            {
                if (u.ID.ToLower().Trim().Equals(id.ToLower().Trim()))
                    return u;
            }
            return null;
        }
        static public void removeTermin(Termin termin)
        {
            termin.Nedelja.Termini.Remove(termin);
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
