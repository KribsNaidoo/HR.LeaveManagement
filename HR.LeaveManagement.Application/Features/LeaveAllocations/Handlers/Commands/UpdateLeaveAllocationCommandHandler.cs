using HR.LeaveManagement.Application.Contracts.Persistence;
using ValidationException = HR.LeaveManagement.Application.Exceptions.ValidationException;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _leaveAllocationRepository.Get(request.leaveAllocationDto.Id);

            _mapper.Map(request.leaveAllocationDto, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
