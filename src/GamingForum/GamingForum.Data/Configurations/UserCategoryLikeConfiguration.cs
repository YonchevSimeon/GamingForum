namespace GamingForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserCategoryLikeConfiguration : IEntityTypeConfiguration<UserCategoryLike>
    {
        public void Configure(EntityTypeBuilder<UserCategoryLike> builder)
        {
            builder
                .HasKey(ucl => new { ucl.LikerId, ucl.CategoryId });

            builder
                .HasOne(ucl => ucl.Liker)
                .WithMany(u => u.LikedCategories)
                .HasForeignKey(ucl => ucl.LikerId);

            builder
                .HasOne(ucl => ucl.Category)
                .WithMany(c => c.Likes)
                .HasForeignKey(ucl => ucl.CategoryId);
        }
    }
}
