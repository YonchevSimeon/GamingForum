namespace GamingForum.Services
{
    using AutoMapper;
    using Data;

    public abstract class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly GamingForumDbContext context;

        public BaseService(IMapper mapper, GamingForumDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
    }
}
