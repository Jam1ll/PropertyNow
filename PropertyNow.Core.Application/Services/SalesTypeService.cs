using AutoMapper;
using PropertyNow.Core.Application.DTOs.SalesType;
using PropertyNow.Core.Application.Interfaces;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;

namespace PropertyNow.Core.Application.Services
{
    public class SalesTypeService : GenericService<SalesType, SalesTypeDTO>, ISalesTypeService
    {
        public SalesTypeService(IGenericRepository<SalesType> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
