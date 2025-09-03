using AutoMapper;
using MediatR;
using PropertyNow.Core.Application.DTOs.PropertyType;
using PropertyNow.Core.Application.Exceptions;
using PropertyNow.Core.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PropertyNow.Core.Application.Features.PropertyTypes.Queries.GetById
{
    public class GetByIdPropertyTypeQuery : IRequest<PropertyTypeDTO>
    {
        [SwaggerSchema(Description = "Id del tipo de propiedad a consultar", Nullable = false)]
        public int Id { get; set; }
    }

    public class GetByIdPropertyTypeQueryHandler : IRequestHandler<GetByIdPropertyTypeQuery, PropertyTypeDTO>
    {
        private readonly IPropertyTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdPropertyTypeQueryHandler(IPropertyTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PropertyTypeDTO> Handle(GetByIdPropertyTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new ApiException("PropertyType not found with this id", (int)HttpStatusCode.NotFound);

            return _mapper.Map<PropertyTypeDTO>(entity);
        }
    }
}
