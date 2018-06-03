using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        Raspored raspored;
       public Raspored Raspored
        {
            get => raspored;
            set => raspored = value;
        }

        public Nedelja(Raspored raspored)
        {
            Termini = new List<Termin>();
            Raspored = raspored;
            
        }
        public Nedelja(Raspored raspoerd, List<Termin> termini) : this(raspoerd)
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
        public override GUIObject Copy()
        {
            return new Nedelja(raspored, termini);

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
        }
    }
}