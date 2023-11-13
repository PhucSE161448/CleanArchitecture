using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(CADBContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public Task<bool> AllocationExist(string userId, int leaveId, int period)
        {
            return _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId 
            && x.LeaveTypeId == leaveId
            && x.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails()
        {
            var allocation = await _context.LeaveAllocations.Include(x => x.LeaveType).ToListAsync();
            return allocation;
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails(string userId)
        {
            var list = await _context.LeaveAllocations.Where(x => x.EmployeeId.Equals(userId))
                .Include(x => x.LeaveType)
                .ToListAsync();
            return list;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leave = await _context.LeaveAllocations.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.LeaveTypeId == id);
            return leave;
        }

        public async Task<LeaveAllocation> GetUserAllocationById(string userId, int id)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == id);
        }
    }
}
