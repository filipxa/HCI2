using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        Raspored raspored;
        Raspored Raspored
        {
            get => raspored;
            set => raspored = value;
        }

        public Nedelja(Raspored raspored)
        {
            Termini = new List<Termin>();
            
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
        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
        }
        public override GUIObject Copy()
        {
            return new Nedelja(raspored, termini);

        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}