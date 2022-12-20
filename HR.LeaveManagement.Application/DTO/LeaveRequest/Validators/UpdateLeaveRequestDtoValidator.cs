namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

            RuleFor(leaveRequest => leaveRequest.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
