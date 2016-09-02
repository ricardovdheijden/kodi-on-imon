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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new iMon()); //Loading the test driver instead that uses functionality
            Application.Run(new iMonTestDriver());
        }
    }
}
