namespace GamingForum.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using GamingForum.Data;
    using GamingForum.Models;
    using GamingForum.Services.InputModels.Reply;
    using GamingForum.Services.ViewModels.Reply;
    using Microsoft.EntityFrameworkCore;

    public class ReplyService : BaseService, IReplyService
    {
        private readonly IConfigurationProvider configurationProvider;

        public ReplyService(IMapper mapper, GamingForumDbContext context, IConfigurationProvider configurationProvider) 
            : base(mapper, context)
        {
            this.configurationProvider = configurationProvider;
        }

        public ReplyInputModel GetReplyInputForm(Post post)
        {
            ReplyInputModel model = new ReplyInputModel()
            {
                PostId = post.Id,
                Post = post
            };

            return model;
        }

        public async Task MakeAsync(ReplyInputModel model, GamingForumUser Replier)
        {
            Reply reply = this.mapper.Map<ReplyInputModel, Reply>(model);

            reply.Replier = Replier;
            reply.RepliedOn = DateTime.UtcNow;

            await this.context.Replies.AddAsync(reply);
            await this.context.SaveChangesAsync();
        }

        public async Task<ReplyDetailsViewModel> ByIdAsync(string id)
            => await this.context
                .Replies
                .Where(p => p.Id == id)
                .ProjectTo<ReplyDetailsViewModel>(this.configurationProvider)
                .FirstOrDefaultAsync();

    }
}
