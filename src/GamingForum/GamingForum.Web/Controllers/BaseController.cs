namespace GamingForum.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController : Controller
    {
        protected readonly IAccountService accountService;

        public BaseController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
    }
}
