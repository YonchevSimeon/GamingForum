namespace GamingForum.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using InputModels.Category;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels.Category;
    using static InputModels.Constants.ErrorMessages;

    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IConfigurationProvider configurationProvider;

        public CategoryService(IMapper mapper, GamingForumDbContext context, IConfigurationProvider configurationProvider) 
            : base(mapper, context)
        {
            this.configurationProvider = configurationProvider;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllAsync()
            => await this.context
                .Categories
                .OrderByDescending(c => c.CreatedOn)
                .ProjectTo<CategoryViewModel>(this.configurationProvider)
                .ToListAsync();

        public async Task CreateAsync(CategoryInputModel model, GamingForumUser creator)
        {
            Category category = this.mapper.Map<CategoryInputModel, Category>(model);

            category.Creator = creator;
            category.CreatedOn = DateTime.UtcNow;

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<CategoryDetailsViewModel> ByIdAsync(string id)
            => await this.context
                .Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryDetailsViewModel>(this.configurationProvider)
                .FirstOrDefaultAsync();

        public async Task<Category> GetByIdAsync(string id, ModelStateDictionary modelState)
        {
            Category category = await this.context
                .Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category is null) modelState.AddModelError("error", InvalidCategoryId);

            return category;
        }

        public bool TitleExists(string title)
            => this.context.Categories.Any(c => c.Title == title);
    }
}
