namespace GamingForum.Models.Constants
{
    public static class ModelConstants
    {
        public static class GameForumUser
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 12;

            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 16;
        }

        public static class Category
        {
            public const int CategoryTitleMinLength = 4;
            public const int CategoryTitleMaxLength = 20;
        }

        public static class Post
        {
            public const int PostTitleMinLength = 4;
            public const int PostTitleMaxLength = 20;

            public const int PostDescriptionMaxLength = 300;
        }

        public static class Reply
        {
            public const int ReplyDescriptionMinLength = 1;
            public const int ReplyDescriptionMaxLength = 100;
        }
    }
}
