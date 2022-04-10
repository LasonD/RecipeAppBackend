namespace Domain.Entities
{
    public abstract class AbstractEntity
    {
        private int _id;

        protected AbstractEntity(int id = default)
        {
            

            Id = id;
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

                _id = value;
            }
        }
    }
}
