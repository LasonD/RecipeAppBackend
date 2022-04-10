namespace Application.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception
    {
        public EntityNotFoundException(object id) : base($"Entity {typeof(TEntity).Name} with id {id} was not found")
        {

        }
    }
}
