using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kodi_on_iMon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Application.Run(new iMonTestDriver(args[0])); // iMonTestDriver() text to show
            }
            else
            {
                //Application.Run(new iMon()); //Loading the test driver instead that uses functionality
                Application.Run(new iMonTestDriver());
                //Application.Run(new KodiTestDriver());
            }
        }
    }
}
