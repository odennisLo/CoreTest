using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Core.BLL;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActionContextAccessor _accessor;
        private readonly DateService _dataService;
        public HomeController(IActionContextAccessor accessor, DateService dataServices)
        {
            _accessor = accessor;
            _dataService = dataServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CalendarModel calendarModel)
        {
            calendarModel.IP = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            calendarModel.InsertDate = DateTime.Now;
            calendarModel.UpdateDate = DateTime.Now;
            var data = await _dataService.Insert(calendarModel).ConfigureAwait(false);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Date()
        {
            var getCalendar = await _dataService.GerCalendarList();
            var List = from t in getCalendar.Data
                       select new
                       {
                           id = t.SerID,
                           start = t.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                           end = t.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                           title = t.Title,
                           color = "lightBlue",
                       };
            var rows = List.ToArray();
            return Ok(rows);
        }
        [HttpPatch]
        public async Task<IActionResult> Edit(CalendarModel calendarModel)
        {
            calendarModel.IP = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            var data = await _dataService.Update(calendarModel);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var data = await _dataService.Delete(id);
            return Ok(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
