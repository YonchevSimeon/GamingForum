namespace GamingForum.Services.InputModels.Constants
{
    public static class ErrorMessages
    {
        #region errors
        public const string RequiredError = "The {0} is a required field!";

        public const string ExistsError = "{0} already exists!";

        public const string InvalidUsernameError = "The {0}, must be between {2} and {1} charecters long.";

        public const string InvalidPasswordError = "The {0}, must be between {1} and {2} charecters long.";

        public const string PasswordsDoNotMatchError = "The password and confirmantion password does not match!";

        public const string InvalidUsernameOrPasswordError = "Invalid username or password!";

        public const string InvalidEmailError = "This is not a valid email address.";
        #endregion

        #region messages
        public const string UserNameExistsMessage = "There is already an user registered with this username.";

        public const string EmailAddressExistsMessage = "There is alrady an user registered with this email.";
        #endregion
    }
}
