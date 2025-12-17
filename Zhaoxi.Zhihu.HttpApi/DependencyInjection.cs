using Zhaoxi.Zhihu.HttpApi.Services;
using Zhaoxi.Zhihu.UseCases.Common.Interfaces;

namespace Zhaoxi.Zhihu.HttpApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        return services;
    }
}