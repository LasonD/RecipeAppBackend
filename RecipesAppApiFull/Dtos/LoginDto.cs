using System.ComponentModel.DataAnnotations;

namespace RecipesAppApiFull.Dtos
{
    public record LoginDto([Required] string Email, [Required] string Password);
}
