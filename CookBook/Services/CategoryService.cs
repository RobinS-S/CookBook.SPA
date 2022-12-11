using AutoMapper;
using CookBook.Data;
using CookBook.Dto;
using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Services;

public class CategoryService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public CategoryService(IMapper mapper, ApplicationDbContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task<IList<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await context.Categories.ToListAsync();
        return mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(long id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null) return null;

        return mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    {
        var newCategory = mapper.Map<Category>(categoryDto);
        context.Categories.Add(newCategory);
        await context.SaveChangesAsync();
        return mapper.Map<CategoryDto>(newCategory);
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(long id, CategoryDto categoryDto)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null || id != categoryDto.Id) return null;

        category = mapper.Map(categoryDto, category);
        context.Categories.Update(category);
        await context.SaveChangesAsync();

        return mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> DeleteCategoryAsync(long id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null) return false;

        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return true;
    }
}