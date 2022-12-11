using AutoMapper;
using CookBook.Models;

namespace CookBook.Dto;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>()
            .ReverseMap();

        CreateMap<IngredientEntry, IngredientEntryDto>()
            .ReverseMap();

        CreateMap<PreparationStep, PreparationStepDto>()
            .ReverseMap();

        CreateMap<Recipe, RecipeDto>()
            .ForMember(dest => dest.CategoryIds, o => o.MapFrom(src => src.RecipeCategories.Select(c => c.CategoryId)))
            .ReverseMap()
            .ForMember(src => src.RecipeCategories,
                o => o.MapFrom((src, dest, destMember, context) =>
                    src.CategoryIds.Select(cid => new RecipeCategory(cid, dest.Id))));
    }
}