using System;
using System.Collections.Generic;
using System.Text;

namespace Events_in_C_
{
  
        public class ThresholdReachedEventArgs : EventArgs
        {
            public int Threshold { get; set; }
            public DateTime TimeReached { get; set; }
        }
    
}
