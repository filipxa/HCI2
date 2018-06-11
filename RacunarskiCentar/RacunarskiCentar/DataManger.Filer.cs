using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    public partial class DataManger
    {
        static HashSet<UcionicaAssets> assetss = new HashSet<UcionicaAssets>();
        static Ucionica ucionicaFilter;// = new Ucionica(null, null, -1, null, null);
        //static Predmet predmetFilter = new Predmet(null, null, null, null, -1, -1, -1);
        static Smer smerFilter = new Smer(null, null, DateTime.MinValue, null, null);

        public static List<Ucionica> ucionicaFilterisanje()
        {
            assetss.Add(UcionicaAssets.linux);
            ucionicaFilter = new Ucionica("mi-a2-2", null, 50, assetss,null);
            //ucionicaFilter.ID.ToLower().Contains(ucionicaFilter.ID);
            return ucionice.Where(x => (x.ID.ToLower().Contains(ucionicaFilter.ID) || ucionicaFilter.ID == null)
            && (x.BrRadnihMesta >= ucionicaFilter.BrRadnihMesta)
            && ((x.Assets.Intersect(ucionicaFilter.Assets).Count() == ucionicaFilter.Assets.Count()) || (ucionicaFilter.Assets == null))
            && ((x.InstalledSoftware.Intersect(ucionicaFilter.InstalledSoftware).Count() == ucionicaFilter.InstalledSoftware.Count()) || (ucionicaFilter.InstalledSoftware == null))
            ).ToList();
        }

        /*public static List<Smer> smerFilterisanje()
        {
            assetss.Add(UcionicaAssets.linux);
            ucionicaFilter = new Ucionica("mi-a2-2", null, 50, assetss, null);
            //ucionicaFilter.ID.ToLower().Contains(ucionicaFilter.ID);
            return smerovi.Where(x => (x.ID.ToLower().Contains(ucionicaFilter.ID) || ucionicaFilter.ID == null)
            && (x.BrRadnihMesta >= ucionicaFilter.BrRadnihMesta)
            && ((x.Assets.Intersect(ucionicaFilter.Assets).Count() == ucionicaFilter.Assets.Count()) || (ucionicaFilter.Assets == null))
            && ((x.InstalledSoftware.Intersect(ucionicaFilter.InstalledSoftware).Count() == ucionicaFilter.InstalledSoftware.Count()) || (ucionicaFilter.InstalledSoftware == null))
            ).ToList();
        }*/
    }
}
