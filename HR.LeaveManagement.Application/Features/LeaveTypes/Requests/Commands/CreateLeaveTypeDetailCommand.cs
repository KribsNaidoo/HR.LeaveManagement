namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeDetailCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}
