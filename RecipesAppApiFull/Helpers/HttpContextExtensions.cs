using Microsoft.AspNetCore.Mvc;

namespace RecipesAppApiFull.Helpers
{
    public static class HttpContextExtensions
    {
        public static int RetrieveUserId(this ControllerBase controller)
        {
            int.TryParse(controller.HttpContext.Items["userId"]?.ToString(), out var userId);

            return userId;
        }
    }
}
