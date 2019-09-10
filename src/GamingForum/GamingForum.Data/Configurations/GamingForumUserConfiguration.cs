namespace GamingForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GamingForumUserConfiguration : IEntityTypeConfiguration<GamingForumUser>
    {
        public void Configure(EntityTypeBuilder<GamingForumUser> builder)
        {
            builder
                .HasMany(gfu => gfu.CreatedCategories)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder
                .HasMany(gfu => gfu.Posts)
                .WithOne(p => p.Poster)
                .HasForeignKey(p => p.PosterId);

            builder
                .HasMany(gfu => gfu.Replies)
                .WithOne(r => r.Replier)
                .HasForeignKey(r => r.ReplierId);
        }
    }
}
