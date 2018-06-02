using System;

namespace RacunarskiCentar
{
    public class Termin : GUIObject
    {
        DateTime pocetakTermina;
        DateTime krajTermina;
        Predmet predmet;
        Nedelja nedelja;
        int duzinaTermina; // Broj casova termina
        
        public Nedelja Nedelja
        {
            get => nedelja;
            set => nedelja = value;

        }

        public Termin(DateTime pocetakTermina, int duzinaTermina,Predmet predmet)
        {
            this.pocetakTermina = pocetakTermina;
            this.duzinaTermina = duzinaTermina;
            this.predmet = predmet;
            krajTermina = pocetakTermina.AddMinutes(45 * duzinaTermina);
        }
        public Predmet Predmet
        {
            get => predmet;
            set => predmet = value;
        }
        public override GUIObject Copy()
        {
            return new Termin(pocetakTermina, duzinaTermina, predmet);
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}