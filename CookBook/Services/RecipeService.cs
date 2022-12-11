using AutoMapper;
using CookBook.Data;
using CookBook.Dto;
using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Services;

public class RecipeService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public RecipeService(IMapper mapper, ApplicationDbContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task<RecipeDto?> GetRecipeByIdAsync(long id)
    {
        var recipe = await context.Recipes
            .Include(r => r.RecipeCategories)
            .Include(r => r.IngredientEntries)
            .Include(r => r.Preparation)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (recipe == null) return null;

        return mapper.Map<RecipeDto>(recipe);
    }

    public async Task<IList<RecipeDto>> GetRecipesAsync(long? categoryId)
    {
        var recipes = await context.Recipes
            .Include(r => r.RecipeCategories)
            .Include(r => r.IngredientEntries)
            .Include(r => r.Preparation)
            .Where(src => !categoryId.HasValue || src.Categories.Any(c => c.Id == categoryId))
            .ToListAsync();
        return mapper.Map<List<RecipeDto>>(recipes);
    }

    public async Task<RecipeDto> AddRecipeAsync(RecipeDto recipeDto)
    {
        var newRecipe = mapper.Map<Recipe>(recipeDto);
        context.Recipes.Add(newRecipe);
        await context.SaveChangesAsync();
        return mapper.Map<RecipeDto>(newRecipe);
    }

    public async Task<RecipeDto?> UpdateRecipeAsync(long id, RecipeDto recipeDto)
    {
        var recipe = await context.Recipes.Include(r => r.RecipeCategories).FirstOrDefaultAsync(c => c.Id == id);
        if (recipe == null) return null;

        recipe = mapper.Map(recipeDto, recipe);
        context.Recipes.Update(recipe);
        await context.SaveChangesAsync();

        return mapper.Map<RecipeDto>(recipe);
    }

    public async Task<bool> DeleteRecipeAsync(long id)
    {
        var recipe = await context.Recipes.FirstOrDefaultAsync(c => c.Id == id);
        if (recipe == null) return false;

        context.Recipes.Remove(recipe);
        await context.SaveChangesAsync();
        return true;
    }
}