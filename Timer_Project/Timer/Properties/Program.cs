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

    [Serializable]
    struct SavedData                // Структура для сохранённых данных
    {
        public byte MondayH;                // Сколько часов програмировать в понедельник
        public byte MondayM;                // Сколько минут програмировать в понедельник
        public byte TuesdayH;               // Сколько часов програмировать во вторник
        public byte TuesdayM;               // Сколько минут програмировать во вторник
        public byte WednesdayH;             // Сколько часов програмировать в среду
        public byte WednesdayM;             // Сколько минут програмировать в среду
        public byte ThursdayH;              // Сколько часов програмировать в четверг
        public byte ThursdayM;              // Сколько минут програмировать в четверг
        public byte FridayH;                // Сколько часов програмировать в пятницу
        public byte FridayM;                // Сколько минут програмировать в пятницу
        public byte SaturdayH;              // Сколько часов програмировать в субботу
        public byte SaturdayM;              // Сколько минут програмировать в субботу
        public byte SunDayH;                // Сколько часов програмировать в воскресенье
        public byte SundayM;                // Сколько минут програмировать в воскресенье
        public byte TodayH;                 // Сколько часов осталось попрограмировать сегодня
        public byte TodayM;                 // Сколько минут осталось попрограмировать сегодня
        public byte TodayS;                 // Сколько секунд осталось попрограмировать
        public DateTime LastProgrDate;             // Когда я последний раз програмировал
    }
}
