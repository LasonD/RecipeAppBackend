using System.Net;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await WriteErrorResponseAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (AccessForbiddenException ex)
            {
                await WriteErrorResponseAsync(context, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                if (ex is IValidationException validationError)
                {
                    await WriteErrorResponseAsync(context, HttpStatusCode.BadRequest, validationError.Errors.ToArray());
                }
                else
                {
                    await WriteErrorResponseAsync(context, HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

        private Task WriteErrorResponseAsync(HttpContext context, HttpStatusCode statusCode, params string[] messages)
        {
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(new ErrorDetails(statusCode, messages).ToString());
        }
    }
}
