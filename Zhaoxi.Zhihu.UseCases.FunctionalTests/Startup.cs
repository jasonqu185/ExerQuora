using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Zhaoxi.Zhihu.Core;
using Zhaoxi.Zhihu.Infrastructure.Data;
using Zhaoxi.Zhihu.Infrastructure.Data.Interceptors;
using Zhaoxi.Zhihu.Infrastructure.Data.Repositories;
using Zhaoxi.Zhihu.SharedKernel.Repository;
using Zhaoxi.Zhihu.UseCases.Common.Interfaces;

namespace Zhaoxi.Zhihu.UseCases.FunctionalTests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var mockUser = new Mock<IUser>();
        mockUser.Setup(user => user.Id).Returns(1);
        services.AddSingleton(mockUser.Object);

        ConfigureEfCore(services);

        services.AddScoped<DbInitializer>();

        services.AddUseCaseServices();
        services.AddCoreServices();
    }

    private static void ConfigureEfCore(IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlite("Data Source=:memory:");
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(EfReadRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddScoped<IDataQueryService, DataQueryService>();
    }
}