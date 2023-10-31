using MediatR;

namespace CleanArchitecture.Application.Features.Queries.GetAllLeaveTypes
{
    /*public class GetLeaveTypesQuery : IRequest <List<LeaveTypeDto>>
    {

    }*/
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypesDto>>;
}
