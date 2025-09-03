using AutoMapper;
using PropertyNow.Core.Application.DTOs.Feature;
using PropertyNow.Core.Application.Interfaces;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;

namespace PropertyNow.Core.Application.Services
{
    public class FeatureService : GenericService<Feature, FeatureDTO>, IFeatureService
    {
        public FeatureService(IGenericRepository<Feature> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
