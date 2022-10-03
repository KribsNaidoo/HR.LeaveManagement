namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<LeaveAllocation> GetLeaveTypeWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveTypeWithDetails();
    }
}
