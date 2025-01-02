using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Common.Dtos;

namespace Calendar.Common.Interfaces;

/// <summary>
///  CalendarService 介面
/// </summary>
public interface ICalendarInterface 
{
    /// <summary>
    /// 取得 Calendar List
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    Task<IQueryable<CalendarDto>> GetListAsync();

    /// <summary>
    /// 取得 Calendar
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    Task<CalendarDto> GetAsync(int groupId);

    /// <summary>
    /// 新增 Calendar
    /// </summary>
    /// <param name="calendarDto">Calendar Dto</param>
    Task<bool> AddAsync(CalendarDto calendarDto);

    /// <summary>
    /// 刪除 Calendar
    /// </summary>
    /// <param name="groupId">groupId</param>
    Task<bool> RemoveAsync(int groupId);

    /// <summary>
    /// 更新 Calendar
    /// </summary>
    /// <param name="calendarDto">Blog Dto</param>
    Task<bool> UpdateAsync(CalendarDto calendarDto);
}
