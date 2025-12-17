using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Zhaoxi.Zhihu.Infrastructure.Data;
using Zhaoxi.Zhihu.UseCases.Common.Interfaces;

namespace Zhaoxi.Zhihu.UseCases.FunctionalTests;

public abstract class TestBase
{
    protected TestBase(IServiceProvider serviceProvider)
    {
        serviceProvider.GetRequiredService<DbInitializer>().InitialCreate();

        Sender = serviceProvider.GetRequiredService<ISender>();

        CurrentUser = serviceProvider.GetRequiredService<IUser>();

        DbContext = serviceProvider.GetRequiredService<AppDbContext>();
    }

    public ISender Sender { get; private set; }

    public IUser CurrentUser { get; private set; }

    public AppDbContext DbContext { get; private set; }
}