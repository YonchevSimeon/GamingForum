namespace GamingForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.ViewModels.Post;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IPostService postService;
        public HomeController(IAccountService accountService, IPostService postService) 
            : base(accountService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PostViewModel> latestPosts = await this.postService.GetLatestAsync();

            return this.View(latestPosts);
        }
    }
}
