using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
           //Validate incoming data
           
           //Convert to domain entity type object
           var leaveTypeToUpdate = _mapper.Map<LeaveType>(request);
           //Update To Database
           await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
           //Return record id
           return Unit.Value;
        }

       
    }
}
