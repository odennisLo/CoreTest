using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CalendarModel
    {
        public long SerID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Content { get; set; }
        
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IP { get; set; }

    }
}
