using System;
using System.Collections.Generic;
using System.Text;

namespace Events_in_C_
{
    class Program
    {
        static void Main()
        {
            var counter = new Counter(5);

            counter.ThresholdReached += (sender, e) =>
            {
                Console.WriteLine("Threshold reached!");
            };

            counter.Add(3);
            counter.Add(2); // This should trigger the event

        }
    }
}
