using System.Collections.Generic;
using MediatR;
using Recipes.Domain;

namespace Recipes.Application.Recipes.Queries
{
    public class GetAllRecipes : IRequest<IEnumerable<Recipe>>
    {
    }
}