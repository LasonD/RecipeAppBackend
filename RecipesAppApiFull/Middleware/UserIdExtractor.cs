using System.Security.Claims;

namespace RecipesAppApiFull.Middleware
{
    public class UserIdExtractor
    {
        private readonly RequestDelegate _next;

        public UserIdExtractor(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            {
                context.Items[Constants.UserIdRouteKey] = userId;
            }

            return _next.Invoke(context);
        }
    }
}
