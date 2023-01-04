using HR.LeaveManagement.Application.Contracts.Persistence;
using ValidationException = HR.LeaveManagement.Application.Exceptions.ValidationException;

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
                response = new BaseCommandResponse{
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);

                leaveType = await _leaveTypeRepository.Add(leaveType);

                response = new BaseCommandResponse
                {
                    Success = true,
                    Message = "Creation Successful",
                    Id = leaveType.Id
                };
            }            

            return response;
        }
    }
}
