using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Service.Dtos;

namespace Calendar.Service.Interfaces
{
    /// <summary>
    ///  FooService 介面
    /// </summary>
    public interface IFooService
    {
        /// <summary>
        /// 取得 Foo
        /// </summary>
        /// <param name="dto">查詢條件</param>
        /// <returns></returns>
        Task<IEnumerable<FooDto>> GetAsync(QueryFooDto dto);
    }
}