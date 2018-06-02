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
        GUIObject o;
        public Action(GUIObject guiObject)
        {
            o = guiObject.Copy();
        }
        public abstract Action GetReverseAction();
        public abstract void excuteAction();
    }
    public class DeleteAction : Action
    {
        public DeleteAction(GUIObject guiObject) : base(guiObject) { }

        public override void excuteAction()
        {
            throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            throw new NotImplementedException();
        }
    }

    public class CreateAction : Action
    {
        public override void excuteAction()
        {
            throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            throw new NotImplementedException();
        }
    }

    public class EditAction : Action
    {
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
