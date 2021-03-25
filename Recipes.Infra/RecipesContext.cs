using MongoDB.Driver;
using Recipes.Domain;
using Recipes.Infra.MongoConfig;

namespace Recipes.Infra
{
  public class RecipesContext 
    {
        private readonly IMongoDatabase _database;

        public RecipesContext(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database =  client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Ingredient> Ingredient
        {
            get
            {
                return _database.GetCollection<Ingredient>("Ingredient");
            }
        }

        public IMongoCollection<Recipe> Recipe
        {
            get
            {
                return _database.GetCollection<Recipe>("Recipes");
            }
        }
    }
}
