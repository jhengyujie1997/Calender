using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Calendar.Repository.Enities;

namespace Calendar.Repository.Interfaces
{
    /// <summary>
    /// Interface ICalendarRepository
    /// </summary>
    public interface ICalendarRepository
    {
        /// <summary>
        /// 取得 Calendar List
        /// <param></param>
        /// </summary>
        Task<IEnumerable<Enities.Calendar>> GetListAsync();

        /// <summary>
        /// 取得 Calendar
        /// <param></param>
        /// </summary>
        Task<Enities.Calendar> GetAsync(QueryCalendar queryCalendar);

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        Task<bool> AddAsync(Enities.Calendar calendar);

        /// <summary>
        /// 刪除 Calendar
        /// </summary>
        /// <param name="groupId">groupId</param>
        Task<bool> RemoveAsync(int groupId);

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="calendar">實體</param>
        Task<bool> UpdateAsync(Enities.Calendar calendar);
    }
}