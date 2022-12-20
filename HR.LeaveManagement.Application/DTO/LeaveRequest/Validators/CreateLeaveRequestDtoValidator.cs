namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveRequestDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveRequestDtoValidator(_leaveAllocationRepository));
        }
    }
}
