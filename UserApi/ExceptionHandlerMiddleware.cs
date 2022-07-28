namespace UserApi
{
    public static class ExceptionHandlerMiddleware
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HandelerErrorsMiddleware>();
        }
    }
}
