using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Application.DTOs.Feature;
using PropertyNow.Core.Application.DTOs.Property;
using PropertyNow.Core.Application.DTOs.PropertyType;
using PropertyNow.Core.Application.DTOs.SalesType;
using PropertyNow.Core.Domain.Interfaces;

namespace PropertyNow.Core.Application.Features.Properties.Queries.List
{
    /// <summary>
    /// Query parameters for retrieving all properties
    /// </summary>
    public class ListPropertiesQuery : IRequest<IList<PropertyForApiDTO>>
    {
    }

    public class ListPropertiesQueryHandler : IRequestHandler<ListPropertiesQuery, IList<PropertyForApiDTO>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public ListPropertiesQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IList<PropertyForApiDTO>> Handle(ListPropertiesQuery query, CancellationToken cancellationToken)
        {
            var listEntitiesQuery = _propertyRepository.GetAllQueryWithInclude(["PropertyType", "SalesType", "Features"]);

            var listEntityDtos = await listEntitiesQuery.Select(s =>

                new PropertyForApiDTO()
                {
                    Id = s.Id,
                    Code = s.Code,
                    PropertyType = s.PropertyType != null ? _mapper.Map<PropertyTypeDTO>(s.PropertyType) : null,
                    SalesType = s.SalesType != null ? _mapper.Map<SalesTypeDTO>(s.SalesType) : null,
                    Price = s.Price,
                    SizeInMeters = s.SizeInMeters,
                    NumberOfRooms = s.NumberOfRooms,
                    NumberOfBathrooms = s.NumberOfBathrooms,
                    Description = s.Description,
                    Features = s.Features.Select(f => _mapper.Map<FeatureDTO>(f)).ToList(),
                    AgentName = s.AgentName,
                    AgentId = s.AgentId,
                    State = s.State,
                }
            ).ToListAsync();

            return listEntityDtos;
        }
    }
}
