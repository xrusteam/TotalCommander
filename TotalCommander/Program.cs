using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TotalCommander
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string firstpath = "";
            string secondpath = "";
            if (File.Exists("Work.txt"))
            {
                using (StreamReader text = new StreamReader("Work.txt"))
                {
                    firstpath += text.ReadLine();
                    secondpath += text.ReadLine();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(firstpath, secondpath));
        }
    }
}
