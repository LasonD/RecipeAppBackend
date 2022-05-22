namespace RecipesAppApiFull.Exceptions
{
    public class UserAlreadyRegisteredException : Exception, IBusinessRuleException
    {
        public UserAlreadyRegisteredException(string email) : base($"User with email {email} is already registered.")
        {

        }
    }
}
