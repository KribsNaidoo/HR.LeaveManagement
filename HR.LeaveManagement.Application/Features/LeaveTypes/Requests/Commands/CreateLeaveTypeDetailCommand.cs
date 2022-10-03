namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeDetailCommand : IRequest<int>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}
