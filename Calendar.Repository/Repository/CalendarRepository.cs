using Calendar.Repository.Enities;
using Calendar.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Calendar.Common.Dtos;
using System.Linq;

namespace Calendar.Repository.Implements
{
    /// <summary>
    /// Class CalendarRepository.
    /// Implements the <see cref="ICalendarInterface" />
    /// </summary>
    /// <seealso cref="ICalendarInterface" />
    public class CalendarRepository(CalendarContext context) : ICalendarInterface
    {
        /// <summary>
        /// 取得 Calendar List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<IQueryable<CalendarDto>> GetListAsync()
        {
            var calendarDto = context.Calendars
                .Select(x => new CalendarDto
                {
                    groupId = x.GroupId,
                    title = x.Title,
                    start = x.Start,
                    end = x.End,
                    color = x.Color,
                    textColor = x.TextColor,
                });
            return calendarDto;
        }

        /// <summary>
        /// 取得 Calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<CalendarDto> GetAsync(int groupId)
        {
            // 資料庫實作
            var calendarDto = await (from cal in context.Calendars
                                     where cal.GroupId == groupId
                                     select new CalendarDto
                                     {
                                         groupId = cal.GroupId,
                                         title = cal.Title,
                                         start = cal.Start,
                                         end = cal.End,
                                         color = cal.Color,
                                         textColor = cal.TextColor,
                                     }).FirstOrDefaultAsync();

            return calendarDto;
        }

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(CalendarDto calendar)
        {
            var calendarEntities = new Enities.Calendar
            {
                GroupId = calendar.groupId,
                Title = calendar.title,
                Start = calendar.start,
                End = calendar.end,
                Color = calendar.color,
                TextColor = calendar.textColor,
            };
            context.Calendars.Add(calendarEntities);
            var count = await context.SaveChangesAsync();

            return count > 0;
        }

        /// <summary>
        /// 刪除 Calendar
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int groupId)
        {
            var calendar = await context.Calendars.FindAsync(groupId);
            context.Calendars.Remove(calendar);
            var count = await context.SaveChangesAsync();

            return count > 0;
        }

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(CalendarDto calendar)
        {
            var existingCalendar = await context.Calendars
                .FirstOrDefaultAsync(c => c.GroupId == calendar.groupId);

            if (existingCalendar == null)
            {
                return false;
            }

            existingCalendar.Title = calendar.title;
            existingCalendar.Start = calendar.start;
            existingCalendar.End = calendar.end;
            existingCalendar.Color = calendar.color;
            existingCalendar.TextColor = calendar.textColor;

            context.Calendars.Update(existingCalendar);
            var count = await context.SaveChangesAsync();
            return count > 0;
        }
    }
}