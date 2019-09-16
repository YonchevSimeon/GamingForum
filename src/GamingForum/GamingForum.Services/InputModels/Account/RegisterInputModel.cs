namespace GamingForum.Services.InputModels.Account
{
    using Attributes;
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using static Constants.ErrorMessages;
    using static Constants.InputModelsConstants.Account;
    public class RegisterInputModel : IMapFrom<GamingForumUser>
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(UsernameMaxLength, ErrorMessage = InvalidUsernameError, MinimumLength = UsernameMinLength)]
        [UsernameExists(ErrorMessage = ExistsError)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [EmailAddress(ErrorMessage = InvalidEmailError)]
        [EmailAddressExists(ErrorMessage = ExistsError)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordError, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = PasswordsDoNotMatchError)]
        public string Password { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordError, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = PasswordsDoNotMatchError)]
        public string ConfirmPassword { get; set; }
    }
}
