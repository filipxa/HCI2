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
        public Termin(DateTime pocetakTermina, int duzinaTermina,Predmet predmet, Nedelja nedelja)
        {
            this.pocetakTermina = pocetakTermina;
            this.duzinaTermina = duzinaTermina;
            Predmet = predmet;
            Nedelja = nedelja;
            krajTermina = pocetakTermina.AddMinutes(45 * duzinaTermina);
        }
        public Nedelja Nedelja
        {
            get => nedelja;
            set => nedelja = value;
        }
        public Predmet Predmet
        {
            get => predmet;
            set => predmet = value;
        }
        public override GUIObject Copy()
        {
            return new Termin(pocetakTermina, duzinaTermina, predmet, nedelja);
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            Termin t = guiObject as Termin;
            if(t == null)
            {
                throw new Exception("Termin null");
            }
            pocetakTermina = t.pocetakTermina;
            duzinaTermina = t.duzinaTermina;
            Predmet = predmet;
            Nedelja = nedelja;
            krajTermina = t.krajTermina;
        }
    }
}