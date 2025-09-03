using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;
using PropertyNow.Infrastructure.Persistence.Contexts;

namespace PropertyNow.Infrastructure.Persistence.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly PropertyNowContext _context;

        public MessageRepository(PropertyNowContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<List<Message>> GetMessagesByPropertyAndUsersAsync(int propertyId, string clientId, string agentId)
        {
            return await _context.Messages
                .Where(m => m.PropertyId == propertyId &&
                           ((m.SenderId == clientId && m.ReceiverId == agentId) ||
                            (m.SenderId == agentId && m.ReceiverId == clientId)))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<List<Message>> GetMessagesByPropertyAndAgentAsync(int propertyId, string agentId)
        {
            return await _context.Messages
                .Where(m => m.PropertyId == propertyId &&
                           (m.SenderId == agentId || m.ReceiverId == agentId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByPropertyAsync(int propertyId)
        {
            return await _context.Messages
                .Where(m => m.PropertyId == propertyId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
    }
}
