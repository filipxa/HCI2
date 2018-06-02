using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        protected override void OnDelete(EventArgs e)
        {
            base.OnDelete(e);
        }
        public override GUIObject Copy()
        {
            throw new System.NotImplementedException();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}