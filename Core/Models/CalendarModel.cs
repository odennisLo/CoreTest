using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CalendarModel
    {
        public long SerID { get; set; }

        public DateTime CalendarDate { get; set; }

        public string ContentText { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string IP { get; set; }

    }
}
