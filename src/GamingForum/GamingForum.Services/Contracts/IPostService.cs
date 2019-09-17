namespace GamingForum.Services.Contracts
{
    using InputModels.Post;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Models;
    using System.Threading.Tasks;
    using ViewModels.Post;

    public interface IPostService
    {
        PostInputModel GetPostInputForm(Category category);

        Task CreateAsync(PostInputModel model, GamingForumUser poster);

        Task<PostDetailsViewModel> ByIdAsync(string id);

        Task<Post> GetByIdAsync(string id, ModelStateDictionary modelState);

        //Task<IEnumerable<PostViewModel>> AllByAlbumIdAsync(string id);
    }
}
