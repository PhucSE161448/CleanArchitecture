using MediatR;

namespace CleanArchitecture.Application.Features.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
