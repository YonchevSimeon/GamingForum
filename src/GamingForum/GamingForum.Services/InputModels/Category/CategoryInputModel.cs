namespace GamingForum.Services.InputModels.Category
{
    using Attributes;
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;
    using static InputModels.Constants.InputModelsConstants.Category;

    public class CategoryInputModel : IMapFrom<Category>
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(TitleMaxLength, ErrorMessage = InvalidTitleError, MinimumLength = TitleMinLength)]
        [CategoryTitleExists(ErrorMessage = ExistsError)]
        public string Title { get; set; }
    }
}
