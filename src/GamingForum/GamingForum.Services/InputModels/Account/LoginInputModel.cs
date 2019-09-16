namespace GamingForum.Services.InputModels.Account
{
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel : IMapFrom<GamingForumUser>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
