namespace GamingForum.Models
{
    public class UserCategoryLike
    {
        public string LikerId { get; set; }
        public virtual GamingForumUser Liker { get; set;}

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
