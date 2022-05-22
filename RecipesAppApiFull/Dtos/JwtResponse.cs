using Newtonsoft.Json;

namespace RecipesAppApiFull.Dtos
{
    public record JwtResponse(
        [JsonProperty(PropertyName = "access_token")] string AccessToken,
        [JsonProperty(PropertyName = "email")] string Email,
        [JsonProperty(PropertyName = "expires_in")] DateTime ExpiresIn,
        [JsonProperty(PropertyName = "local_id")] string UserId);
}
