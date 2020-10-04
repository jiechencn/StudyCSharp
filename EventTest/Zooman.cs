using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public delegate void ZooEvent();
    class Zooman
    {
        public event ZooEvent EatSignal;
        public event ZooEvent SleepSignal;
        public void SendEatSignal()
        {
            EatSignal?.Invoke();
        }
        public void SendSleepSignal()
        {
            SleepSignal?.Invoke();
        }
    }
}
