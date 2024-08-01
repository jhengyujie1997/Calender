using AutoMapper;
using Calendar.Service.Implements;
using Calendar.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        //private readonly IFooService _fooService;
        //private readonly IMapper _mapper;

        public CalendarController(ILogger<CalendarController> logger/*, IFooService fooService, IMapper mapper*/)
        {
            _logger = logger;
            //_fooService = fooService;
            //_mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return PartialView("Create");
        }

        public IActionResult Update()
        {
            return PartialView("Update");
        }
    }
}
