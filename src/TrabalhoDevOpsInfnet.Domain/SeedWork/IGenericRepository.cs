namespace TrabalhoDevOpsInfnet.Domain.SeedWork
{
    public interface IGenericRepository<TEntity> : IRepository where TEntity : Entity
    {
        public Task Insert(TEntity aggregate, CancellationToken cancellationToken);

        public Task<TEntity> Get(Guid id, CancellationToken cancellationToken);

        public Task Delete(TEntity aggregate, CancellationToken cancellationToken);

        public Task Update(TEntity aggregate, CancellationToken cancellationToken);
    }
}
