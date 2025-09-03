using PropertyNow.Core.Domain.Entities;

namespace PropertyNow.Core.Domain.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<List<Message>> GetAllAsync();
        Task<IEnumerable<Message>> GetMessagesByPropertyAsync(int propertyId);
        Task<List<Message>> GetMessagesByPropertyAndUsersAsync(int propertyId, string clientId, string agentId);
        Task<List<Message>> GetMessagesByPropertyAndAgentAsync(int propertyId, string agentId);
    }
}
