using Microsoft.AspNetCore.Identity;

namespace RecipesAppApiFull.Exceptions
{
    public class UnableToRegisterException : Exception
    {
        public UnableToRegisterException(ICollection<IdentityError> errors) :
            base(string.Join(";\n", errors.Select(x => $"{x.Code}: {x.Description}")))
        {
            Errors = errors.ToArray();
        }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
