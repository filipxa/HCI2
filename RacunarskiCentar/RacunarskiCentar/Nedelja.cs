using System;
using System.Collections.Generic;

namespace RacunarskiCentar
{
    public class Nedelja : GUIObject
    {
        List<Termin> termini;
        Raspored raspored;
        DateTime ponedeljak;
       public Raspored Raspored
        {
            get => raspored;
            set => raspored = value;
        }

        public Nedelja(Raspored raspored, DateTime ponedeljak)
        {
            Termini = new List<Termin>();
            Raspored = raspored;
            
        }
        public Nedelja(Raspored raspoerd, List<Termin> termini,DateTime ponedeljak) : this(raspoerd,ponedeljak)
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
        public DateTime Ponedeljak
        {
            get => ponedeljak;
            set
            {
                ponedeljak = value;
            }
        }
        public bool isSlobodan(DateTime vremePocetka, int brCasova)
        {
            DateTime vremeKraja = vremePocetka.AddMinutes(45 * brCasova);

            foreach (Termin t in termini)
            {   //prvo je pocetak/kraj vremena koje je uneseno drugo je p/k vreman termina
                int pocetakPPocetakT = DateTime.Compare(vremePocetka, t.PocetakTermina);//v,p if(v<0) v pre t,provera, termin
                int pocetakPKrajT = DateTime.Compare(vremePocetka, t.KrajTermina);//

                int krajPPocetakT = DateTime.Compare(vremeKraja, t.PocetakTermina);//
                int krajPKrajT = DateTime.Compare(vremeKraja, t.PocetakTermina);//

                //provera da li se pocetak ili kraj nalazi u toku termina
                if (pocetakPPocetakT >= 0 && pocetakPKrajT<=0)
                {
                    return false;
                }
                if (krajPPocetakT >= 0 && krajPKrajT <= 0)
                {
                    return false;
                }
                //proverava da li neki od termina se nalazi unutar zadatog vremena
                if (pocetakPPocetakT <= 0 && krajPKrajT >= 0)
                {
                    return false;
                }
                
    
            }
            return true;
        }
        public override GUIObject Copy()
        {
            return new Nedelja(raspored, termini,ponedeljak);

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
            Ponedeljak = ned.Ponedeljak;
        }
    }
}