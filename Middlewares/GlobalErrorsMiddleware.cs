using storeManagerDotNet.Exceptions;
using System.Text.Json;

namespace storeManagerDotNet.Middlewares
{
    public class GlobalErrorsMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerErrorAsync(context, ex);
            }
        }

        public static Task HandlerErrorAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            string message;
            var exceptionType = ex.GetType();
            if (exceptionType == typeof(DbNotFoundException))
            {
                context.Response.StatusCode = 404;
                message = ex.Message;
            }
            else
            {
                context.Response.StatusCode = 500;
                message = ex.Message;
            }
            var result = JsonSerializer.Serialize(new { message });
            return context.Response.WriteAsync(result);
        }
    }
}
