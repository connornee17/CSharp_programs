using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();
            int i;
            for (i = 0; i < 10; i++)
            {
                myClock.ReadTime();
                myClock.Tick();
                System.Threading.Thread.Sleep(1000);
            }
            myClock.Reset();
            for (i = 0; i < 10; i++)
            {
                myClock.ReadTime();
                myClock.Tick();
                System.Threading.Thread.Sleep(1000);
            }
        }
        
    }
}