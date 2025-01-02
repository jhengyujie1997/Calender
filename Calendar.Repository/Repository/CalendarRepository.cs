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
            var calendarDto = context.Calendar
                .Select(x => new CalendarDto
                {
                    groupId = x.groupId,
                    title = x.title,
                    start = x.start,
                    end = x.end,
                    color = x.color,
                    textColor = x.textColor,
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
            var calendarDto = await (from cal in context.Calendar
                                     where cal.groupId == groupId
                                     select new CalendarDto
                                     {
                                         groupId = cal.groupId,
                                         title = cal.title,
                                         start = cal.start,
                                         end = cal.end,
                                         color = cal.color,
                                         textColor = cal.textColor,
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
                groupId = calendar.groupId,
                title = calendar.title,
                start = calendar.start,
                end = calendar.end,
                color = calendar.color,
                textColor = calendar.textColor,
            };
            context.Calendar.Add(calendarEntities);
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
            var calendar = await context.Calendar.FindAsync(groupId);
            context.Calendar.Remove(calendar);
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
            var existingCalendar = await context.Calendar
                .FirstOrDefaultAsync(c => c.groupId == calendar.groupId);

            if (existingCalendar == null)
            {
                return false;
            }

            existingCalendar.title = calendar.title;
            existingCalendar.start = calendar.start;
            existingCalendar.end = calendar.end;
            existingCalendar.color = calendar.color;
            existingCalendar.textColor = calendar.textColor;

            context.Calendar.Update(existingCalendar);
            var count = await context.SaveChangesAsync();
            return count > 0;
        }
    }
}