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
            string tipovi = "";
            TimeSpan ts = DateTime.Now - lastMessageBox;
            if (!allowedTypes.Contains(typeof(CreateAction)))
            {
                tipovi += "dodavanje";
            }
            if (!allowedTypes.Contains(typeof(DeleteAction)))
            {
                if (tipovi.Length > 0)
                {
                    tipovi += ", ";
                }
                tipovi += "brisanje";
            }
            if (!allowedTypes.Contains(typeof(ChainAction)))
            {
                if (tipovi.Length > 0)
                {
                    tipovi += ", ";
                }
                tipovi += "pomeranje";
            }

            MessageBox.Show("Za vreme tutorijala nije dozvoljeno " + tipovi + "  podataka.", "Upozrenje");
            lastMessageBox = DateTime.Now;

           
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
        public DateTime timeOfCreation;
        protected List<Termin> termini = new List<Termin>();

        public Action(GUIObject guiObject)
        {
            o = guiObject;
            timeOfCreation = DateTime.Now;
        }
        public abstract Action GetReverseAction();
        internal virtual void excuteAction()
        {
            if (DataControllercs.onAction != null)
            {
                DataControllercs.onAction(null, this);
            }
            if (!DataControllercs.isTutorial)
            {
                DataManger.save();
            }
           
        }
        public override string ToString()
        {
            string rets = "";
            if (o is Predmet)
            {
                rets = "predmeta sa id-om ";
            }
            else if (o is Smer)
            {
                rets = "smera sa id-om ";
            }
            else if (o is Ucionica)
            {
                rets = "učionice sa id-om ";
            }
            else if (o is Termin)
            {
                rets = "termina koji pripada predmetu: ";
            }
            else if (o is Software)
            {
                rets = "s sa id-om ";
            }
            rets += o.ToString();
            return rets;
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
            DeleteAction deleteA;
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
                deleteA = new DeleteAction(t);
                deleteA.excuteAction();

            }
            base.excuteAction();
        }

        public override Action GetReverseAction()
        {
            Action a = new CreateAction(o);
            a.timeOfCreation = timeOfCreation;
            return a;
        }
        public override string ToString()
        {

            return timeOfCreation.ToShortTimeString() + ":" + " Akcija brisanja " + base.ToString(); 
        }
    }

    public class CreateAction : Action
    {
        public CreateAction(GUIObject guiObject) : base(guiObject) { }
        internal override void excuteAction()
        {
            DataManger.addObject(o);
            CreateAction cAction;

            foreach(Termin t in termini)
            {
                cAction = new CreateAction(t);
                cAction.excuteAction();
            }
            base.excuteAction();
        }

        public override Action GetReverseAction()
        {
            DeleteAction d = new DeleteAction(o);
            d.timeOfCreation = timeOfCreation;
            return d;
        }
        public override string ToString()
        {
            return timeOfCreation.ToShortTimeString() + ":" + " Akcija kreiranja " + base.ToString();
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
            RestoreAction a = new RestoreAction(o, copyObject);
            a.timeOfCreation = timeOfCreation;
            return a;
        }
        public override string ToString()
        {
            return timeOfCreation.ToShortTimeString() + ":" + " Akcija izmene " + base.ToString();
        }
    }

    public class RestoreAction : Action
    {
        GUIObject memo;
        GUIObject preRestore;
        public RestoreAction(GUIObject guiObject,  GUIObject memo) : base(guiObject)
        {
            o = guiObject;
            this.memo = memo;
        }
        internal override void excuteAction()
        {
            preRestore = o.Copy();
            o.restoreFromCopy(memo);
            base.excuteAction();
        }

        public override Action GetReverseAction()
        {
            RestoreAction a = new RestoreAction(o, preRestore);
            a.timeOfCreation = timeOfCreation;
            return a;
        }
        public override string ToString()
        {
            return timeOfCreation.ToShortTimeString() + ":" + " Akcija izmene " + base.ToString();
        }
    }

    public class ChainAction : Action
    {
        public List<Action> actions;
        public ChainAction(GUIObject guiObject) : base(guiObject)
        {
            actions = new List<Action>();

        }
        internal override void excuteAction()
        {
           
            foreach (Action action in actions)
            {
                action.excuteAction();
            }
            base.excuteAction();
        }

        public override Action GetReverseAction()
        {
            List<Action> reverseActions = new List<Action>(actions);
            ChainAction reverse = new ChainAction(o);
            reverseActions.Reverse();
            foreach (Action action in reverseActions)
            {
                reverse.actions.Add(action.GetReverseAction());
            }
            reverse.timeOfCreation = timeOfCreation;

            return reverse;
        }
        public override string ToString()
        {
            return timeOfCreation.ToShortTimeString() + ":" + " Akcija pomeranja " + base.ToString();
        }
    }
}
