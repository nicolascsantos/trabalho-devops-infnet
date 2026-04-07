using Microsoft.EntityFrameworkCore;

namespace TrabalhoDevOpsInfnet.Data
{
    public class TrabalhoDevOpsDbContext : DbContext
    {
        public TrabalhoDevOpsDbContext(DbContextOptions options) : base(options) {}
    }
}
