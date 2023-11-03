using CEM.Repositories;
using CemApi.Models;

namespace CemApi.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> FindAllAsync()
    {
        return _categoryRepository.GetAllCategories();
    }
}