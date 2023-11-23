using Cem.Api.Models;
using CemApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CemApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAsync()
    {
        IEnumerable<Category> categories = await _categoryService.FindAllAsync();
        return Ok(categories);
    }
}