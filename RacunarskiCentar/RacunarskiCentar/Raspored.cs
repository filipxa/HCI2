using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Raspored : GUIObject
    {
        List<Nedelja> radneNedelje;

        public List<Nedelja> RadneNedelje
        {
            get => radneNedelje;
            set => radneNedelje = new List<Nedelja>(value);
        }
        

        public override GUIObject Copy()
        { 
            throw new System.NotImplementedException();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new System.NotImplementedException();
        }
    }
}