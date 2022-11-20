using AutoMapper;
using CookBook.Models;

namespace CookBook.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(src => src.Id, o => o.Ignore())
                .ReverseMap();

            CreateMap<Ingredient, IngredientDto>()
                .ForMember(src => src.Id, o => o.Ignore())
                .ReverseMap();

            CreateMap<RecipeIngredientAmount, RecipeIngredientAmountDto>()
                .ReverseMap();

            CreateMap<Recipe, RecipeDto>()
                .ForMember(src => src.Id, o => o.Ignore())
                .ReverseMap();
        }
    }
}
