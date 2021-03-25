using MediatR;
using Recipes.Domain;

namespace Recipes.Application.Recipes.Commands
{
    public class CreateRecipe : IRequest<Recipe>
    {
    }
}