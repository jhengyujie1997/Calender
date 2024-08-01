using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Repository.Enities;
using Calendar.Repository.Interfaces;

namespace Calendar.Repository.Implements
{
    /// <summary>
    /// Class FooRepository.
    /// Implements the <see cref="IFooRepository" />
    /// </summary>
    /// <seealso cref="IFooRepository" />
    public class FooRepository : IFooRepository
    {
        /// <summary>
        /// 取得 Foo
        /// </summary>
        /// <param name="dto">查詢條件</param>
        /// <returns></returns>
        public async Task<IEnumerable<Foo>> GetAsync(QueryFoo dto)
        {
            // 資料庫實作

            return null;
        }
    }
}