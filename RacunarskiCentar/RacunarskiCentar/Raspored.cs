using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Raspored : GUIObject
    {
        List<Nedelja> radneNedelje;
        Ucionica ucionica;

        public Ucionica Ucionica
        {
            get => ucionica;
            set => ucionica = value;
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
        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
            List<Nedelja> nedelje = new List<Nedelja>(RadneNedelje);
            foreach (Nedelja nedelja in nedelje)
            {
                nedelja.Delete();
            }

        }
    }
}