using ValidationException = HR.LeaveManagement.Application.Exceptions.ValidationException;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.leaveRequestDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
                var validationResult = await validator.ValidateAsync(request.leaveRequestDto);

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                _mapper.Map(request.leaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if(request.leaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.leaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
