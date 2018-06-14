using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    public partial class DataManger
    {
        //static HashSet<UcionicaAssets> assetss = null;
        static Ucionica ucionicaFilter = new Ucionica("", "", -1, null, null);
        static Predmet predmetFilter = new Predmet("", "", null, "", -1, -1, -1);
        static Software softverFilter = new Software("","","","","",-1,"");
        static Smer smerFilter = new Smer("", "", DateTime.MinValue, "", null);

        public static List<Ucionica> ucionicaFilterisanje()
        {
            //ID, BrRadnihMesta, Assets, InstalledSoftware
            return ucionice.Where(x => ucionicaFilter.ID == "" || (x.ID.ToLower().Contains(ucionicaFilter.ID.ToLower()))
            && (x.BrRadnihMesta >= ucionicaFilter.BrRadnihMesta)
            && ((x.Assets.Intersect(ucionicaFilter.Assets).Count() == ucionicaFilter.Assets.Count()) || (ucionicaFilter.Assets == null))
            && ((x.InstalledSoftware.Intersect(ucionicaFilter.InstalledSoftware).Count() == ucionicaFilter.InstalledSoftware.Count()) || (ucionicaFilter.InstalledSoftware == null))
            ).ToList();
        }

        public static List<Smer> smerFilterisanje()
        {
            //ID, Ime, Predmeti
            return smerovi.Where(x => (x.ID.ToLower().Contains(smerFilter.ID.ToLower()) || smerFilter.ID == "")
            && ((x.Ime.ToLower().Contains(smerFilter.Ime.ToLower())) || (smerFilter.Ime == ""))
            && ((x.Predmeti.Intersect(smerFilter.Predmeti).Count() == smerFilter.Predmeti.Count()) || smerFilter.Predmeti == null)
            ).ToList();
        }
        
        public static List<Predmet> predmetFiltriranje(List<Predmet> predmeti)
        {
            //ID, ime, BrLjudi, BrCasova, BrTermina, Assets
            return predmeti.Where(x => (x.ID.ToLower().Contains(predmetFilter.ID.ToLower()) || predmetFilter.ID == "")
            && ((x.Ime.ToLower().Contains(predmetFilter.Ime.ToLower())) || (predmetFilter.Ime == ""))
            && (x.BrLjudi >= predmetFilter.BrLjudi)
            && (x.BrCasova >= predmetFilter.BrCasova)
            && (x.BrTermina >= predmetFilter.BrTermina)
            && ((x.Assets.Intersect(predmetFilter.Assets).Count() == predmetFilter.Assets.Count()) || (predmetFilter.Assets == null))
                ).ToList();
        }

        public static List<Software> softverFiltriranje()
        {
            //ID, Ime, Proizvodjac, Cena
            return softveri.Where(x => (x.ID == null || x.ID.ToLower().Contains(softverFilter.ID.ToLower()) || softverFilter.ID == "")
            && (x.Ime == null || (x.Ime.ToLower().Contains(softverFilter.Ime.ToLower())) || (softverFilter.Ime == ""))
            && (x.Proizvodjac == null || (x.Proizvodjac.ToLower().Contains(softverFilter.Proizvodjac.ToLower())) || (softverFilter.Proizvodjac == ""))
            && (x.Cena == null || x.Cena >= softverFilter.Cena)
            ).ToList();
        }

        public static List<Software> softverOperativanSistemFiltiriranje(List<UcionicaAssets> opSistem)
        {
            return softveri.Where(x=> (x.Assets.Intersect(opSistem).Count() > 0 )).ToList();
        }

        public static Ucionica UcionicaFilter {
            set => ucionicaFilter = value;
            get => ucionicaFilter;
        }

        public static Predmet PredmetFiler
        {
            set => predmetFilter = value;
            get => predmetFilter;
        }

        public static Smer SmerFilter{
            set => smerFilter = value;
            get => smerFilter;
        }

        public static Software SoftverFilter
        {
            set => softverFilter = value;
            get => softverFilter;
        }


    }
}
