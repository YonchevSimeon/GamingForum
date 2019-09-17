namespace GamingForum.Services.InputModels.Constants
{
    public static class InputModelsConstants
    {
        public static class Account
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 12;

            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 12;
        }

        public static class Category
        {
            public const int TitleMinLength = 4;
            public const int TitleMaxLength = 20;
        }

        public static class Post
        {
            public const int TitleMinLength = 4;
            public const int TitleMaxLength = 20;

            public const int DescriptionMaxLength = 300;
        }

        public static class Reply
        {
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 100;
        }
    }
}
