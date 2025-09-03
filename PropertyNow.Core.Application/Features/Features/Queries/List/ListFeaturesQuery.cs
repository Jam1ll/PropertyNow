using AutoMapper;
using MediatR;
using PropertyNow.Core.Application.DTOs.Feature;
using PropertyNow.Core.Application.Exceptions;
using PropertyNow.Core.Domain.Interfaces;
using System.Net;

namespace PropertyNow.Core.Application.Features.Features.Queries.List
{
    /// <summary>
    /// Query para listar todas las mejoras registradas.
    /// </summary>
    public class ListFeaturesQuery : IRequest<IList<FeatureDTO>> { }

    public class ListFeaturesQueryHandler : IRequestHandler<ListFeaturesQuery, IList<FeatureDTO>>
    {
        private readonly IFeatureRepository _repository;
        private readonly IMapper _mapper;

        public ListFeaturesQueryHandler(IFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<FeatureDTO>> Handle(ListFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllFeaturesAsync(cancellationToken);
            if (features == null || !features.Any())
                throw new ApiException("No features found", (int)HttpStatusCode.NotFound);

            return _mapper.Map<List<FeatureDTO>>(features);
        }
    }
}
