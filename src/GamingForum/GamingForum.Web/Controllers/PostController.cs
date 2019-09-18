namespace GamingForum.Web.Controllers
{
    using Infrastructure;
    using Services.Contracts;
    using Services.InputModels.Post;
    using Services.ViewModels.Post;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Enums;
    using System.Threading.Tasks;
    using System.Net;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;

    [AutorizeRoles(nameof(Role.Administrator), nameof(Role.User))]
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IAccountService accountService, IPostService postService, ICategoryService categoryService) 
            : base(accountService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<PostViewModel> posts = await this.postService.AllAsync();

            return this.View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            if (!this.User.Identity.IsAuthenticated) return this.Redirect("/Account/Login");
           
            Category category = await this.categoryService.GetByIdAsync(id, this.ModelState);
            
            if (this.ModelState.IsValid)
            {
                PostInputModel model = this.postService.GetPostInputForm(category);
                
                return this.View(model);
            }
            else
            {
                ViewResult result = this.View("Error", this.ModelState);
                result.StatusCode = (int)HttpStatusCode.BadRequest;

                return result;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                GamingForumUser poster = await this.accountService.GetLoggedInUserAsync(this.User);
                
                await this.postService.CreateAsync(model, poster);
                
                return this.Redirect($"/Category/Details/{model.CategoryId}");
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
            PostDetailsViewModel post = await this.postService.ByIdAsync(id);

            return this.View(post);
        }
    }
}
