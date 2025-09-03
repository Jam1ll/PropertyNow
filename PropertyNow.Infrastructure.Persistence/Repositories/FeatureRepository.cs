using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;
using PropertyNow.Infrastructure.Persistence.Contexts;

namespace PropertyNow.Infrastructure.Persistence.Repositories
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        private readonly RealEstateContext _dbContext;

        public FeatureRepository(RealEstateContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feature?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Feature>()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Feature>> GetAllFeaturesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Feature>()
                .ToListAsync(cancellationToken);
        }
    }
}
