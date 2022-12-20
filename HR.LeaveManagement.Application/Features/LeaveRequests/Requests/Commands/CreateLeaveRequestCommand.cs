namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto leaveRequestDto { get; set; }
    }
}
