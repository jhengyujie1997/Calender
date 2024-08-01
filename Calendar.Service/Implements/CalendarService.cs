using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Calendar.Repository.Enities;
using Calendar.Repository.Interfaces;
using Calendar.Service.Dtos;
using Calendar.Service.Interfaces;

namespace Calendar.Service.Implements
{
    /// <summary>
    ///
    /// </summary>
    public class CalendarService : ICalendarService
    {
        private ICalendarRepository _CalendarRepository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarService"/> class.
        /// </summary>
        public CalendarService(ICalendarRepository CalendarRepository, IMapper mapper)
        {
            _CalendarRepository = CalendarRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 取得 Calendar List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<IEnumerable<CalendarDto>> GetListAsync()
        {
            var Calendar = await _CalendarRepository.GetListAsync();

            // Convert Calendar to CalendarDto
            var CalendarDtos = _mapper.Map<IEnumerable<CalendarDto>>(Calendar);

            return CalendarDtos;
        }

        /// <summary>
        /// 取得 Calendar
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<CalendarDto> GetAsync(QueryCalendarDto queryCalendarDto)
        {
            // Convert QueryCalendarDto to QueryCalendar
            var queryCalendar = this._mapper.Map<QueryCalendar>(queryCalendarDto);

            var Calendar = await _CalendarRepository.GetAsync(queryCalendar);

            // Convert Calendar to CalendarDto
            var CalendarDtos = _mapper.Map<CalendarDto>(Calendar);

            return CalendarDtos;
        }

        /// <summary>
        /// 新增 Calendar
        /// </summary>
        /// <param name="calendarDto">Calendar Dto</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(CalendarDto calendarDto)
        {
            // Convert CalendarDto to Calendar
            var calendar = this._mapper.Map<Repository.Enities.Calendar>(calendarDto);

            return await this._CalendarRepository.AddAsync(calendar);
        }

        /// <summary>
        /// 刪除 Calendar
        /// </summary>
        /// <param name="groupId">groupId</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int groupId)
        {
            return await this._CalendarRepository.RemoveAsync(groupId);
        }

        /// <summary>
        /// 更新 Calendar
        /// </summary>
        /// <param name="calendarDto">Calendar Dto</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(CalendarDto calendarDto)
        {
            // Convert CalendarDto to Calendar
            var calendar = this._mapper.Map<Repository.Enities.Calendar>(calendarDto);

            return await this._CalendarRepository.UpdateAsync(calendar);
        }
    }
}