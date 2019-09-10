namespace GamingForum.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class GamingForumDbContext : IdentityDbContext<GamingForumUser>
    {
        public GamingForumDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
