using IamService.Infrastructure.Pipeline.Middleware.Components;

namespace IamService.Infrastructure.Pipeline.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestAuthorizationMiddleware>();
}