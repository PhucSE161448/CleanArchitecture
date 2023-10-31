using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand,Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler( ILeaveTypeRepository leaveTypeRepository)
            => _leaveTypeRepository = leaveTypeRepository;
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
           //Retrieve domain entity type object
           var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
           //Check if exist
           if (leaveTypeToDelete == null)
           {
               throw new NotFoundException(nameof(LeaveType), request.Id);
           }
           //Delete To Database
           await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
           //Return record id
           return Unit.Value;
        }

       
    }
}
