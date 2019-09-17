namespace GamingForum.Services.Contracts
{
    using InputModels.Reply;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Models;
    using System.Threading.Tasks;
    using ViewModels.Reply;

    public interface IReplyService
    {
        ReplyInputModel GetReplyInputForm(Post post);

        Task MakeAsync(ReplyInputModel model, GamingForumUser Replier);

        Task<ReplyDetailsViewModel> ByIdAsync(string id);
    }
}
