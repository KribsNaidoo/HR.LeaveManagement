using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTO.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(leaveAllocation => leaveAllocation.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(leaveAllocation => leaveAllocation.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist");

            RuleFor(leaveAllocation => leaveAllocation.Period)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }
    }
}
