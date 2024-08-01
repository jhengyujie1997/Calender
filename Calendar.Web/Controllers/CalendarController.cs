using AutoMapper;
using Calendar.Service.Implements;
using Calendar.Service.Dtos;
using Calendar.Service.Interfaces;
using Calendar.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Calendar.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendarService _calendarService;
        private readonly IMapper _mapper;

        public CalendarController(ILogger<CalendarController> logger, ICalendarService calendarService, IMapper mapper)
        {
            _logger = logger;
            _calendarService = calendarService;
            _mapper = mapper;
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

        /// <summary>
        /// Get Calendar List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CalendarViewModel>> GetListAsync()
        {
            var calendarDto = await this._calendarService.GetListAsync();

            // Convert FooDto to FooViewModel
            var calendarViewModels = this._mapper.Map<IEnumerable<CalendarViewModel>>(calendarDto);

            return calendarViewModels;
        }

        /// <summary>
        /// 取得 Calendar
        /// </summary>
        /// <param name="model">查詢參數</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CalendarViewModel> GetAsync([FromQuery] QueryCalendarModel model)
        {
            // Convert QueryCalendarModel to QueryCalendarDto
            var QueryCalendarDto = this._mapper.Map<QueryCalendarDto>(model);

            var calenderDto = await this._calendarService.GetAsync(QueryCalendarDto);

            // Convert calenderDto to calendarViewModel
            var calendarViewModel = this._mapper.Map<CalendarViewModel>(calenderDto);

            return calendarViewModel;
        }

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="model">Calendar</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> AddAsync([FromBody] CalendarViewModel model)
        {
            // Convert CalendarViewModel to CalendarDto
            var calendarDto = this._mapper.Map<CalendarDto>(model);

            var status = await this._calendarService.AddAsync(calendarDto);

            return status;
        }

        /// <summary>
        /// 刪除 Calendar
        /// </summary>
        /// <param name="groupId">groupId Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/{groupId}")]
        public async Task<bool> RemoveAsync(int groupId)
        {
            var status = await this._calendarService.RemoveAsync(groupId);

            return status;
        }

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="model">Calendar</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<bool> UpdateAsync([FromBody] CalendarViewModel model)
        {
            // Convert BlogParameter to BlogQueryDto
            var calendarDto = this._mapper.Map<CalendarDto>(model);

            var status = await this._calendarService.UpdateAsync(calendarDto);

            return status;
        }
    }
}
