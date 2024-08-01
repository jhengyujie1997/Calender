using AutoMapper;
using Calendar.Repository.Enities;
using Calendar.Service.Dtos;

namespace Calendar.Service.Infrastructure
{
    /// <summary>
    /// Class ServiceProfile.
    /// Implements the <see cref="Profile" />
    /// </summary>
    /// <seealso cref="Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            CreateMap<QueryFooDto, QueryFoo>();
            CreateMap<Foo, FooDto>();
        }
    }
}