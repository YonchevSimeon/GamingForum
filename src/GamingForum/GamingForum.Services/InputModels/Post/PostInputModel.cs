namespace GamingForum.Services.InputModels.Post
{
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;
    using static InputModels.Constants.InputModelsConstants.Post;

    public class PostInputModel : IMapFrom<Post>
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(TitleMaxLength, ErrorMessage = InvalidTitleError, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [StringLength(DescriptionMaxLength, ErrorMessage = InvalidDescriptionError)]
        public string Description { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
