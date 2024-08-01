using System.Collections.Generic;
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
    public class FooService : IFooService
    {
        private IFooRepository _fooRepository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FooService"/> class.
        /// </summary>
        public FooService(
            IFooRepository fooRepository,
            IMapper mapper)
        {
            _fooRepository = fooRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 取得 Foo
        /// </summary>
        /// <param name="dto">查詢條件</param>
        /// <returns></returns>
        public async Task<IEnumerable<FooDto>> GetAsync(QueryFooDto dto)
        {
            // Convert QueryFooDto to QueyFoo
            var queryFoo = _mapper.Map<QueryFoo>(dto);

            var foo = await _fooRepository.GetAsync(queryFoo);

            // Convert Foo to FooDto
            var fooDtos = _mapper.Map<IEnumerable<FooDto>>(foo);

            return fooDtos;
        }
    }
}