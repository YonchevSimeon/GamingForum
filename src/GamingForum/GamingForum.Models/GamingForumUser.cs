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
        }

        public virtual ICollection<Category> CreatedCategories { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
