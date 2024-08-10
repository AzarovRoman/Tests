using System.Net;
using System.Text.Json;
using Tests.BLL.Exceptions;
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
            // в секциях catch будут отбиваться все исключения. Секции catch выполнять от частного к общему
            try
            {
                await _next(context);
            }
            catch (ServerExeption ex)
            {
                await ConstructResponse(context, HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await ConstructResponse(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (ClientException ex)
            {
                await ConstructResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await ConstructResponse(context, HttpStatusCode.InternalServerError, ex.Message);
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
