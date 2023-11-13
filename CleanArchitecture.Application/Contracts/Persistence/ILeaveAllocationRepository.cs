using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails();
        Task<List<LeaveAllocation>> GetAllLeaveAllocationWithDetails(string userId);
        Task<bool> AllocationExist(string userId, int leaveId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
        Task<LeaveAllocation> GetUserAllocationById(string userId,int id);
    }
}
