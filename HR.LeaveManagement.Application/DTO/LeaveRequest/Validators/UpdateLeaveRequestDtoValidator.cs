namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveRequestDtoValidator(_leaveAllocationRepository));

            RuleFor(leaveRequest => leaveRequest.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
