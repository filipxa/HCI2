using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class DataManger
    {
        List<Ucionica> ucionice;
        public void addObject(GUIObject guiObject)
        {
            if (guiObject is Ucionica)
            {
                addUcionica((Ucionica)guiObject);
                
            }
        }

        private void addUcionica(Ucionica ucionica)
        {
            ucionice.Add(ucionica);
           // ucionica
        }
    }
}
