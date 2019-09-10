namespace GamingForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserPostLikeConfiguration : IEntityTypeConfiguration<UserPostLike>
    {
        public void Configure(EntityTypeBuilder<UserPostLike> builder)
        {
            builder
                .HasKey(upl => new { upl.LikerId, upl.PostId });

            builder
                .HasOne(upl => upl.Liker)
                .WithMany(u => u.LikedPosts)
                .HasForeignKey(upl => upl.LikerId);

            builder
                .HasOne(upl => upl.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(upl => upl.PostId);
        }
    }
}
