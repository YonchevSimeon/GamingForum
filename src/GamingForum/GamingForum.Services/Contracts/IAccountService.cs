namespace GamingForum.Services.Contracts
{
    using Models;
    using InputModels.Account;
    using ViewModels.Account;
    using System.Threading.Tasks;
    using System.Security.Claims;

    public interface IAccountService
    {
        Task LogInAsync(LoginInputModel model);

        Task RegisterAsync(RegisterInputModel model);

        Task LogOutAsync();

        Task<GamingForumUser> GetLoggedInUserAsync(ClaimsPrincipal claimsPrincipal);

        Task<AccountViewModel> GetProfileByIdAsync(string id);

        bool UserNameExists(string userName);

        bool EmailAddressExists(string emailAddress);
    }
}
