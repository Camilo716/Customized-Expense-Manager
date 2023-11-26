using Cem.Api.Models;
using CemApi.Data;

namespace CemApi.Services;

public class CategoryService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> FindAllAsync()
    {
        return await _categoryRepository.FindAsync(new { });
    }
}