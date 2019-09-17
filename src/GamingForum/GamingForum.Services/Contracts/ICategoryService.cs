namespace GamingForum.Services.Contracts
{
    using InputModels.Category;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllAsync();

        Task CreateAsync(CategoryInputModel model, GamingForumUser creator);

        Task<CategoryDetailsViewModel> ByIdAsync(string id);

        Task<Category> GetByIdAsync(string id, ModelStateDictionary modelState);



        bool TitleExists(string title);
    }
}
