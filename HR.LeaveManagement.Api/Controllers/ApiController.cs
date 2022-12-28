using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator
        {
            get { return this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>(); }
        }
    }
}
