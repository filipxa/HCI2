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
        public CustomControlBase(T guiObject)
        {
            this.GuiObject = guiObject;
            guiObject.ValueChanged += onValueChaged;
            guiObject.Deleted += onDelete;
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

        private void onValueChaged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void onDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
