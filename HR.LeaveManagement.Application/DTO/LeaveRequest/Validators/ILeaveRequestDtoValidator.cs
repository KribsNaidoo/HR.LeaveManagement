using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _ILeaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository ILeaveTypeRepository)
        {
            _ILeaveTypeRepository = ILeaveTypeRepository;

            RuleFor(leaveRequest => leaveRequest.StartDate)
                .LessThan(leaveRequest => leaveRequest.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(leaveRequest => leaveRequest.EndDate)
                .GreaterThan(leaveRequest => leaveRequest.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(leaveRequest => leaveRequest.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _ILeaveTypeRepository.Exists(id);
                    return leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
