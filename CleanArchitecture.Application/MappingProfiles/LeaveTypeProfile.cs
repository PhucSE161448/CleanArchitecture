using AutoMapper;
using CleanArchitecture.Application.Features.Queries.GetAllLeaveTypes;
using CleanArchitecture.Application.Features.Queries.GetLeaveTypeDetail;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypesDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
