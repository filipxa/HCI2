using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
   public abstract class GUIObject
    {
        protected EventHandler onValueChanged;
        protected EventHandler onDeleteEvent;
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
        public virtual void OnValueChanged(EventArgs e)
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
                onDeleteEvent += value;
            }
            remove
            {
                onDeleteEvent -= value;
            }
        }
        public virtual void OnDelete(EventArgs e)
        {
            if (onDeleteEvent != null)
            {
                onDeleteEvent(this, e); 
            }
        }

        

        public virtual void Delete()
        {
            DataManger.removeObject(this);
            OnDelete(new EventArgs());
        }

        public abstract GUIObject Copy();
        internal abstract void restoreFromCopy(GUIObject guiObject);
    }

}
