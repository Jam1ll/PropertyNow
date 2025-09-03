using AutoMapper;
using PropertyNow.Core.Application.DTOs.PropertyType;
using PropertyNow.Core.Application.Interfaces;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;

namespace PropertyNow.Core.Application.Services
{
    public class PropertyTypeService : GenericService<PropertyType, PropertyTypeDTO>, IPropertyTypeService
    {
        public PropertyTypeService(IGenericRepository<PropertyType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
