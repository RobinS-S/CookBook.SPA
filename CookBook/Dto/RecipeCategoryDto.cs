using Newtonsoft.Json;

namespace CookBook.Dto;

public class RecipeCategoryDto
{
    [JsonProperty(Required = Required.DisallowNull)]
    public long CategoryId { get; set; }
}