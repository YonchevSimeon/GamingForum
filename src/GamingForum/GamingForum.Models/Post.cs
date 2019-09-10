namespace GamingForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Constants.ModelConstants.Post;
    public class Post : BaseModel<string>
    {
        public Post()
        {
            this.Replies = new HashSet<Reply>();
            this.Likes = new HashSet<UserPostLike>();
        }

        [Required]
        [MinLength(PostTitleMinLength)]
        [MaxLength(PostTitleMaxLength)]
        public string Name { get; set; }

        [MinLength(PostDescriptionMaxLength)]
        public string Description { get; set; }

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string PosterId { get; set; }
        public virtual GamingForumUser Poster { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<UserPostLike> Likes { get; set; }
    }
}
