namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeDetailCommandHandler : IRequestHandler<CreateLeaveTypeDetailCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeDetailCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new ILeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeDto);

            if (validationResult.IsValid == false)
                throw new Exception();

            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            return leaveType.Id;
        }
    }
}
