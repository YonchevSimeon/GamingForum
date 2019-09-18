namespace GamingForum.Services.ViewModels.Account
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;
    using System.Linq;

    public class AccountViewModel : IMapFrom<GamingForumUser>, IHaveCustomMapping
    {
        public string UserName { get; set; }

        public int Categories { get; set; }

        public int Posts { get; set; }

        public int Replies { get; set; }


        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<GamingForumUser, AccountViewModel>()
                    .ForMember(a => a.Categories, cfg => cfg.MapFrom(gfu => gfu.CreatedCategories.Count()))
                    .ForMember(a => a.Posts, cfg => cfg.MapFrom(gfu => gfu.Posts.Count()))
                    .ForMember(a => a.Replies, cfg => cfg.MapFrom(gfu => gfu.Replies.Count()));
    }
}
