using Calendar.Application.Model;
using Calendar.Common.Dtos;
using Calendar.Common.Interfaces;

namespace Calendar.Application.Implements;

public class CalendarUseCase (ICalendarInterface calendarInterface)
{
    /// <summary>
    /// 取得 Calendar List
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public async Task<IQueryable<CalendarDto>> GetListAsync()
    {
        var calendar = await calendarInterface.GetListAsync();       
        return calendar;
    }

    /// <summary>
    /// 取得 Calendar
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    public async Task<CalendarDto> GetAsync(int groupId)
    {
        var calendar = await calendarInterface.GetAsync(groupId);
        return calendar;
    }

    /// <summary>
    /// 新增 Calendar
    /// </summary>
    /// <param name="calendarInput">Calendar Dto</param>
    /// <returns></returns>
    public async Task<bool> AddAsync(CalendarInput calendarInput)
    {
        var calendarDto = new CalendarDto {
            groupId = calendarInput.groupId,
            title = calendarInput.title,
            start = calendarInput.start,
            end = calendarInput.end,
            color = calendarInput.color,
            textColor = calendarInput.textColor,
        };
        return await calendarInterface.AddAsync(calendarDto);
    }

    /// <summary>
    /// 刪除 Calendar
    /// </summary>
    /// <param name="groupId">groupId</param>
    /// <returns></returns>
    public async Task<bool> RemoveAsync(int groupId)
    {
        return await calendarInterface.RemoveAsync(groupId);
    }

    /// <summary>
    /// 更新 Calendar
    /// </summary>
    /// <param name="calendarInput">Calendar Dto</param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(CalendarInput calendarInput)
    {
        var calendarDto = new CalendarDto
        {
            groupId = calendarInput.groupId,
            title = calendarInput.title,
            start = calendarInput.start,
            end = calendarInput.end,
            color = calendarInput.color,
            textColor = calendarInput.textColor,
        };
        return await calendarInterface.UpdateAsync(calendarDto);
    }
}