using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;
using PropertyNow.Infrastructure.Persistence.Contexts;

namespace PropertyNow.Infrastructure.Persistence.Repositories
{
    public class SalesTypeRepository : GenericRepository<SalesType>, ISalesTypeRepository
    {
        public SalesTypeRepository(PropertyNowContext context) : base(context)
        {
        }
    }
}