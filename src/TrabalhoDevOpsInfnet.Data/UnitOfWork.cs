using TrabalhoDevOpsInfnet.Domain.SeedWork;

namespace TrabalhoDevOpsInfnet.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrabalhoDevOpsDbContext _context;

        public UnitOfWork(TrabalhoDevOpsDbContext context)
            => _context = context;

        public async Task Commit(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync();
        

        public Task Rollback(CancellationToken cancellationToken)
            => throw new NotImplementedException();
        
    }
}
