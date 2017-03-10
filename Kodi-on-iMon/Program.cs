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
            string parameterGuide = "Run this application with one of these parameters:" + Environment.NewLine + Environment.NewLine +
                    "idle\t\tDisplays a default scrolling text" + Environment.NewLine +
                    "idle \"TEXT\"\tDisplays the given scrolling TEXT" + Environment.NewLine +
                    "menu\t\tDisplays the menu" + Environment.NewLine +
                    "imon-testdriver\tRuns the imon-testdriver" + Environment.NewLine +
                    "kodi-testdriver\tRuns the kodi-testdriver" + Environment.NewLine + Environment.NewLine +
                    "Example:" + Environment.NewLine +
                    "kodi-on-imon.exe idle \"Your text\"";

            if (args.Length > 0) //add logic to find a parameter
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "idle" && args.Length > i + 1)
                    {
                        Application.Run(new iMonIdle(args[i + 1], true));
                    }
                    else if (args[i] == "idle")
                    {
                        Application.Run(new iMonIdle());
                    }
                    else if (args[i] == "menu")
                    {
                        Application.Run(new iMonMenu());
                    }
                    else if (args[i] == "imon-testdriver")
                    {
                        Application.Run(new iMonTestDriver());
                    }
                    else if (args[i] == "kodi-testdriver")
                    {
                        Application.Run(new KodiTestDriver());
                    }
                    else if (args[i] == "help" || args[i] == "/help" || args[i] == "?" || args[i] == "/?") {
                        MessageBox.Show(parameterGuide);
                    }
                }
            }
            else
            {
                //MessageBox.Show(parameterGuide);
                Application.Run(new KodiTestDriver());
                //Application.Run(new iMonIdle());
                //Application.Run(new iMonMenu());
                //Application.Run(new iMon()); //Loading the test driver instead that uses functionality
                //Application.Run(new iMonTestDriver());
            }
        }
    }
}
