namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto leaveAllocationDto { get; set; }
    }
}
