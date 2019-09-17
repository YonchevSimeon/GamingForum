namespace GamingForum.Web.Controllers
{
    using Infrastructure;
    using Services.Contracts;
    using Services.InputModels.Reply;
    using Services.ViewModels.Reply;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Enums;
    using System.Threading.Tasks;
    using System.Net;
    using Microsoft.AspNetCore.Authorization;

    [AutorizeRoles(nameof(Role.Administrator), nameof(Role.User))]
    public class ReplyController : BaseController
    {
        private readonly IReplyService replyService;
        private readonly IPostService postService;

        public ReplyController(IAccountService accountService, IReplyService replyService, IPostService postService) 
            : base(accountService)
        {
            this.replyService = replyService;
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Make(string id)
        {
            if (!this.User.Identity.IsAuthenticated) return this.Redirect("/Account/Login");
            
            Post post = await this.postService.GetByIdAsync(id, this.ModelState);

            if (this.ModelState.IsValid)
            {
                ReplyInputModel model = this.replyService.GetReplyInputForm(post);

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
        public async Task<IActionResult> Make(ReplyInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                GamingForumUser replier = await this.accountService.GetLoggedInUserAsync(this.User);

                await this.replyService.MakeAsync(model, replier);

                return this.Redirect($"/Post/Details/{model.PostId}");
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
            ReplyDetailsViewModel reply = await this.replyService.ByIdAsync(id);

            return this.View(reply);
        }
    }
}
