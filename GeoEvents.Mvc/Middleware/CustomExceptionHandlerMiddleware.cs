using System.Net;
using FluentValidation;
using System.Text.Json;
using GeoEvents.Application.Common.Exceptions;

namespace GeoEvents.Mvc.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        //Call next delegate request in middleware
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        //Вызывает делегат next и перехватывает
        //и обрабатывает исключение, если оно возникло
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        //Метод для обработки исключений
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //код ответа
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            //Если возникло исключение валидации - то BadRequest, а в результат
            //записываем ошибки валидации
            //Если мое добавленное исключение (DirectoryNotFoundException) - то NotFound
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case DirectoryNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            //Тип возвращаемого контента
            context.Response.ContentType = "application/json";
            //Статус код кладем в ответ
            context.Response.StatusCode = (int)code;

            //Если другое исключение
            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message});
            }

            //Возвращаем контекст, записав в него результат
            return context.Response.WriteAsync(result);
        }

    }
}
