namespace GamingForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserReplyLikeConfiguration : IEntityTypeConfiguration<UserReplyLike>
    {
        public void Configure(EntityTypeBuilder<UserReplyLike> builder)
        {
            builder
                .HasKey(url => new { url.LikerId, url.ReplyId });

            builder
                .HasOne(url => url.Liker)
                .WithMany(u => u.LikedReplies)
                .HasForeignKey(url => url.LikerId);

            builder
                .HasOne(url => url.Reply)
                .WithMany(r => r.Likes)
                .HasForeignKey(url => url.ReplyId);
        }
    }
}
