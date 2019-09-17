namespace GamingForum.Services.ViewModels.Reply
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;
    using System.Linq;

    public class ReplyViewModel : IMapFrom<Reply>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<Reply, ReplyViewModel>()
                    .ForMember(r => r.Description, cfg => cfg.MapFrom(r => r.Description.Substring(0, 10) + "..."));
    }
}
