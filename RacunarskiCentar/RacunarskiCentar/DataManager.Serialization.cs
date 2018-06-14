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

               // ucionice[0].Raspored = new Raspored(ucionice[0]);
                //ucionice[0].Raspored.RadneNedelje.Add(new Nedelja(ucionice[0].Raspored, DateTime.Now));
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
            DataManger.saveUcionica("ucionicaXML.xml");
            DataManger.saveSmer("smerXML.xml");
            DataManger.saveSoftware("softwareXML.xml");
        }

        public static void load()
        {
              
            loadSmerovi("smerXML.xml");
            loadSoftware("softwareXML.xml");
            loadUcionice("ucionicaXML.xml");

        }

        private static void loadSoftware(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Software>));
                    softveri = (List<Software>)serializer.Deserialize(reader);
                    reader.Close();
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
                    reader.Close();
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
                    reader.Close();
                }
            }
            catch (Exception)
            {

               
            }
           

        }



    }
}
