namespace GamingForum.Web.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;

    public class AutorizeRolesAttribute : AuthorizeAttribute
    {
        public AutorizeRolesAttribute(params string[] roles)
            : base()
        {
            Roles = string.Join(", ", roles);
        }
    }
}
