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


            Ucionica ucionica;

            Action action;
            Random r = new Random();
            for (int i = 1; i < 25; i++)
            {
                ucionica = new Ucionica("MI-A2-2", "32", i*4, null, new HashSet<Software>());
                for (int j = 1; j < 6; j++)
                {
                    if (r.Next(100)>30)
                    {
                        ucionica.Assets.Add((UcionicaAssets)j);
                    }
                    
                }
                action = new CreateAction(ucionica);
                DataControllercs.addAction(action);
            }
                


            Application.Run(new Form1());
        }
    }
}
