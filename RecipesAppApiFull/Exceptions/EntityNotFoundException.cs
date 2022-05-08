namespace RecipesAppApiFull.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, object id) : base($"Entity {entityName} with id {id} was not found")
        {

        }
    }
}
