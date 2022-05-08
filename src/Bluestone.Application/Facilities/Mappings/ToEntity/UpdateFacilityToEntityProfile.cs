using AutoMapper;
using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;

namespace Bluestone.Application.Facilities.Mappings.ToEntity
{
    public class UpdateFacilityToEntityProfile : Profile
    {
        public UpdateFacilityToEntityProfile()
        {
            CreateMap<GetFacilityDetailsByIdViewModel, UpdateFacilityRequestModel>()
                .ForMember(d => d.FacilityId, opt => opt.MapFrom(opt => opt.FacilityId))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(opt => opt.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(opt => opt.LastName))
                .ForMember(d => d.City, opt => opt.MapFrom(opt => opt.City))
                .ForMember(d => d.Address, opt => opt.MapFrom(opt => opt.Address));
        }
    }
}
