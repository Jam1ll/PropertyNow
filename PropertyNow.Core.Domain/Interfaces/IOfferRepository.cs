using PropertyNow.Core.Domain.Entities;


namespace PropertyNow.Core.Domain.Interfaces
{
    public interface IOfferRepository : IGenericRepository<Offer>
    {
        Task<List<Offer>> GetAllAsync();
        Task<IEnumerable<Offer>> GetOffersByPropertyAsync(int propertyId);
        Task<Offer?> GetByIdAsync(int id);
        Task<List<Offer>> GetByPropertyAndClientAsync(int propertyId, string clientId);
        Task<List<Offer>> GetAllPendingByPropertyAsync(int propertyId, int excludeOfferId = 0);
    }
}
