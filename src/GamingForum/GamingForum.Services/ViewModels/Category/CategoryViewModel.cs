namespace GamingForum.Services.ViewModels.Category
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string CreatorId { get; set; }

        public string Creator { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryViewModel>()
                .ForMember(c => c.Creator, cfg => cfg.MapFrom(c => c.Creator.UserName));
    }
}
