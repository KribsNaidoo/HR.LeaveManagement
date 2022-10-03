namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto leaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalDto leaveRequestApprovalDto { get; set; }
    }
}
