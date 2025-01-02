using Calendar.Application.Implements;
using Calendar.Application.Model;
using Calendar.Common.Dtos;
using Calendar.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Calendar.Web.Controllers
{
    public class CalendarController(ILogger<CalendarController> logger, CalendarUseCase calendarUseCase) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public async Task<IActionResult> Update(int groupId)
        {
            // Convert QueryCalendarModel to QueryCalendarDto
            var calenderDto = await calendarUseCase.GetAsync(groupId);
            var calendarViewModel = new CalendarViewModel {
                groupId = calenderDto.groupId,
                title = calenderDto.title,
                start = calenderDto.start,
                end = calenderDto.end,
                color = calenderDto.color,
                textColor = calenderDto.textColor,
            };
            return View("Update", calendarViewModel);
        }

        /// <summary>
        /// Get Calendar List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            var calendarDto = (await calendarUseCase.GetListAsync()).ToList();
            return Ok(calendarDto);
        }

        /// <summary>
        /// 取得 Calendar
        /// </summary>
        /// <param name="groupId">查詢參數</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int groupId)
        {
            var calenderDto = await calendarUseCase.GetAsync(groupId);
            return View("Update", calenderDto);
        }

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="model">Calendar</param>
        /// <returns></returns>
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] CalendarViewModel model)
        {
            var calendarInput = new CalendarInput
            {
                groupId = model.groupId,
                title = model.title,
                start = model.start,
                end = model.end,
                color = model.color,
                textColor = model.textColor,
            };
            var status = await calendarUseCase.AddAsync(calendarInput);
            return View("Index");
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
            var status = await calendarUseCase.RemoveAsync(groupId);
            return status;
        }

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="model">Calendar</param>
        /// <returns></returns>
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CalendarViewModel model)
        {
            var calendarInput = new CalendarInput
            {
                groupId = model.groupId,
                title = model.title,
                start = model.start,
                end = model.end,
                color = model.color,
                textColor = model.textColor,
            };
            var status = await calendarUseCase.UpdateAsync(calendarInput);
            return Ok(status);
        }
    }
}
