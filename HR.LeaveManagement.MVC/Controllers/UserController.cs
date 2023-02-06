using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var isLoggedIn = await _authenticationService.Authenticate(login.Email, login.Password);

                if (isLoggedIn)
                    return LocalRedirect(returnUrl);
            }            

            ModelState.AddModelError("", "Log in Attempt Failed. Please try again.");
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registration)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authenticationService.Register(registration);

                if (isCreated)
                    return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Registration attempt failed. Please try again");
            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authenticationService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
