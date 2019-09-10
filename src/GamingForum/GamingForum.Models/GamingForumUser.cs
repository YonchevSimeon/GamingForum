namespace GamingForum.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class GamingForumUser : IdentityUser
    {
        public GamingForumUser()
        {
            this.CreatedCategories = new HashSet<Category>();
            this.Posts = new HashSet<Post>();
            this.Replies = new HashSet<Reply>();
            this.LikedCategories = new HashSet<UserCategoryLike>();
            this.LikedPosts = new HashSet<UserPostLike>();
            this.LikedReplies = new HashSet<UserReplyLike>();
        }

        public virtual ICollection<Category> CreatedCategories { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<UserCategoryLike> LikedCategories { get; set; }

        public virtual ICollection<UserPostLike> LikedPosts { get; set; }

        public virtual ICollection<UserReplyLike> LikedReplies { get; set; }
    }
}
