namespace GamingForum.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using Data;
    using InputModels.Account;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using Models.Enums;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<GamingForumUser> userManager;
        private readonly SignInManager<GamingForumUser> signInManager;

        public AccountService(IMapper mapper, GamingForumDbContext context, UserManager<GamingForumUser> userManager, SignInManager<GamingForumUser> signInManager)
            : base(mapper, context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task LogInAsync(LoginInputModel model)
        {
            GamingForumUser user = this.mapper.Map<LoginInputModel, GamingForumUser>(model);
            
            await this.LogInAsync(user, model.Password);
        }

        public async Task RegisterAsync(RegisterInputModel model)
        {
            GamingForumUser user = this.mapper.Map<RegisterInputModel, GamingForumUser>(model);

            await this.RegisterAsync(user, model.Password);
        }

        public async Task LogOutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<GamingForumUser> GetLoggedInUserAsync(ClaimsPrincipal claimsPrincipal)
            => await this.userManager.GetUserAsync(claimsPrincipal);

        public bool UserNameExists(string userName)
            => this.context.Users.Any(u => u.UserName == userName);

        public bool EmailAddressExists(string emailAddress)
            => this.context.Users.Any(u => u.Email == emailAddress);

        private async Task<SignInResult> LogInAsync(GamingForumUser user, string password) 
            => await this.signInManager.PasswordSignInAsync(user.UserName, password, false, lockoutOnFailure: true);

        private async Task<IdentityResult> RegisterAsync(GamingForumUser user, string password)
        {
            IdentityResult result = await this.userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (this.context.Users.Count() == 1)
                    await this.userManager.AddToRoleAsync(user, Role.Administrator.ToString());
                else
                    await this.userManager.AddToRoleAsync(user, Role.User.ToString());

                await this.signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}