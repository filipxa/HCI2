using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    public partial class DataManger
    {
        static HashSet<UcionicaAssets> assetss = null;
        static Ucionica ucionicaFilter = new Ucionica("", "", -1, null, null);
        static Predmet predmetFilter = new Predmet("", "", null, "", -1, -1, -1);
        static Smer smerFilter = new Smer("", "", DateTime.MinValue, "", null);

        public static List<Ucionica> ucionicaFilterisanje()
        {
            //assetss.Add(UcionicaAssets.linux);
            //ucionicaFilter = new Ucionica("", null, 50, assetss,null);
            //ucionicaFilter.ID.ToLower().Contains(ucionicaFilter.ID);
            return ucionice.Where(x => ucionicaFilter.ID == "" || (x.ID.ToLower().Contains(ucionicaFilter.ID.ToLower()))
            && (x.BrRadnihMesta >= ucionicaFilter.BrRadnihMesta)
            && ((x.Assets.Intersect(ucionicaFilter.Assets).Count() == ucionicaFilter.Assets.Count()) || (ucionicaFilter.Assets == null))
            && ((x.InstalledSoftware.Intersect(ucionicaFilter.InstalledSoftware).Count() == ucionicaFilter.InstalledSoftware.Count()) || (ucionicaFilter.InstalledSoftware == null))
            ).ToList();
        }

        public static List<Smer> smerFilterisanje()
        {
            return smerovi.Where(x => (x.ID.ToLower().Contains(smerFilter.ID.ToLower()) || smerFilter.ID == "")
            && ((x.Ime.ToLower().Contains(smerFilter.Ime.ToLower())) || (smerFilter.Ime == ""))
            && ((x.Predmeti.Intersect(smerFilter.Predmeti).Count() == smerFilter.Predmeti.Count()) || smerFilter.Predmeti == null)
            ).ToList();
        }

        public static List<Predmet> predmetFiltriranje(List<Predmet> predmeti)
        {
            return predmeti.Where(x => (x.ID.ToLower().Contains(predmetFilter.ID.ToLower()) || predmetFilter.ID == "")
           && ((x.Ime.ToLower().Contains(predmetFilter.Ime.ToLower())) || (predmetFilter.Ime == ""))
           && (x.BrLjudi >= predmetFilter.BrLjudi)
           && (x.BrCasova >= predmetFilter.BrCasova)
           && (x.BrTermina >= predmetFilter.BrTermina)
           && ((x.Assets.Intersect(predmetFilter.Assets).Count() == predmetFilter.Assets.Count()) || (predmetFilter.Assets == null))
                ).ToList();
        }

        public static Ucionica UcionicFilter {
            set => ucionicaFilter = value;
        }

        public static Predmet PredmetFiler
        {
            set => predmetFilter = value;
        }

        public static Smer SmerFilter{
            set => smerFilter = value;
        }
    }
}
