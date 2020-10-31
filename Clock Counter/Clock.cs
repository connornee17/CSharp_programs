using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTest
{
    public class Clock
    {
        private Counter _sec;
        private Counter _min;
        private Counter _hour;


        public Counter Hours
        {
            get { return _hour; }
            set { _hour = value; }
        }
        public Counter Minutes
        {
            get { return _min; }
            set { _min = value; }
        }
        public Counter Seconds
        {
            get { return _sec; }
            set { _sec = value; }
        }

        public Clock ()
        {
            Hours = new Counter("Hours");
            Minutes = new Counter("Minutes");
            Seconds = new Counter("Seconds");
        }

        public void Reset ()
        {
            Hours.Reset();
            Minutes.Reset();
            Seconds.Reset();
        }

        public void ReadTime ()
        {
            Console.WriteLine("{0:00}:{1:00}:{2:00}", Hours.Value, Minutes.Value, Seconds.Value);
        }

        public void Tick ()
        {
            Seconds.Increment();
            if (Seconds.Value == 60)
            {
                Seconds.Reset();
                Minutes.Increment();
                if (Minutes.Value == 60)
                {
                    Minutes.Reset();
                    Hours.Increment();
                    if (Hours.Value == 24)
                    {
                        Hours.Reset();
                    }
                }
            }
        }


    }
}
