using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly ILocalStorageService _localStorageService;

        public LeaveTypeService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            _mapper = mapper;
            _httpclient = httpclient;
            _localStorageService = localStorageService;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                AddBearerToken();

                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveType);

                if(apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public Task<Response<int>> DeleteLeaveType(int id) => throw new NotImplementedException();
        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id) => throw new NotImplementedException();
        public Task<List<LeaveTypeVM>> GetLeaveTypes() => throw new NotImplementedException();
        public Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType) => throw new NotImplementedException();
    }
}
