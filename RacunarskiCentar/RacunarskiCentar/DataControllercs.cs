using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    class DataControllercs
    {

    }

    public abstract class Action
    {
        protected GUIObject o;
        public Action(GUIObject guiObject)
        {
            o = guiObject;
        }
        public abstract Action GetReverseAction();
        public abstract void excuteAction();
        public GUIObject getGUIObject()
        {
            return o;
        }
    }
    public class DeleteAction : Action
    {
        public DeleteAction(GUIObject guiObject) : base(guiObject) { }
 

        public override void excuteAction()
        {
            o.Delete();
            throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            return new CreateAction(o);
        }
    }

    public class CreateAction : Action
    {
        public CreateAction(GUIObject guiObject) : base(guiObject) { }
        public override void excuteAction()
        {

            throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            return new DeleteAction(o);
        }
    }

    public class EditAction : Action
    {
        GUIObject copyObject;
        public EditAction(GUIObject guiObject) : base(guiObject)
        {
            guiObject.restoreFromCopy(guiObject);
        }
        public override void excuteAction()
        {
            throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            throw new NotImplementedException();
        }
    }
}
