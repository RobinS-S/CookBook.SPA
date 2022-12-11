using CookBook.Auth;
using CookBook.Dto;
using CookBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly RecipeService recipeService;

    public RecipesController(RecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RecipeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> Get([FromQuery] long? categoryId)
    {
        var recipes = await recipeService.GetRecipesAsync(categoryId);
        return Ok(recipes);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(RecipeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecipeDto>> Get(long id)
    {
        var recipe = await recipeService.GetRecipeByIdAsync(id);
        if (recipe == null) return NotFound();

        return Ok(recipe);
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(RecipeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RecipeDto>> Post([FromBody] RecipeDto recipe)
    {
        var newRecipe = await recipeService.AddRecipeAsync(recipe);

        return Ok(newRecipe);
    }

    [Authorize]
    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(RecipeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RecipeDto>> Put(long id, [FromBody] RecipeDto recipe)
    {
        var updatedRecipe = await recipeService.UpdateRecipeAsync(id, recipe);
        if (updatedRecipe == null) return NotFound();

        return Ok(updatedRecipe);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<bool>> Delete(long id)
    {
        var deleted = await recipeService.DeleteRecipeAsync(id);
        if (!deleted) return NoContent();

        return Ok(deleted);
    }
}