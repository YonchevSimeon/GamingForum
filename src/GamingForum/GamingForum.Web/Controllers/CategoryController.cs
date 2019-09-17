namespace GamingForum.Web.Controllers
{
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Enums;
    using Services.Contracts;
    using Services.InputModels.Category;
    using Services.ViewModels.Category;
    using System.Net;
    using System.Threading.Tasks;

    [AutorizeRoles(nameof(Role.Administrator), nameof(Role.User))]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(IAccountService accountService, ICategoryService categoryService) 
            : base(accountService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var categories = await this.categoryService.AllAsync();

            return this.View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this.User.Identity.IsAuthenticated) return this.Redirect("/Account/Login");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                GamingForumUser creator = await this.accountService.GetLoggedInUserAsync(this.User);

                await this.categoryService.CreateAsync(model, creator);

                return this.RedirectToAction(nameof(All));
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
        public async Task<IActionResult> Details(string id)
        {
            CategoryDetailsViewModel category = await this.categoryService.ByIdAsync(id);
           
            return this.View(category);
        }
    }
}
