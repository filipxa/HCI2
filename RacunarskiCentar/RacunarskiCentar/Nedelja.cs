using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        public Nedelja()
        {
            termini = new List<Termin>();
            Termini = termini;
        }
        public Nedelja(List<Termin> termini)
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
            Nedelja t = new Nedelja(termini);

            throw new System.NotImplementedException();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}