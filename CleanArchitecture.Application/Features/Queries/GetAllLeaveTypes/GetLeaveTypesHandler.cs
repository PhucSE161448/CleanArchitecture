using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypesDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypesHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypesDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            //Convert data objects to DTO objects
            var data = _mapper.Map<List<LeaveTypesDto>>(leaveTypes);
            //return list of DTO object
            return data;
        }
    }
}
