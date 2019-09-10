namespace GamingForum.Models
{
    public class UserPostLike
    {
        public string LikerId { get; set; }
        public virtual GamingForumUser Liker { get; set; }

        public string PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
