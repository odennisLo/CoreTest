using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Models;
using Core.DAL;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActionContextAccessor _accessor;
        private readonly ConnectionString _context;

        public HomeController(ILogger<HomeController> logger,IActionContextAccessor accessor, ConnectionString connectionString)
        {
            _logger = logger;
            _accessor = accessor;
            _context = connectionString;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CalendarModel calendarModel)
        {            
            calendarModel.IP= _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            calendarModel.InsertDate = DateTime.Now;
            calendarModel.UpdateDate = DateTime.Now;
            var dal = new DataDal(_context);
            var data =await dal.Insert(calendarModel);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Date()
        {                        
            var dal = new DataDal(_context);

            var getCalendar =await dal.GerCalendarList();

            var List = from t in getCalendar.Data
                       select new
                       {
                           id = t.SerID,
                           start = t.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                           end=t.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                           title = t.Title,
                           color = "lightBlue",                          
                       };
            var rows = List.ToArray();
            return Ok(rows);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
