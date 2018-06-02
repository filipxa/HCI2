using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class Smer : GUIObject
    {
        string id;
        string ime;
        DateTime datumUvodjenja;
        string opis;


        public string ID
        {
            get => id;
            set
            {
                id = value;
                OnValueChanged(new EventArgs());
            }
        }
        public string Ime
        {
            get => ime;
            set
            {
                ime = value;
                OnValueChanged(new EventArgs());
            }
        }
        public string Opis
        {
            get => opis;
            set
            {
                opis = value;
                OnValueChanged(new EventArgs());
            }
        }

        public DateTime DatumUvodjenja
        {
            get => datumUvodjenja;
            set
            {
                datumUvodjenja = value;
                OnValueChanged(new EventArgs());
            }
        }

        public override GUIObject Copy()
        {
            throw new NotImplementedException();
        }

        internal override void restoreFromCopy(GUIObject guiObject)
        {
            throw new NotImplementedException();
        }
    }
}
