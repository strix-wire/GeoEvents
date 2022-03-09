namespace GeoEvents.Mvc.Middleware
{
    //Чтобы мы могли включить элемент middleware в конвеер
    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
