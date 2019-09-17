namespace GamingForum.Services.ViewModels.Reply
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;

    public class ReplyDetailsViewModel : IMapFrom<Reply>, IHaveCustomMapping
    {
        public string Description { get; set; }

        public string ReplierId { get; set; }

        public string Replier { get; set; }

        public string RepliedOn { get; set; }

        public string PostId { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<Reply, ReplyDetailsViewModel>()
                    .ForMember(r => r.Replier, cfg => cfg.MapFrom(r => r.Replier.UserName))
                    .ForMember(r => r.RepliedOn, cfg => cfg.MapFrom(r => r.RepliedOn.ToShortDateString()));
    }
}
