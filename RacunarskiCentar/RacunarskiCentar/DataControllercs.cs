using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    static class DataControllercs
    {
        public static Stack<Action> actionsHistory = new Stack<Action>();
        public static Stack<Action> actionsRedo = new Stack<Action>();
        static public EventHandler<Action> onAction;
        public static bool isTutorial = false;
        public static List<Type> allowedTypes = new List<Type>();
        static public void addAction(Action action)
        {
            if (isTutorial)
            {

                if (!allowedTypes.Contains(action.GetType()))
                {
                    prikaziMessageBox();
                    return;
                }
            }
            action.excuteAction();
            actionsHistory.Push(action);
            actionsRedo.Clear();
            action.excuteAction();
        }
        static public  Action undoAction()
        {
           
            Action rets=null;
            if (actionsHistory.Count > 0)
            {
                if (isTutorial && !allowedTypes.Contains(actionsHistory.Peek().GetType()))
                {
                    prikaziMessageBox();
                    return null;
                }

                rets = actionsHistory.Pop().GetReverseAction();
              
                actionsRedo.Push(rets);
                rets.excuteAction();
            }
            
            return rets;
             
        }

        static public Action redoAction()
        {
            Action rets = null;
           
            if (actionsRedo.Count > 0)
            {
                if (isTutorial && !allowedTypes.Contains(actionsHistory.Peek().GetType()))
                {
                    prikaziMessageBox();
                    return null;
                }


                rets = actionsRedo.Pop().GetReverseAction();
               
                actionsHistory.Push(rets);
                rets.excuteAction();
            }
            
            return rets;

        }
        static DateTime lastMessageBox = DateTime.Now;
        private static void prikaziMessageBox()
        {
            TimeSpan ts = DateTime.Now - lastMessageBox;
            if (true)
            {
                MessageBox.Show("Brisanje podataka nije moguće za vreme tutorijala!", "Upozrenje");
                lastMessageBox = DateTime.Now;
            }
           
        }

        internal static bool undoAvailable()
        {
            return actionsHistory.Count > 0;
        }

        internal static bool RedoAvailable()
        {
            return actionsRedo.Count > 0;
        }

        internal static bool UndoAvailable()
        {
            return actionsHistory.Count > 0;
        }
    }


    public abstract class Action 
    {
        protected GUIObject o;
        protected List<Termin> termini = new List<Termin>();
        public Action(GUIObject guiObject)
        {
            o = guiObject;
        }
        public abstract Action GetReverseAction();
        internal virtual void excuteAction()
        {
            if (DataControllercs.onAction != null)
            {
                DataControllercs.onAction(null, this);
            }
        }
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
            if (o is Smer)
            {
                Smer s = o as Smer;
                termini = DataManger.getTerminsBySmer(s);
            }
            else if(o is Predmet)
            {
                Predmet p = o as Predmet;
                termini = DataManger.getTerminsByPredmet(p);
            }
            foreach(Termin t in termini)
            {
                t.Delete();
            }
            base.excuteAction();
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

            foreach(Termin t in termini)
            {
                DataManger.addObject(t);
            }
            base.excuteAction();
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
            base.excuteAction();
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

    public class ChainAction : Action
    {
        public List<Action> actions;
        public ChainAction() : base(null)
        {
            actions = new List<Action>();

        }
        internal override void excuteAction()
        {
           

            foreach (Action action in actions)
            {
                action.excuteAction();
            }
        }

        public override Action GetReverseAction()
        {
            List<Action> reverseActions = new List<Action>(actions);
            ChainAction reverse = new ChainAction();
            reverseActions.Reverse();
            foreach (Action action in reverseActions)
            {
                reverse.actions.Add(action.GetReverseAction());
            }

            return reverse;
        }
    }
}
