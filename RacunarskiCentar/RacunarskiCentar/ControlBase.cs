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
        Panel parentPanel;
        public CustomControlBase(T guiObject, Panel panel)
        {
            this.GuiObject = guiObject;
            guiObject.ValueChanged += onValueChaged;
            guiObject.Deleted += onDelete;
            parentPanel = panel;
            panel.Controls.Add(this);
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
                guiObject.ValueChanged += onValueChaged;
                guiObject.Deleted += onDelete;
                Invalidate();
                
            }
        }

        protected void onValueChaged(object sender, EventArgs e)
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
