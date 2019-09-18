namespace GamingForum.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Net;
    using System.Threading.Tasks;
    using Services.InputModels.Account;
    using Services.ViewModels.Account;

    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IAccountService accountService) 
            : base(accountService)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) this.Redirect("/");

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if(this.ModelState.IsValid)
            {
                await this.accountService.LogInAsync(model);

                return this.Redirect("/");
            }
            else
            {
                ViewResult result = this.View("Error", this.ModelState);
                result.StatusCode = (int)HttpStatusCode.BadRequest;

                return result;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated) this.Redirect("/");

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            if(this.ModelState.IsValid)
            {
                await this.accountService.RegisterAsync(model);

                return this.Redirect("/");
            }
            else
            {
                
                ViewResult result = this.View("Error", this.ModelState);
                
                result.StatusCode = (int)HttpStatusCode.BadRequest;

                return result;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(string id)
        {
            AccountViewModel account = await this.accountService.GetProfileByIdAsync(id);

            return this.View(account);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this.accountService.LogOutAsync();

            return this.Redirect("/");
        }
    }
}
