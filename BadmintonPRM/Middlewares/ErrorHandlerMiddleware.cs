using Newtonsoft.Json;
using Service.Constants;
using Service.Exceptions;
using Service.Models;
using ILogger = Serilog.ILogger;

namespace BadmintonPRM.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, AppException ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = ex.StatusCode;

            var data = new BaseResponse(response.StatusCode, ex.Code, ex.Message);
            var result = JsonConvert.SerializeObject(data, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            await response.WriteAsync(result);
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status500InternalServerError;

            var data = new BaseResponse(response.StatusCode, ResponseCodeConstants.INTERNAL_SERVER_ERROR, ex.Message);
            var result = JsonConvert.SerializeObject(data, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            await response.WriteAsync(result);
        }
    }
}
