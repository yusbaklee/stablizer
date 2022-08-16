using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    internal class VoltageRate  //publisher
    {

        public delegate void NotifyHandler();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public event NotifyHandler NotifyOtherClasses;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void HighVoltage()
        {
        }



        protected virtual void OnHighVoltage()
        {
            NotifyOtherClasses?.Invoke();  //raise event
        }
    }

    public class RegulatorRate   //subscriber
    {
        public void ActOnHighVoltage()
        {
            var newRate = new VoltageRate();

            newRate.NotifyOtherClasses += () => Console.WriteLine("Switch To Stabilizer");

            newRate.HighVoltage();
        }



        public void HighVoltage()
        {
            Console.WriteLine("Sleep Device");
            Console.ReadLine();
        }
    }
}