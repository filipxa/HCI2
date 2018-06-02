using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunarskiCentar
{
    static class DataControllercs
    {
        static Stack<Action> actionsHistory = new Stack<Action>();
        static public void addAction(Action action)
        {
            action.excuteAction();
            actionsHistory.Push(action);
        }
        static public  Action undoAction()
        {
            Action rets=null;
            if (actionsHistory.Count > 0)
            {
                rets = actionsHistory.Pop().GetReverseAction();
                rets.excuteAction();
            }
            return rets;
             
        }
    }



    public abstract class Action 
    {
        protected GUIObject o;
        public Action(GUIObject guiObject)
        {
            o = guiObject;
        }
        public abstract Action GetReverseAction();
        internal abstract void excuteAction();
        public GUIObject getGUIObject()
        {
            return o;
        }
    }
    public class DeleteAction : Action
    {
        public DeleteAction(GUIObject guiObject) : base(guiObject) { }


        internal override void excuteAction()
        {
            o.Delete();
           // throw new NotImplementedException();
        }

        public override Action GetReverseAction()
        {
            return new CreateAction(o);
        }
    }

    public class CreateAction : Action
    {
        public CreateAction(GUIObject guiObject) : base(guiObject) { }
        internal override void excuteAction()
        {
            DataManger.addObject(o);
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
            o = guiObject;
            copyObject = o.Copy();
        }
        internal override void excuteAction()
        {
            
        }

        public override Action GetReverseAction()
        {
            return new RestoreAction(o, copyObject);
        }
    }

    public class RestoreAction : Action
    {
        GUIObject memo;
        public RestoreAction(GUIObject guiObject,  GUIObject memo) : base(guiObject)
        {
            o = guiObject;
            this.memo = memo;
        }
        internal override void excuteAction()
        {
            o.restoreFromCopy(memo);
        }

        public override Action GetReverseAction()
        {
            throw new NotImplementedException();
        }
    }
}
