namespace HR.LeaveManagement.Application.DTO.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(leaveType => leaveType.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(leaveType => leaveType.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }
    }
}
