using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;
using PropertyNow.Infrastructure.Persistence.Contexts;

namespace PropertyNow.Infrastructure.Persistence.Repositories
{
    public class PropertyTypeRepository : GenericRepository<PropertyType>, IPropertyTypeRepository
    {
        private readonly PropertyNowContext _context;

        public PropertyTypeRepository(PropertyNowContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PropertyType?> GetByIdAsync(int id)
        {
            // Si necesitas las propiedades relacionadas (para contar o para validaciones), 
            // descomenta el Include. Si no, FindAsync es más barato.
            return await _context.PropertyTypes
                                 //.Include(pt => pt.Properties) // descomenta si necesitas las propiedades
                                 .FirstOrDefaultAsync(pt => pt.Id == id);
        }

        public IQueryable<PropertyType> GetAllQuery()
        {
            return _context.PropertyTypes.AsNoTracking();
        }
    }
}