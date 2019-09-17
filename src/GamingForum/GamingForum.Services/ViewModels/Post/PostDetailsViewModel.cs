namespace GamingForum.Services.ViewModels.Post
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;
    using System.Collections.Generic;
    using ViewModels.Reply;

    public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PosterId { get; set; }

        public string Poster { get; set; }

        public string PostedOn { get; set; }

        public string CategoryId { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<Post, PostDetailsViewModel>()
                    .ForMember(p => p.Poster, cfg => cfg.MapFrom(p => p.Poster.UserName))
                    .ForMember(p => p.PostedOn, cfg => cfg.MapFrom(p => p.PostedOn.ToShortDateString()))
                    .ForMember(p => p.Replies, cfg => cfg.MapFrom(p => p.Replies));
    }
}
