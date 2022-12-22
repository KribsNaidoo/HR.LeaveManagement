using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTO.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));

            RuleFor(leaveAllocation => leaveAllocation.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
