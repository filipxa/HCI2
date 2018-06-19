using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace RacunarskiCentar
{
    public class Raspored : GUIObject
    {
        List<Nedelja> radneNedelje;
       
        Ucionica ucionica;

      

        [XmlIgnoreAttribute]
        public Ucionica Ucionica
        {
            get => ucionica;
            set => ucionica = value;
        }

        public Raspored()
        {

        }
        public Raspored(Ucionica ucionica)
        {
            radneNedelje = new List<Nedelja>();
            Ucionica = ucionica;
        }
        public Raspored(Ucionica ucionica, List<Nedelja> radneNedelje) : this(ucionica)
        {
            if (radneNedelje != null)
                 RadneNedelje = radneNedelje;
        }

        public List<Nedelja> RadneNedelje
        {
            get => radneNedelje;
            set => radneNedelje = new List<Nedelja>(value);
        }
       
        public Nedelja GetNedelja(DateTime date)
        {
            List<Nedelja> rets  = radneNedelje.Where(x => x.IsInNedelja(date)).ToList();
            if (rets.Count > 0)
            {
                return rets[0];
            }
            Nedelja ned = new Nedelja(this, date);
            radneNedelje.Add(ned);
            return ned;

        }



        public override GUIObject Copy()
        {
            return new Raspored(ucionica,radneNedelje);
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Raspored r = guiObject as Raspored;
            if(r == null)
            {
                throw new Exception("Raspored null");
            }
            RadneNedelje = r.radneNedelje;
            Ucionica = r.ucionica;
        }


    }
}