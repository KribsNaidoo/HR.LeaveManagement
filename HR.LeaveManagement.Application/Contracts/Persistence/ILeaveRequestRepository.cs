namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
        Task<LeaveRequest> GetLeaveRequestsWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    }
}
