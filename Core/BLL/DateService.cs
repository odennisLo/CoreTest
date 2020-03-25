using Core.DAL;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.BLL
{
    public class DateService// : IDataServices
    {
        private readonly DataRepository _dataRepo;

        public DateService(DataRepository dataRepository)
        {
            _dataRepo = dataRepository;
        }

        public async Task<ApiData<CalendarModel>> Insert(CalendarModel calendarModel)
        {
            var data = await _dataRepo.Insert(calendarModel).ConfigureAwait(false);
            return data;
        }
        public async Task<ApiData<CalendarModel>> Update(CalendarModel calendarModel)
        {
            var data = await _dataRepo.Update(calendarModel).ConfigureAwait(false);
            return data;
        }
        public async Task<ApiData<CalendarModel>> GerCalendarList()
        {
            var data = await _dataRepo.GerCalendarList().ConfigureAwait(false);
            return data;
        }
        public async Task<ApiData<CalendarModel>> Delete(long id)
        {
            var data = await _dataRepo.Delete(id).ConfigureAwait(false);
            return data;
        }
    }
}
