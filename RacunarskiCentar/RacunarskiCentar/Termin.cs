using System;

namespace RacunarskiCentar
{
    public class Termin : GUIObject
    {
        DateTime pocetakTermina;
        DateTime krajTermina;
        int duzinaTermina; // Broj casova termina
        public Termin(DateTime pocetakTermina, int duzinaTermina)
        {
            this.pocetakTermina = pocetakTermina;
            this.duzinaTermina = duzinaTermina;
            krajTermina = pocetakTermina.AddMinutes(45 * duzinaTermina);
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