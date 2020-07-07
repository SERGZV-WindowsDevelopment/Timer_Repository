using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

// При нажатии на кнопку старт при сверхурочных таймер просигнализировал о том что мне надо отдохнуть хотя я отдыхал не час назад а пол часа назад, я не отдохнул но при старте он мне просигнализировал
// .ещё раз что надо отдохнуть я не уверен нужно ли сигналаизировать об отдыхе второй раз если я ещё не отдохнул при повторном нажатии на кнопку пуск, возможно что и да об этом ещё надо подумать
// ..но насчёт того что сигнал прозвучал раньше и тамер показывает отдохните это нужно проверить воссоздав ошибку.

namespace Timer
{ 
    public partial class Timer : Form
    {
        SoundPlayer EndProgrammingSound;                                            // Сдесь будет лежать звук конец програмирования
        SoundPlayer RelaxationSound;                                                // Сдесь будет лежать звук отдыха
        SoundPlayer EndRelaxationSound;                                             // Сдесь будет лежать звук конца отдыха
        Color Green = Color.FromArgb(0, 230, 0);                                    // Зелёный цвет
        Color DullGreen = Color.FromArgb(0, 80, 0);                                 // Тусклозелёный цвет
        Color Orange = Color.FromArgb(255, 128, 0);                                 // Ораньжевый цвет
        Color DullOrange = Color.FromArgb(150, 120, 50);                            // Тусклоораньжевый цвет
        Color Blue = Color.FromArgb(0, 70, 225);                                    // Специально мной подобранный голубой цвет
        short NormalWidth = 390;                                                    // Нормальная ширина окна таймера
        short NormalHeight = 227;                                                   // Нормальная высота окна таймера
        short ExpandWidth = 620;                                                    // Расширенная ширина окна таймера
        byte TodayHours;                                                            // Сколько часов осталось сегодня попрограмировать
        byte TodayMinutes;                                                          // Сколько минут осталось сегодня попрограмировать
        byte TodaySeconds;                                                          // Сколько секунд осталось сегодня попрограмировать
        byte LeftForEyesRelaxationMinutes = 60;                                     // Сдесь храняться минуты которые указывают сколько осталось до отдыха для глаз
        byte LeftForEyesRelaxationSeconds;                                          // Сдесь храняться секунды которые указывают сколько осталось до отдыха для глаз
        byte EyesRelaxationMinutes = 5;                                             // Сдесь храняться минуты которые указывают сколько осталось до конца отдыха для глаз
        byte EyesRelaxationSeconds;                                                 // Сдесь храняться секунды которые указывают сколько осталось до конца отдыха для глаз
        ushort TodayProgTimeInSec;                                                  // Сдесь храниться сегодняшнее время програмирования в секундах (Максимальное время которое мы не уменьшаем)
        short LastProgrammingYear;                                                  // Год последнего програмирования
        byte LastProgrammingMonth;                                                  // Месяц последнего програмирования
        byte LastProgrammingDay;                                                    // День последнего програмирования
        public TextBox labe = new TextBox();                                        // Создаём на том же месте поле ввода времени с именем labe 
        string pathMyDocuments;                                                     // Сдесь бюудет лежать путь к папке мои документы
        bool OvertimeMode;                                                          // Эта переменная указывает в каком режиме находиться таймер (сверхурочные) на набор времени или нормальном
        string WorkMode = "Stop";                                                   // Тут может быть один из трёх режимов, 1) Работа (Work), 2) Стоп (Stop), 3) Отдых (Relaxation)
        bool Tick;                                                                  // Эта переменная указывает был ли включен таймер только что или он уже успел совершить хотябы один тик
        bool PlayRelaxationSound;                                                   // Эта переменная указывает был ли уже проигран звук из переменной "RelaxationSound"
        bool PlayAfterRalaxationSound;                                              // Эта переменная указывает был ли уже проигран звук из переменной "EndRelaxationSound"

        public Timer()
        {
            InitializeComponent();                                                              // Требуемый метод для поддержки конструктора
        }


        void Timer_Load(object sender, EventArgs e)                                             // Обработчик события который вызываеться при загрузке окна таймера
        {
            EndProgrammingSound = new SoundPlayer(@"C:\Windows\Media\tada.wav");                // Заносим звук конец програмирования в переменную "EndProgrammingSound"
            RelaxationSound = new SoundPlayer(@"C:\Windows\Media\Speech Off.wav");              // Заносим звук отдыха в переменную "RelaxationSound"
            EndRelaxationSound = new SoundPlayer(@"C:\Windows\Media\notify.wav");               // Заносим звук конец отдыха в переменную EndRelaxationSound

            this.DesktopBounds = new Rectangle(this.Location.X, this.Location.Y, NormalWidth, NormalHeight);    // Ставим форме "Timer" нормальные сжатые размеры
            pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);    // Записываем в переменную path путь к папке мои документы
            if (!Directory.Exists(pathMyDocuments + "/MyPrograms/Timer/Save"))                  // Если дирректории по текущему адресу не существует
            {
                Directory.CreateDirectory(pathMyDocuments + "/MyPrograms/Timer/Save");          // Создаём путь к дирректории папки "Save" и саму папку 
            }
            if (File.Exists(pathMyDocuments + "/MyPrograms/Timer/Save/Save.bin"))               // Если файл сохранения существует
            {
                LoadInformation();                                                              // Вызываем метод Загрузки информации из файла "Save"

                // Проверяем соответствует ли сохранённый год, месяц, и день сегодняшним, и если сегодня уже другой день, месяц или год то я сегодня не програмировал тогда мы выполняем следующий код...
                if (LastProgrammingYear != DateTime.Now.Year | LastProgrammingMonth != DateTime.Now.Month | LastProgrammingDay != DateTime.Now.Day)
                {
                    UpdatingDay();                                                      // Обновляем переменные для сегодняшнего дня
                }
                TimeProgressBar.Maximum = TodayProgTimeInSec;                           // Присваиваем сегодняшнее время програмирования в секундах верхней границе "TimeProgressBar"
                CalculateTime();                                                        // Высчитываем время и помещаем его на табло (кнопку)
            }
            else                                                                        // Иначе если файла сохранения не существует
            {
                LastProgrammingYear = 1990;                                             // Устанавливаем год когда мы последний раз програмировали
                LastProgrammingMonth = 07;                                              // Устанавливаем месяц когда мы последний раз програмировали
                LastProgrammingDay = 31;                                                // Устанавоиваем день когда мы последний раз програмировали

                CalculateTime();                                                        // Высчитываем время и помещаем его на табло (кнопку)    
            }

            DayOfTheWeekIndicator();                                                    // Вызываем метод который устанавливает на этикетке "LabelDayOfWeek" сегодняшний день недели

            if (OvertimeMode)                                                           // Если режим сверхурочных активирован
            {
                LabelTimerMode.Enabled = true;                                          // Ставим переменной "OvertimeMode" значение правда (Делаем видимым текст сверхурочные)
                TimeButton.ForeColor = DullOrange;                                      // Задаём цифрам тусклоораньжевый цвет
                LabelDayOfWeek.ForeColor = DullOrange;                                  // Задаём этикетке указывающей какой сегодня день недели тусклоораньжевый цвет                  
            }
        }
        

        void Start_Click(object sender, EventArgs e)                                    // Этот метод вызываеться при нажатии на кнопку старт
        {
            if (TodayHours != 0 | TodayMinutes != 0 | TodaySeconds != 0){}              // Если осталось время для програмирования 
            else                                                                        // Иначе если часы, минуты и секунды равны нулю
                OvertimeMode = true;                                                    // Включаем режим сверхурочные

            if (!OvertimeMode)                                                          // Если сейчас не стоит режим сверхурочных
            {
                TimeButton.ForeColor = Green;                                           // Задаём цифрам зелёный цвет цвет
                LabelDayOfWeek.ForeColor = Green;                                       // Задаём этикетке указывающей какой сегодня день недели зелёный цвет
            }
            else                                                                        // Иначе если сейчас стоит режим сверхурочных
            {
                LabelTimerMode.Enabled = true;                                          // Ставим переменной "LabelTimerMode" значение правда (Делаем видимым текст сверхурочные)
                LabelTimerMode.ForeColor = Orange;                                      // Задаём этикетке LabelTimerMode ораньжевый цвет
                TimeButton.ForeColor = Orange;                                          // Задаём цифрам ораньжевый цвет
                LabelDayOfWeek.ForeColor = Orange;                                      // Задаём этикетке указывающей какой сегодня день недели ораньжевый цвет
                TimeProgressBar.Value = TimeProgressBar.Maximum;                        // Заполняем полностью полоску времени
                
            }

            LabelRest.Text = "";                                                        // Стираем текст у этикетки "LabelRest"

            EyesRelaxationMinutes = 5;                                                  // Устанавливаем сколько нужно отдохнуть минут в переменную EyesRelaxationMinutes
            EyesRelaxationSeconds = 0;                                                  // Устанавливаем сколько нужно отдохнуть секунд в переменную EyesRelaxationSeconds

            PlayRelaxationSound = false;                                                // Ставим переменной "PlayRelaxationSound" значение ложь
            PlayAfterRalaxationSound = false;                                           // Ставим переменной "PlayAfterRalaxationSound" значение ложь
            WorkMode = "Work";                                                          // Ставим переменной "WorkMode" значение "Work" Тоесть ставим режим работы
            MyTimer.Start();                                                            // Этот метод запускает элемент "Timer" из панели элементов
        }


        void Stop_Click(object sender, EventArgs e)                                     // Этот метод вызываеться каждый раз при нажатии на кнопку стоп
        {
            if (WorkMode == "Work")                                                     // Если таймер находилься в режиме работы
            {
                WorkMode = "Stop";                                                      // Ставим таймер в режим стоп "Stop"
                MyTimer.Stop();                                                         // Останавливаем таймер так как в режиме стоп таймер не должен считать он должен стоять
                CalculateTime();                                                        // Вызываем метод "CalculateTime" чтобы этикетка "LabelRest" стала жёлтой и написала что сейчас режим "Стоп"
            }
            else if (WorkMode == "Stop")
            {
                WorkMode = "Relaxation";                                                // Ставим таймер в режим отдыха "Relaxation"
                MyTimer.Start();                                                        // Запускаем таймер если он не запущен, так как по нажатию на стоп таймер должен должен считать отдых
            }

            if (!OvertimeMode)                                                          // Если сейчас не стоит режим сверхурочных
            {
                TimeButton.ForeColor = DullGreen;                                       // Задаём цифрам тусклозелёный цвет
                LabelDayOfWeek.ForeColor = DullGreen;                                   // Задаём дню недели тусклозелёный цвет
            }
            else                                                                        // Иначе если сейчас стоит режим сверхурочных
            {
                LabelTimerMode.ForeColor = DullOrange;                                  // Задаём тексту сверхурочные тусклоораньжевый свет
                TimeButton.ForeColor = DullOrange;                                      // Задаём цифрам тусклоораньжевый цвет
                LabelDayOfWeek.ForeColor = DullOrange;                                  // Задаём дню недели тусклоораньжевый цвет
            }
            SaveIformation();                                                           // Вызываем метод сохранения информации
        }


        private void Update_Click(object sender, EventArgs e)                           // Обработчик событий для события нажатия на кнопку "Update"
        {
            if (WorkMode == "Work")                                                     // Если таймер находиться в режиме работы
            {
                TimeButton.ForeColor = Green;                                           // Задаём цифрам зелёный цвет цвет
                LabelDayOfWeek.ForeColor = Green;                                       // Задаём этикетке указывающей какой сегодня день недели зелёный цвет
            }
            else                                                                        // Иначе если таймер находиться в режиме "Стоп" или "Отдых"
            {
                if (OvertimeMode)                                                       // Также если таймер находиться в режиме "Сверхурочные"
                {
                    TimeButton.ForeColor = DullGreen;                                   // Задаём цифрам тусклозелёный цвет
                    LabelDayOfWeek.ForeColor = DullGreen;                               // Задаём дню недели тусклозелёный цвет
                }
            }

            UpdatingDay();                                                              // Вызываем метод обновления дня          
            LabelTimerMode.Enabled = false;                                             // Ставим переменной "OvertimeMode" значение ложь (Делаем невидимым текст сверхурочные)
            TimeProgressBar.Maximum = TodayProgTimeInSec;                               // Присваиваем сегодняшнее время програмирования в секундах верхней границе "TimeProgressBar"
            CalculateTime();                                                            // Вызываем метод обновляющий время на кнопке-табло
        }


        private void ExpandButton_Click(object sender, EventArgs e)                                             // Этот метод вызываеться при нажатии кнопки развернуть
        {
            this.DesktopBounds = new Rectangle( this.Location.X, this.Location.Y, ExpandWidth, NormalHeight);   // Задаём окну развёрнутые размеры
        }

        private void ConstrictionButton_Click(object sender, EventArgs e)                                       // Обработчик событий кнопки "Cвернуть"
        {
            this.DesktopBounds = new Rectangle(this.Location.X, this.Location.Y, NormalWidth, NormalHeight);    // Задаём окну компактные размеры
            SaveIformation();                                                                                   // Вызываем метод сохранения информации
        }


        //---------------------------------------------------------------- Методы ------------------------------------------------------------------------------------------------------------------------


        ushort ProgrammingTimeInSeconds(byte H, byte M, byte S)         // Этот метод пересчитывает отправленное ему время в часах минутах и секундах и возвращает значение в секундах                                   
        {
            ushort Seconds;                                             // Сдесь будет храниться результат отправленного сюда времени в секундах
            ushort HoursInSeconds;                                      // Сдесь будут храниться часы переведённые в секунды
            short MinutesInSeconds;                                     // Сдесь будут храниться значения минут переведённых в секунды

            HoursInSeconds = (ushort)(H * 3600);                        // Переводим отправленные сюда часы в секунды
            MinutesInSeconds = (short)(M * 60);                         // Переводим отправленные сюда минуты в секунды

            Seconds = (ushort)(HoursInSeconds + MinutesInSeconds + S);  // Складываем часы в секундах, минуты в секундах, и секунды отправленные сюда и присваиваем результат "Seconds"    

            if (Seconds <= 0) Seconds = 1;                              // Если на сегодня вообще нет времени програмирования ставим 1 секунду чтобы даже в этом случае полоска заполнялась корректно

            return Seconds;                                             // Возвращаем высчитанное количество секунд из метода
        }
        
        
        void UpdatingDay()                                          // Этот метод заполняет таймер новой инофрмации при старте нового дня 
        {
            LastProgrammingYear = (short)DateTime.Now.Year;         // Записываем сегодняшний год програмирования
            LastProgrammingMonth = (byte)DateTime.Now.Month;        // Записываем сегодняшний месяц програмирования
            LastProgrammingDay = (byte)DateTime.Now.Day;            // Записываем сегодняшний день програмирования
            OvertimeMode = false;                                   // Ставим переменную "OvertimeMode" Равной false
            UpdatingProgrammingTime();                              // Вызываем метод заполняющий переменные TodayHours и TodayMinutes
            TodaySeconds = 0;                                       // Обнуляем возможно оставшиеся со вчерашнего дня секунды
        }

        void DayOfTheWeekIndicator()                                // Метод присваивающий текст сегодняшнего дня кнопке "LabelDayOfWeek"
        {
            byte DayOfWeek = (byte)DateTime.Today.DayOfWeek;        // Ложим день недели в переменную DayOfWeek

            switch (DayOfWeek)                                      // Переключатель зависящий от переменной "DayOfWeek"
            {
                case 0:                                             // В случае если сегодня воскресенье
                    LabelDayOfWeek.Text = "Sunday";                 // Присваиваем текст "Воскресенье" этикетке "День недели"
                    break;
                case 1:                                             // В случае если сегодня понедельник
                    LabelDayOfWeek.Text = "Monday";                 // Присваиваем текст "Понедельник" этикетке "День недели"   
                    break;
                case 2:                                             // В случае если сегодня вторник
                    LabelDayOfWeek.Text = "Tuesday";                // Присваиваем текст "Вторник" этикетке "День недели"
                    break;
                case 3:                                             // В случае если сегодня среда
                    LabelDayOfWeek.Text = "Wednesday";              // Присваиваем текст "Среда" этикетке "День недели"
                    break;
                case 4:                                             // В случае если сегодня четверг
                    LabelDayOfWeek.Text = "Thursday";               // Присваиваем текст "Четверг" этикетке "День недели"
                    break;
                case 5:                                             // В случае если сегодня пятница
                    LabelDayOfWeek.Text = "Friday";                 // Присваиваем текст "Пятница" этикетке "День недели"
                    break;
                case 6:                                             // В случае если сегодня суббота
                    LabelDayOfWeek.Text = "Saturday";               // Присваиваем текст "Суббота" этикетке "День недели"
                    break;
            }
        }


        void UpdatingProgrammingTime()                              // Этот метод записывает в переменные оставшегося времени програмирования время указанное на сегодня
        {
            byte DayOfWeek = (byte)DateTime.Today.DayOfWeek;        // Ложим день недели в переменную DayOfWeek

            switch (DayOfWeek)
            {
                case 0:                                             // В случае если сегодня воскресенье
                    TodayHours = (byte)SundayHours.Value;           // То количество часов которое нужно сегодня попрограмировать берём из SundayHours
                    TodayMinutes = (byte)SundayMinutes.Value;       // А количество минут берём из SundayMinutes
                    break;
                case 1:                                             // В случае если сегодня понедельник
                    TodayHours = (byte)MondayHours.Value;           // То количество часов которое нужно сегодня попрограмировать берём из MondayHours
                    TodayMinutes = (byte)MondayMinutes.Value;       // А количество минут берём из MondayMinutes
                    break;
                case 2:                                             // В случае если сегодня вторник
                    TodayHours = (byte)TuesdayHours.Value;          // То количество часов которое нужно сегодня попрограмировать берём из TuesdayHours
                    TodayMinutes = (byte)TuesdayMinutes.Value;      // А количество минут берём из TuesdayMinutes
                    break;
                case 3:                                             // В случае если сегодня среда
                    TodayHours = (byte)WednesdayHours.Value;        // То количество часов которое нужно сегодня попрограмировать берём из WednesdayHours
                    TodayMinutes = (byte)WednesdayMinutes.Value;    // А количество минут берём из WednesdayMinutes
                    break;
                case 4:                                             // В случае если сегодня четверг
                    TodayHours = (byte)ThursdayHours.Value;         // То количество часов которое нужно сегодня попрограмировать берём из ThursdayHours
                    TodayMinutes = (byte)ThursdayMinutes.Value;     // А количество минут берём из ThursdayMinutes
                    break;
                case 5:                                             // В случае если сегодня пятница
                    TodayHours = (byte)FridayHours.Value;           // То количество часов которое нужно сегодня попрограмировать берём из FridayHours
                    TodayMinutes = (byte)FridayMinutes.Value;       // А количество минут берём из FridayMinutes
                    break;
                case 6:                                             // В случае если сегодня суббота
                    TodayHours = (byte)SaturdayHours.Value;         // То количество часов которое нужно сегодня попрограмировать берём из SaturdayHours
                    TodayMinutes = (byte)SaturdayMinutes.Value;     // А количество минут берём из SaturdayMinutes
                    break;
            }

            TodayProgTimeInSec = ProgrammingTimeInSeconds(TodayHours, TodayMinutes, 0); // Присваиваем переменной TodayProgTimeInSec сколько сегодня програмировать в секундах
        }


        private void MyTimer_Tick(object sender, EventArgs e)                   // Этот метод вызываеться элементом "Timer" из манели элементов раз в секунду
        {
            CalculateTime();
        }


        void CalculateTime()                                                    // Этот метод высчитывает оставшееся время
        {
            ushort LeftTodayProgramInSeconds;                                   // Сдесь будет храниться сколько нам осталось програмировать в секундах

            if (WorkMode == "Work")                                             // Если таймер находиться в режиме работы
            {
                if (!OvertimeMode)                                              // Если таймер не находиться в режиме сверхурочных
                {
                    LeftTodayProgramInSeconds = ProgrammingTimeInSeconds(TodayHours, TodayMinutes, TodaySeconds);
                    TimeProgressBar.Value = (TimeProgressBar.Maximum - LeftTodayProgramInSeconds);  // Высчитываем какое теперь значение у "TimeProgressBar"

                    if (TodaySeconds <= 0)                                      // Если количество секунд меньше или равно нулю
                    {
                        if (TodayMinutes <= 0)                                  // И если количество минут меньше или равно нулю
                        {
                            if (TodayHours <= 0)                                // И если количество часов меньше или равно нулю
                            {
                                if (Tick) EndProgrammingSound.Play();           // Если произошёл хотябы один тик то издаём сигнал что сегодня я попрограмировал запланированное время 
                                MyTimer.Stop();                                 // Останавливаем таймер
                            }
                            else                                                // Если количество часов больше ноля
                            {
                                TodayHours--;                                   // Уменьшаем количество часов на 1
                                TodayMinutes = 59;                              // Ставим количество минут на 59
                                TodaySeconds = 59;                              // Ставим количество секунд на 59
                                Tick = true;                                    // Ставим что произошёл тик
                            }
                        }
                        else                                                    // Иначе если количество минут больше ноля
                        {
                            TodayMinutes--;                                     // Уменьшаем количество минут на 1
                            TodaySeconds = 59;                                  // Ставим количество секунд на 59 
                            Tick = true;                                        // Ставим что произошёл тик
                        }
                    }
                    else                                                        // Иначе если количество секунд больше ноля
                    {
                        TodaySeconds--;                                         // Уменьшаем количество секунд на 1
                        Tick = true;                                            // Ставим что произошёл тик
                    }
                }
                else                                                            // Иначе если таймер находиться в режиме сверхурочные
                {
                    if (TodaySeconds >= 59)                                     // Если количество секунд больше или равно 59
                    {
                        if (TodayMinutes >= 59)                                 // Если количество минут больше или равно 59
                        {
                            TodayHours++;                                       // Прибавляем на один количество часов
                            TodayMinutes = 0;                                   // Ставим количество минут равным нулю
                            TodaySeconds = 0;                                   // Ставим количество секунд равным нулю
                        }
                        else                                                    // Иначе если количество минут меньше 59
                        {
                            TodaySeconds = 0;                                   // Увеличиваем значение "TodaySeconds" на 1
                            TodayMinutes++;                                     // Увеличиваем количество минут на 1
                        }

                    }
                    else                                                        // Иначе если количество секунд меньше 59
                        TodaySeconds++;                                         // Увеличиваем значение "TodaySeconds" на 1
                }


                if (LeftForEyesRelaxationSeconds <= 0)                          // Если количество секунд в переменной LeftForEyesRelaxationSeconds меньше или равно нулю
                {
                    if (LeftForEyesRelaxationMinutes <= 0)                      // Если количество минут в переменной LeftForEyesRelaxationMinutes меньше или равно нулю
                    {
                        if (!PlayRelaxationSound)                               // Если звук отдыха ещё не был проигран 
                        {
                            RelaxationSound.Play();                             // Издаём звуковой сигнал отдыха
                            LabelRest.ForeColor = Blue;                         // Ставим этикетке "LabelRest" голубой цвет
                            LabelRest.Text = "Отдохните";                       // Делаем видимой этикетку "LabelRest" говорящей о том что порабы отдохнуть
                            PlayRelaxationSound = true;                         // Ставим значение переменной "PlayRelaxationSound" правда указывая что звук был проигран
                        }
                    }
                    else                                                        // Иначе если количество минут в переменной LeftForEyesRelaxationMinutes больше ноля
                    {
                        LeftForEyesRelaxationMinutes--;                         // То уменьшаем количество минут в переменной LeftForEyesRelaxationMinutes на одну
                        LeftForEyesRelaxationSeconds = 59;                      // А количество секунд в переменной LeftForEyesRelaxationSeconds ставим равными 59
                    }
                }
                else                                                            // Иначе если количество секунд в переменной LeftForEyesRelaxationSeconds больше ноля
                {
                    LeftForEyesRelaxationSeconds--;                             // То уменьшаем количество секунд в переменной LeftForEyesRelaxationSeconds на одну
                }
            }
            if (WorkMode == "Stop")                                             // Иначе если таймер находиться в режиме "Стоп"
            {
                LabelRest.ForeColor = Color.Yellow;                             // Ставим этикетке "LabelRest" жёлтый цвет
                LabelRest.Text = "Стоп";                                        // Присваиваем этикетке "LabelRest" текст "LaelRest"
            }
            else if (WorkMode == "Relaxation")                                  // Иначе если таймер находиться в режиме отдыха
            {
                if (EyesRelaxationSeconds <= 0)                                 // Если количество секунд в переменной EyesRelaxationSeconds меньше ноля
                {
                    if (EyesRelaxationMinutes <= 0)                             // Если количество минут в переменной EyesRelaxationMinutes Меньше ноля
                    {
                        if (!PlayAfterRalaxationSound)                          // Если звук оповещающий о том что отдых закончилься ещё не был проигран
                        {
                            EndRelaxationSound.Play();                          // То издаём звук оповещающий о том что отдых закончилься
                            LeftForEyesRelaxationMinutes = 60;                  // Указываем переменной LeftForEyesRelaxationMinutes 60 минут так как отдых был полностью использован
                            LeftForEyesRelaxationSeconds = 0;                   // Указываем переменной LeftForEyesRelaxationSeconds 0 секунд
                            MyTimer.Stop();                                     // Останавливаем таймер
                            PlayAfterRalaxationSound = true;                    // Указываем переменной "EndRelaxationSound" значение "true"
                        }
                    }
                    else                                                        // Иначе если количество минут в переменной больше ноля
                    {
                        EyesRelaxationMinutes--;                                // То уменьшаем количество минут в переменной EyesRelaxationMinutes на одну
                        EyesRelaxationSeconds = 59;                             // А количество секунд в переменной EyesRelaxationSeconds ставим равными 59
                    }
                }
                else                                                            // Иначе если количество секунд в переменной EyesRelaxationSeconds больше ноля
                {
                    EyesRelaxationSeconds--;                                    // То уменьшаем количество минут в переменной EyesRelaxationMinutes на одну
                }
                // Форматируем строку чтобы часы минуты и секунды показывались в двухзначном формате и присваиваем получившийся текст времени отдыха тексту этикетки показывающей время отдыха
                LabelRest.Text = String.Format("{0:d2}:{1:d2}", EyesRelaxationMinutes, EyesRelaxationSeconds); 
                LabelRest.ForeColor = Blue;                                     // Ставим этикетке "LabelRest" голубой цвет
            }

            // Форматируем строку чтобы часы минуты и секунды показывались в двухзначном формате и присваиваем получившийся текст времени програмирования тексту кнопки показывающей время  
            TimeButton.Text = String.Format("{0:d2}:{1:d2}:{2:d2}", TodayHours, TodayMinutes, TodaySeconds);        
        }


        void SaveIformation()                                       // Этот метод сохраняет информацию в бинарный файл
        {     
            SavedData Save = new SavedData();                       // Создаём объект "Save" структуры "SaveData"
            Save.MondayH = (byte)MondayHours.Value;                 // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "MondayH"
            Save.MondayM = (byte)MondayMinutes.Value;               // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "MondayM"
            Save.TuesdayH = (byte)TuesdayHours.Value;               // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "TuesdayH"
            Save.TuesdayM = (byte)TuesdayMinutes.Value;             // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "TuesdayM"
            Save.WednesdayH = (byte)WednesdayHours.Value;           // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "WednesdayH"
            Save.WednesdayM = (byte)WednesdayMinutes.Value;         // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "WednesdayM"
            Save.ThursdayH = (byte)ThursdayHours.Value;             // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "ThursdayH"
            Save.ThursdayM = (byte)ThursdayMinutes.Value;           // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "ThursdayM"
            Save.FridayH = (byte)FridayHours.Value;                 // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "FridayH"
            Save.FridayM = (byte)FridayMinutes.Value;               // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "FridayM"
            Save.SaturdayH = (byte)SaturdayHours.Value;             // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "SaturdayH"
            Save.SaturdayM = (byte)SaturdayMinutes.Value;           // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "SaturdayM"
            Save.SunDayH = (byte)SundayHours.Value;                 // Сохраняем число часов програмирования для понедельника в объект "Save" переменную "SunDayH"
            Save.SundayM = (byte)SundayMinutes.Value;               // Сохраняем число минут програмирования для понедельника в объект "Save" переменную "SundayM"
            Save.TodayH = TodayHours;                               // Сохраняем число оставшихся часов програмирования для сегодняшнего дня в объект "Save" переменную "TodayH"
            Save.TodayM = TodayMinutes;                             // Сохраняем число оставшихся минут програмирования для сегодняшнего дня в объект "Save" переменную "TodayM"
            Save.TodayS = TodaySeconds;                             // Сохраняем число оставшихся секунд програмирования для сегодняшнего дня в объект "Save" переменную "TodayS"
            Save.LastPY = LastProgrammingYear;                      // Сохраняем год последнего програмирования
            Save.LastPM = LastProgrammingMonth;                     // Сохраняем месяц последнего програмирования
            Save.LastPD = LastProgrammingDay;                       // Сохраняем день последнего програмирования
            Save.OvertM = OvertimeMode;                             // Сохраняем режим програмирования
            Save.TodayPTIS = TodayProgTimeInSec;                    // Сохраняем сегодняшнее время програмирования в секундах

            // Создаём поток с адресом сохранения файла Save.bin и если файл существует мы открываем его, если он не существует то мы его создаём
            FileStream SaveStream = new FileStream(pathMyDocuments + "/MyPrograms/Timer/Save/Save.bin", FileMode.OpenOrCreate);
            BinaryFormatter Serializer = new BinaryFormatter();         // Создаём объект класса серриализатора
            Serializer.Serialize(SaveStream, Save);                     // Серриализуем оюъект "Save" в поток "Serializer"

            SaveStream.Close();                                         // Закрываем поток "SaveStream"
        }


        void LoadInformation()                                          // Этот метод загружает информацию из бинарного файла
        { 
            IFormatter Form = new BinaryFormatter();                    // Создаём Дессериализатор
            FileStream LoadStream = new FileStream(pathMyDocuments + "/MyPrograms/Timer/Save/Save.bin", FileMode.Open, FileAccess.Read);    // Создаём поток "LoadStream" читающий файл "Save"
            SavedData Load = (SavedData)Form.Deserialize(LoadStream);   // Создаём объект "Load" и десериализуем в него поток "LoadStream"

            MondayHours.Value = Load.MondayH;                       // Загружаем значение "MondayH" из потока "Load" в переменную "Value" объекта "MondayHours"
            MondayMinutes.Value = Load.MondayM;                     // Загружаем значение "MondayM" из потока "Load" в переменную "Value" объекта "MondayMinutes"
            TuesdayHours.Value = Load.TuesdayH;                     // Загружаем значение "TuesdayH" из потока "Load" в переменную "Value" объекта "TuesdayHours"
            TuesdayMinutes.Value = Load.TuesdayM;                   // Загружаем значение "TuesdayM" из потока "Load" в переменную "Value" объекта "TuesdayMinutes"
            WednesdayHours.Value = Load.WednesdayH;                 // Загружаем значение "WednesdayH" из потока "Load" в переменную "Value" объекта "WednesdayHours"
            WednesdayMinutes.Value = Load.WednesdayM;               // Загружаем значение "WednesdayM" из потока "Load" в переменную "Value" объекта "WednesdayMinutes"
            ThursdayHours.Value = Load.ThursdayH;                   // Загружаем значение "ThursdayH" из потока "Load" в переменную "Value" объекта "ThursdayHours"
            ThursdayMinutes.Value = Load.ThursdayM;                 // Загружаем значение "ThursdayM" из потока "Load" в переменную "Value" объекта "ThursdayMinutes"
            FridayHours.Value = Load.FridayH;                       // Загружаем значение "FridayH" из потока "Load" в переменную "Value" объекта "FridayHours"
            FridayMinutes.Value = Load.FridayM;                     // Загружаем значение "FridayM" из потока "Load" в переменную "Value" объекта "FridayMinutes"
            SaturdayHours.Value = Load.SaturdayH;                   // Загружаем значение "SaturdayH" из потока "Load" в переменную "Value" объекта "SaturdayHours"
            SaturdayMinutes.Value = Load.SaturdayM;                 // Загружаем значение "SaturdayM" из потока "Load" в переменную "Value" объекта "SaturdayMinutes"
            SundayHours.Value = Load.SunDayH;                       // Загружаем значение "SunDayH" из потока "Load" в переменную "Value" объекта "SundayHours"
            SundayMinutes.Value = Load.SundayM;                     // Загружаем значение "SundayM" из потока "Load" в переменную "Value" объекта "SundayMinutes"
            TodayHours = Load.TodayH;                               // Загружаем значение "TodayH" из потока "Load" в переменную "TodayHours"
            TodayMinutes = Load.TodayM;                             // Загружаем значение "TodayM" из потока "Load" в переменную "TodayMinutes"
            TodaySeconds = Load.TodayS;                             // Загружаем значение "TodayS" из потока "Load" в переменную "TodaySeconds"
            LastProgrammingYear = Load.LastPY;                      // Загружаем значение "LastPY" из потока "Load" в переменную "LastProgrammingYear"
            LastProgrammingMonth = Load.LastPM;                     // Загружаем значение "LastPM" из потока "Load" в переменную "LastProgrammingMonth"
            LastProgrammingDay = Load.LastPD;                       // Загружаем значение "LastPD" из потока "Load" в переменную "LastProgrammingDay"
            OvertimeMode = Load.OvertM;                             // Загружаем значение "OvertM" из потока "Load" в переменную "OvertimeMode"
            TodayProgTimeInSec = Load.TodayPTIS;                    // Загружаем значение "TodayPTIS" из потока "Load" в переменную "TodayProgTimeInSec"

            LoadStream.Close();                                     // Закрываем поток "LoadStream"
        }


        private void FormTimer_Closing(object sender, FormClosingEventArgs e)   // Этот метод вызываеться перед закрытием формы
        {
            SaveIformation();                                                   // Вызываем метод сохранения информации
        }
    }
}
