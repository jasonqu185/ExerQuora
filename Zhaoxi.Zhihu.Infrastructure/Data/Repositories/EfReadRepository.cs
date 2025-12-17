using Microsoft.EntityFrameworkCore;
using Zhaoxi.Zhihu.SharedKernel.Domain;
using Zhaoxi.Zhihu.SharedKernel.Repository;
using Zhaoxi.Zhihu.SharedKernel.Specification;

namespace Zhaoxi.Zhihu.Infrastructure.Data.Repositories;

public class EfReadRepository<T>(AppDbContext dbContext) : IReadRepository<T> where T : class, IEntity
{
    protected readonly DbSet<T> DbSet = dbContext.Set<T>();

    public async Task<T?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
    }

    public async Task<List<T>> GetListAsync(ISpecification<T>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(DbSet, specification).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetSingleOrDefaultAsync(ISpecification<T>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(DbSet, specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(DbSet, specification).CountAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(ISpecification<T>? specification = null,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.GetQuery(DbSet, specification).AnyAsync(cancellationToken);
    }
}