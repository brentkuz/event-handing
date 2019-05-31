using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling.Events
{
    public class EventBase
    {
        public EventBase()
        {
            Id = Guid.NewGuid();
            TransactionDate = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime TransactionDate { get; private set; }
    }
}
