using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
        {
            return services.AddSwaggerDocument(options =>
            {
                options.Title = "ChatApp.Api";
            });
        }
    }
}
