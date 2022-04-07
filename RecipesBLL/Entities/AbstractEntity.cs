namespace Domain.Entities
{
    public abstract class AbstractEntity
    {
        protected AbstractEntity(int id = default)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
        }

        public int Id { get; private set; }
    }
}
