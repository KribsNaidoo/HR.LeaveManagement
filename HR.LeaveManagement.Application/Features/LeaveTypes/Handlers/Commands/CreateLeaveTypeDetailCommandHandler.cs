namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeDetailCommandHandler : IRequestHandler<CreateLeaveTypeDetailCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeDetailCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Allocations Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Allocations Successful";
            response.Id = leaveType.Id;

            return response;
        }
    }
}
