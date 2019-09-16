namespace GamingForum.Services.Attributes
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;

    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryTitleExistsAttribute : ValidationAttribute
    {
        ICategoryService categoryService;

        public CategoryTitleExistsAttribute() { }

        public CategoryTitleExistsAttribute(string errorMessage) : base(errorMessage) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.categoryService = (ICategoryService)validationContext.GetService(typeof(ICategoryService));

            if (!this.categoryService.TitleExists(value.ToString())) return ValidationResult.Success;
            else return new ValidationResult(CateogryTitleExists);
        }
    }
}
