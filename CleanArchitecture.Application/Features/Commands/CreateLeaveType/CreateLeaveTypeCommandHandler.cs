using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Leavetype", validationResult);
            }
            //Convert to domain entity type object
            var leaveTypeToCreate = _mapper.Map<LeaveType>(request);
            //Add To Database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            //Return record id
            return leaveTypeToCreate.Id;
        }
    }
}
