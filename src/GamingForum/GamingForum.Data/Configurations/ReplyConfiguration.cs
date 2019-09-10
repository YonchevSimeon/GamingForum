namespace GamingForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .HasForeignKey(p => p.PostId);
        }
    }
}
