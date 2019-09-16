namespace GamingForum.Services.Attributes
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;

    [AttributeUsage(AttributeTargets.Property)]
    public class UsernameExistsAttribute : ValidationAttribute
    {
        private IAccountService accountService;

        public UsernameExistsAttribute() { }

        public UsernameExistsAttribute(string errorMessage) : base(errorMessage) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.accountService = (IAccountService)validationContext.GetService(typeof(IAccountService));

            if (!this.accountService.UserNameExists(value.ToString())) return ValidationResult.Success;
            else return new ValidationResult(UserNameExistsMessage);
        }
    }
}
