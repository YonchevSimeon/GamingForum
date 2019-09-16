namespace GamingForum.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using Data;
    using InputModels.Category;
    using ViewModels.Category;
    using Models;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

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

        public bool TitleExists(string title)
            => this.context.Categories.Any(c => c.Title == title);
    }
}
