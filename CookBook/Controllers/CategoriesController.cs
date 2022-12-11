using CookBook.Auth;
using CookBook.Dto;
using CookBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        var categories = await categoryService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> Get(long id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();

        return Ok(category);
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto category)
    {
        var newCategory = await categoryService.AddCategoryAsync(category);

        return Ok(newCategory);
    }

    [Authorize]
    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> Put(long id, [FromBody] CategoryDto category)
    {
        var updatedCategory = await categoryService.UpdateCategoryAsync(id, category);
        if (updatedCategory == null) return NotFound();

        return Ok(updatedCategory);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<bool>> Delete(long id)
    {
        var deleted = await categoryService.DeleteCategoryAsync(id);
        if (!deleted) return NoContent();
        return Ok(deleted);
    }
}