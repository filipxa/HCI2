using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
   public  abstract class CustomControlBase<T> : Control where T : GUIObject
    {
        T guiObject;
        protected Panel parentPanel;
        private bool isTutorial = false;
        public CustomControlBase(T guiObject, Panel panel)
        {
            GuiObject = guiObject;
            parentPanel = panel;
           
        }

        public T GuiObject
        {
            get => guiObject;
            set
            {
               
                if (guiObject != null)
                {
                    if (guiObject.Equals(value))
                        return;
                    guiObject.ValueChanged -= onValueChaged;
                    guiObject.Deleted -= onDelete;
                }
                   
                guiObject = value;
                if (guiObject != null)
                {
                    guiObject.ValueChanged += onValueChaged;
                    guiObject.Deleted += onDelete;
                }
                   
                Invalidate();
                
            }
        }

        public bool IsTutorial {
            get => isTutorial;

            set {
                if (isTutorial != value)
                {
                    isTutorial = value;
                    onValueChaged(null, null);
                }
               
            }
        }

        protected virtual void onValueChaged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected virtual void onDelete(object sender, EventArgs e)
        {
            Dispose(true);
            parentPanel.Controls.Remove(this);
        }
    }

}
