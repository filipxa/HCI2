﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RacunarskiCentar
{
    public partial class DataManger
    {

        public static void saveUcionica(string fileName)
        {

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(List<Ucionica>));
                xml.Serialize(stream, ucionice);
            }
        }


        public static void saveSmer(string fileName)
        {

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(List<Smer>));
                xml.Serialize(stream, smerovi);
            }
        }

        public static void saveSoftware(string fileName)
        {

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(List<Software>));
                xml.Serialize(stream, softveri);
            }
        }

        public static void save()
        {
            saveUcionica("ucionicaXML.xml");
            saveSmer("smerXML.xml");
            saveSoftware("softwareXML.xml");
        }

        public static void load()
        {
            smerovi.Clear();
            softveri.Clear();
            ucionice.Clear();
            loadSoftware("softwareXML.xml");
            loadSmerovi("smerXML.xml");
            loadUcionice("ucionicaXML.xml");
            
            foreach(Ucionica u in ucionice)
            {
                if (u.Raspored == null)
                    continue;
                u.Raspored.Ucionica = u;
                foreach(Nedelja ned in u.Raspored.RadneNedelje)
                {
                    ned.Raspored = u.Raspored;

                    foreach(Termin t in ned.Termini)
                    {
                        t.Nedelja = ned;
                    }
                }
            }
            foreach(Smer smer in smerovi)
            {
                foreach(Predmet p in smer.Predmeti)
                {
                    p.SmerPredmeta = smer;
                }
            }

        }

        public static void loadTut()
        {
            ucionice.Clear();
            smerovi.Clear();
            softveri.Clear();
            loadSoftware("softwareXMLTut.xml");
            loadSmerovi("smerXMLTut.xml");
            loadUcionice("ucionicaXMLTut.xml");
            
            foreach (Ucionica u in ucionice)
            {
                if (u.Raspored == null)
                    continue;
                u.Raspored.Ucionica = u;
                foreach (Nedelja ned in u.Raspored.RadneNedelje)
                {
                    ned.Raspored = u.Raspored;

                    foreach (Termin t in ned.Termini)
                    {
                        t.Nedelja = ned;
                    }
                }
            }
            foreach (Smer smer in smerovi)
            {
                foreach (Predmet p in smer.Predmeti)
                {
                    p.SmerPredmeta = smer;
                }
            }

        }

        private static void loadSoftware(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Software>));
                    softveri = (List<Software>)serializer.Deserialize(reader);
                   
                }
            }
            catch (Exception)
            {

            }
           

        }

        private static void loadUcionice(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Ucionica>));
                    ucionice = (List<Ucionica>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {

                
            }

          

        }

        private static void loadSmerovi(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Smer>));
                    smerovi = (List<Smer>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {

            }
           

        }



    }
}
