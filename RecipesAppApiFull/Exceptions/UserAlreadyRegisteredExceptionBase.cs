namespace RecipesAppApiFull.Exceptions
{
    public class UserAlreadyRegisteredException : Exception, IValidationException
    {
        public UserAlreadyRegisteredException(string email) : base($"User with email {email} is already registered.")
        {

        }

        public IEnumerable<string> Errors => new[] { Message };
    }
}
