using PropertyNow.Core.Domain.Entities;

namespace PropertyNow.Core.Domain.Interfaces
{
    public interface IFeatureRepository : IGenericRepository<Feature>
    {
        Task<Feature?> GetByIdAsync(int id);
        Task<List<Feature>> GetAllFeaturesAsync(CancellationToken cancellationToken);
    }
}
