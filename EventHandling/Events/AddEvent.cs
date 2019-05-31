using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling.Events
{
    public class AddEvent : EventBase
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }
    }
}
