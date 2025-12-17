using Microsoft.EntityFrameworkCore;
using Zhaoxi.Zhihu.SharedKernel.Domain;
using Zhaoxi.Zhihu.SharedKernel.Repository;

namespace Zhaoxi.Zhihu.Infrastructure.Data.Repositories;

public class EfRepository<T>(AppDbContext dbContext) : EfReadRepository<T>(dbContext), IRepository<T>
    where T : class, IEntity, IAggregateRoot
{
    private readonly AppDbContext _dbContext = dbContext;

    public T Add(T entity)
    {
        DbSet.Add(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}