using MediatR;

namespace CleanArchitecture.Application.Features.Queries.GetLeaveTypeDetail
{
    /*public class GetLeaveTypesQuery : IRequest <List<LeaveTypeDto>>
    {

    }*/
    public record GetLeaveTypeDetailsQuery(int Id) : IRequest<List<LeaveTypeDetailsDto>>, IRequest<LeaveTypeDetailsDto>;
}
