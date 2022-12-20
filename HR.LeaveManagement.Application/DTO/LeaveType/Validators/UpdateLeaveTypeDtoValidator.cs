namespace HR.LeaveManagement.Application.DTO.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(leaveType => leaveType.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}