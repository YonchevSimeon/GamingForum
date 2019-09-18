namespace GamingForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Constants.ModelConstants.Category;
    public class Category : BaseModel<string>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(CategoryTitleMinLength)]
        [MaxLength(CategoryTitleMaxLength)]
        public string Title { get; set; }

        public string CreatorId { get; set; }
        public virtual GamingForumUser Creator { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
