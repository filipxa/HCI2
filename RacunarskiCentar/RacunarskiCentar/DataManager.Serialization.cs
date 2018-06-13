using System;
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

        public static void saveUcionice(string fileName)
        {

            using (var stream = new FileStream(fileName, FileMode.Create))
            {

                ucionice[0].Raspored = new Raspored(ucionice[0]);
                //ucionice[0].Raspored.RadneNedelje.Add(new Nedelja(ucionice[0].Raspored, DateTime.Now));
                var xml = new XmlSerializer(typeof(List<Ucionica>));
                xml.Serialize(stream, ucionice);
            }
        }
    }
}
