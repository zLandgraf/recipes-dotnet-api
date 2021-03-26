using AutoMapper;
using Recipes.Domain;

namespace Recipes.Application.Ingredients.TransferObjects
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ingredient, IngredientDTO>();
        }
    }
}
