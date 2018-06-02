using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Raspored : GUIObject
    {
        List<Nedelja> radneNedelje;

        public Raspored(List<Nedelja> radneNedelje)
        {
            RadneNedelje = radneNedelje;
        }

        public List<Nedelja> RadneNedelje
        {
            get => radneNedelje;
            set => radneNedelje = new List<Nedelja>(value);
        }
        

        public override GUIObject Copy()
        {
            Raspored r = new Raspored(radneNedelje);
            //(Nedelja)radneNedelje.Copy();
            return r;
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new System.NotImplementedException();
        }
    }
}