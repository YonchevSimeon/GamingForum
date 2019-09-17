namespace GamingForum.Services.ViewModels.Post
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string Title { get; set; }
    }
}
