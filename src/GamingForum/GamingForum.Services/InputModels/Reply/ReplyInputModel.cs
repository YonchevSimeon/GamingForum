namespace GamingForum.Services.InputModels.Reply
{
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using static InputModels.Constants.ErrorMessages;
    using static InputModels.Constants.InputModelsConstants.Reply;

    public class ReplyInputModel : IMapFrom<Reply>
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(DescriptionMaxLength, ErrorMessage = InvalidDescriptionError)]
        public string Description { get; set; }

        public string PostId { get; set; }
        public Post Post { get; set; }
    }
}
