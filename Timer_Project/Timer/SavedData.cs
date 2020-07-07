using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    [Serializable]
    class SavedData
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
        public short LastPY;                // Год когда я последний раз програмировал
        public byte LastPM;                 // Месяц когда я последний раз програмировал
        public byte LastPD;                 // День когда я последний раз програмировал
        public bool OvertM;                 // Эта переменная указывает в каком режиме находиться таймер(сверхурочные) на набор времени или нормальном
        public ushort TodayPTIS;            // Эта переменная хранит сегодняшнее время програмирования в секундах
    }
}
