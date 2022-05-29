using Microsoft.AspNetCore.Identity;

namespace RecipesAppApiFull.Exceptions
{
    public class UnableToRegisterException : Exception, IValidationException
    {
        public UnableToRegisterException(ICollection<IdentityError> errors) :
            base(string.Join(";\n", errors.Select(x => $"{x.Code}: {x.Description}")))
        {
            IdentityErrors = errors.ToArray();
        }

        public IEnumerable<IdentityError> IdentityErrors { get; set; }

        public IEnumerable<string> Errors => IdentityErrors.Select(x => x.Description);
    }
}
