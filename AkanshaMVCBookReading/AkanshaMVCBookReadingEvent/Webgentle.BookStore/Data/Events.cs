using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Data
{
    public class Events : IEvents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string OtherDetails { get; set; }
        public DateTime Date { get; set; }
        public string startTime { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public string eventType { get; set; }

        public string invitedTo { get; set; }

        public string CreatedBy { get; set;}

    }
}
