namespace GamingForum.Models
{
    public class UserReplyLike
    {
        public string LikerId { get; set; }
        public virtual GamingForumUser Liker { get; set; }

        public string ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
    }
}
