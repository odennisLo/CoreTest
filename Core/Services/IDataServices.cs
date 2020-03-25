using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDataServices
    {
        Task<ApiData<CalendarModel>> Insert(CalendarModel calendarModel);
    }
}
