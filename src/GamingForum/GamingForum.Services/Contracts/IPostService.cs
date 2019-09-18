namespace GamingForum.Services.Contracts
{
    using InputModels.Post;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Post;

    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> AllAsync();

        PostInputModel GetPostInputForm(Category category);

        Task CreateAsync(PostInputModel model, GamingForumUser poster);

        Task<PostDetailsViewModel> ByIdAsync(string id);

        Task<Post> GetByIdAsync(string id, ModelStateDictionary modelState);

        Task<IEnumerable<PostViewModel>> GetLatestAsync();

        //Task<IEnumerable<PostViewModel>> AllByAlbumIdAsync(string id);
    }
}
