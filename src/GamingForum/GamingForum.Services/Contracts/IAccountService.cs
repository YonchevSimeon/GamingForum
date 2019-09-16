namespace GamingForum.Services.Contracts
{
    using System.Threading.Tasks;
    using InputModels.Account;

    public interface IAccountService
    {
        Task LogInAsync(LoginInputModel model);

        Task RegisterAsync(RegisterInputModel model);

        Task LogOutAsync();

        bool UserNameExists(string userName);

        bool EmailAddressExists(string emailAddress);
    }
}
