using System;
using System.Collections.Generic;
using System.Timers;

namespace AlarmClock
{
    public delegate void AlarmClockEventHandler(object sender, AlarmClockArgs e);
    public class AlarmClockArgs : EventArgs
    {
        int time;
        public int Time
        {
            get => time;
        }
        public AlarmClockArgs(int time)
        {
            this.time = time;
        }
    }

    public class AlarmClock : IDisposable
    {
        int time;
        System.Timers.Timer timer;
        public event AlarmClockEventHandler Tick;
        public event AlarmClockEventHandler Alarm;
        List<int> alarmTimeList;

        public AlarmClock(List<int> alarmTimeList)
        {
            time = 0;
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TimerElapsed;
            this.alarmTimeList = alarmTimeList;
        }
        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            time++;
            AlarmClockArgs args = new AlarmClockArgs(time);
            Tick?.Invoke(this, args);
            if (alarmTimeList.Contains(time))
            {
                Alarm?.Invoke(this, args);
            }
        }
        public void Start()
        {
            timer.Start();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入闹钟响铃的次数：");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
            {
                Console.WriteLine("输入无效，请输入一个正整数：");
            }
            
            List<int> alarmTimeList = new List<int>();
            Console.WriteLine("请依次输入响铃时间（整数）：");
            for (int i = 0; i < count; i++)
            {
                int alarmTime;
                while (!int.TryParse(Console.ReadLine(), out alarmTime) || alarmTime < 0)
                {
                    Console.WriteLine("输入无效，请输入一个正整数：");
                }
                alarmTimeList.Add(alarmTime);
            }

            using (AlarmClock alarm = new AlarmClock(alarmTimeList))
            {
                alarm.Tick += AlarmTick;
                alarm.Alarm += AlarmAlarm;
                alarm.Start();
                Console.WriteLine("按任意键退出...");
                Console.ReadKey();
            }
        }

        private static void AlarmTick(object sender, AlarmClockArgs e)
        {
            Console.WriteLine($"Tick. 时间:{e.Time}");
        }
        private static void AlarmAlarm(object sender, AlarmClockArgs e)
        {
            Console.WriteLine($"Alarm! 时间:{e.Time}");
        }
    }
}
