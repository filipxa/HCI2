using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
   public abstract class GUIObject
    {
        private EventHandler onValueChanged;
        private EventHandler onDelete;
        public event EventHandler ValueChanged
        {
            add
            {
                onValueChanged += value;
            }
            remove
            {
                onValueChanged -= value;
            }
        }
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (onValueChanged != null)
            {
                onValueChanged(this, e);
            }
        }

        public event EventHandler Deleted
        {
            add
            {
                onDelete += value;
            }
            remove
            {
                onDelete -= value;
            }
        }
        protected virtual void OnDelete(EventArgs e)
        {
            if (onDelete != null)
            {
                onDelete(this, e);
            }
        }

        public void Delete()
        {
            //throw new NotImplementedException();
            OnDelete(new EventArgs());
        }

        public abstract GUIObject Copy();
        internal abstract void restoreFromCopy(GUIObject guiObject);
    }
}
