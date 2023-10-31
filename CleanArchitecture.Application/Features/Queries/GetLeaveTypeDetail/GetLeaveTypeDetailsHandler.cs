using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Queries.GetLeaveTypeDetail
{
    public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);
            //check if exist
            if (leaveTypes == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            //Convert data objects to DTO objects
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);
            //return list of DTO object
            return data;
        }
    }
}
