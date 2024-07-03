using System.Net;
using System.Text.Json;
using Tests.Models;

namespace Tests.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // в секциях catch будут отбиваться все исключения
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await ConstructResponse(context, HttpStatusCode.InternalServerError, error.Message);
            }
        }

        private async Task ConstructResponse(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var updateModel = new ExceptionModel { Code = (int)code, Message = message };

            var result = JsonSerializer.Serialize(updateModel);
            await context.Response.WriteAsync(result);
        }
    }
}
