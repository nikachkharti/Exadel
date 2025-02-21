using BookManagement.Service.Exceptions;
using BookManagement.Service.Exceptions.Base.Exceptions;
using System.Net;

namespace BookManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            EndpointResponse apiResponse = new();

            switch (exception)
            {
                case BadHttpRequestException:
                case BookAlreadyExistsException:
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = exception.Message;
                    apiResponse.Result = null;
                    break;
                case BookNotFoundException:
                case NotFoundException:
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = exception.Message;
                    apiResponse.Result = null;
                    break;
                case InternalServerException:
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = exception.Message;
                    apiResponse.Result = null;
                    break;
                default:
                    apiResponse.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                    apiResponse.IsSuccess = false;
                    apiResponse.Message = exception.Message;
                    apiResponse.Result = null;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = apiResponse.StatusCode;

            return context.Response.WriteAsJsonAsync(apiResponse);
        }

    }
}
