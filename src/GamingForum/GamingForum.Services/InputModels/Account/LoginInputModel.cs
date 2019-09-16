namespace GamingForum.Services.InputModels.Account
{
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;

    public class LoginInputModel : IMapFrom<GamingForumUser>
    {
        [Required(ErrorMessage = RequiredError)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
