using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HashSet<UcionicaAssets> rets = new HashSet<UcionicaAssets>();
            for (int i = 0; i < 5; i++)
            {
                rets.Add((UcionicaAssets)i);
            }

            Ucionica ucionica;
            ucionica = new Ucionica("cao", "32", 32, rets,new HashSet<Software>());
            Action action;
            action = new CreateAction(ucionica);
            DataControllercs.addAction(action);

            action = new CreateAction(ucionica);
            DataControllercs.addAction(action);

            action = new CreateAction(ucionica);
            DataControllercs.addAction(action);


            Application.Run(new Form1());
        }
    }
}
