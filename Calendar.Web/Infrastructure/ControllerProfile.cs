using AutoMapper;
using Calendar.Service.Dtos;
using Calendar.Web.Models;

namespace Calendar.Web.Infrastructure
{
    /// <summary>
    /// Class ControllerProfile.
    /// Implements the <see cref="AutoMapper.Profile" />
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ControllerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerProfile"/> class.
        /// </summary>
        public ControllerProfile()
        {
            this.CreateMap<QueryFooParameter, QueryFooDto>();
            this.CreateMap<FooDto, FooViewModel>();
        }
    }
}