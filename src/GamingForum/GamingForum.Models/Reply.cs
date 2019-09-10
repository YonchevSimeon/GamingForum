namespace GamingForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Constants.ModelConstants.Reply;

    public class Reply : BaseModel<string>
    {
        public Reply()
        {
            this.Likes = new HashSet<UserReplyLike>();
        }

        public string ReplierId { get; set; }
        public virtual GamingForumUser Replier { get; set; }

        public string PostId { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        [MinLength(ReplyDescriptionMinLength)]
        [MaxLength(ReplyDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime RepliedOn { get; set; }

        public virtual ICollection<UserReplyLike> Likes { get; set; }
    }
}
