using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();                       // Метод по умолчанию
            Application.SetCompatibleTextRenderingDefault(false);   // Метод по умолчанию
            Application.Run(new Timer());                           // Метод вызывающий форму таймера                 
        }
    }
}
