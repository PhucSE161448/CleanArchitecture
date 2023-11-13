using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(CADBContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetails()
        {
            var leave = await _context.LeaveRequests.Include(p => p.LeaveType)
                .ToListAsync();
            return leave;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
           var request = await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == userId)
                .Include(p => p.LeaveType)
                .ToListAsync();
            return request;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return leaveRequest;
        }
    }
}
