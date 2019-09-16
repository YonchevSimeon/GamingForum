namespace GamingForum.Services.Contracts
{
    using Models;
    using InputModels.Account;
    using System.Threading.Tasks;
    using System.Security.Claims;

    public interface IAccountService
    {
        Task LogInAsync(LoginInputModel model);

        Task RegisterAsync(RegisterInputModel model);

        Task LogOutAsync();

        Task<GamingForumUser> GetLoggedInUserAsync(ClaimsPrincipal claimsPrincipal);

        bool UserNameExists(string userName);

        bool EmailAddressExists(string emailAddress);
    }
}
