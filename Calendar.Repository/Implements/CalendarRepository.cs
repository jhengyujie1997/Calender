using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Calendar.Repository.Enities;
using Calendar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Repository.Implements
{
    /// <summary>
    /// Class CalendarRepository.
    /// Implements the <see cref="ICalendarRepository" />
    /// </summary>
    /// <seealso cref="ICalendarRepository" />
    public class CalendarRepository : ICalendarRepository
    {
        /// <summary>
        /// The database
        /// </summary>
        private readonly CalendarContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CalendarRepository(CalendarContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 取得 Calendar List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<IEnumerable<Enities.Calendar>> GetListAsync()
        {
            // 資料庫實作
            var calendars = await _context.Calendar.ToListAsync();
            return calendars;
        }

        /// <summary>
        /// 取得 Calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<Enities.Calendar> GetAsync(QueryCalendar queryCalendar)
        {
            // 資料庫實作
            var calendar = await _context.Calendar.FindAsync(queryCalendar.groupId);
            return calendar;
        }

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(Enities.Calendar calendar)
        {
            _context.Add(calendar);
            var count = await _context.SaveChangesAsync();

            return count > 0;
        }

        /// <summary>
        /// 刪除 Calendar
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int groupId)
        {
            var calendar = await _context.Calendar.FindAsync(groupId);
            _context.Calendar.Remove(calendar);
            var count = await _context.SaveChangesAsync();

            return count > 0;
        }

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Enities.Calendar calendar)
        {
            _context.Update(calendar);
            var count = await _context.SaveChangesAsync();

            return count > 0;
        }
    }
}