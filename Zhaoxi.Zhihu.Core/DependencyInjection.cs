using Microsoft.Extensions.DependencyInjection;
using Zhaoxi.Zhihu.Core.Interfaces;
using Zhaoxi.Zhihu.Core.Services;

namespace Zhaoxi.Zhihu.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IFollowQuestionService, FollowQuestionService>();
        return services;
    }
}