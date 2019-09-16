namespace GamingForum.Services.ViewModels.Category
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Models;

    public class CategoryDetailsViewModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public string Title { get; set; }

        public string CreatorId { get; set; }

        public string Creator { get; set; }

        public string CreatedOn { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryDetailsViewModel>()
                    .ForMember(c => c.Creator, cfg => cfg.MapFrom(c => c.Creator.UserName))
                    .ForMember(c => c.CreatedOn, cfg => cfg.MapFrom(c => c.CreatedOn.ToShortDateString()));
                
    }
}
