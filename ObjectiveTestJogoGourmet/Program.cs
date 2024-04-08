using System;
using System.Windows.Forms;

namespace ObjectiveTestJogoGourmet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JogoGourmet());
            //Application.Run(new TesteJogoGourmet());
        }
    }
}
