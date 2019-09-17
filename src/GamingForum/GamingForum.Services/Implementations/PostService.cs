namespace GamingForum.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using GamingForum.Data;
    using GamingForum.Models;
    using GamingForum.Services.InputModels.Post;
    using GamingForum.Services.ViewModels.Post;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static InputModels.Constants.ErrorMessages;

    public class PostService : BaseService, IPostService
    {
        private readonly IConfigurationProvider configurationProvider;

        public PostService(IMapper mapper, GamingForumDbContext context, IConfigurationProvider configurationProvider) 
            : base(mapper, context)
        {
            this.configurationProvider = configurationProvider;
        }

        public PostInputModel GetPostInputForm(Category category)
        {
            PostInputModel model = new PostInputModel()
            {
                CategoryId = category.Id,
                Category = category
            };

            return model;
        }

        public async Task CreateAsync(PostInputModel model, GamingForumUser poster)
        {
            Post post = this.mapper.Map<PostInputModel, Post>(model);

            post.Poster = poster;
            post.PostedOn = DateTime.UtcNow;

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();
        }

        public async Task<PostDetailsViewModel> ByIdAsync(string id)
            => await this.context
                .Posts
                .Where(p => p.Id == id)
                .ProjectTo<PostDetailsViewModel>(this.configurationProvider)
                .FirstOrDefaultAsync();

        public async Task<Post> GetByIdAsync(string id, ModelStateDictionary modelState)
        {
            Post post = await this.context
                .Posts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (post is null) modelState.AddModelError("error", InvalidPostId);

            return post;
        }

        //public async Task<IEnumerable<PostViewModel>> AllByAlbumIdAsync(string id)
        //    => await this.context
        //        .Posts
        //        .Where(p => p.CategoryId == id)
        //        .ProjectTo<PostViewModel>(this.configurationProvider)
        //        .ToListAsync();
    }
}
