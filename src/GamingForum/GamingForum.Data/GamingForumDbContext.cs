namespace GamingForum.Data
{
    using Configurations;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class GamingForumDbContext : IdentityDbContext<GamingForumUser>
    {
        public GamingForumDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<UserCategoryLike> UserCategoryLikes { get; set; }

        public DbSet<UserPostLike> UserPostLikes { get; set; }

        public DbSet<UserReplyLike> UserReplyLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GamingForumUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new ReplyConfiguration());
            builder.ApplyConfiguration(new UserCategoryLikeConfiguration());
            builder.ApplyConfiguration(new UserPostLikeConfiguration());
            builder.ApplyConfiguration(new UserReplyLikeConfiguration());
        }
    }
}
