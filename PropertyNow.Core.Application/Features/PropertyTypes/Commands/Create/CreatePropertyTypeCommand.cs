using AutoMapper;
using MediatR;
using PropertyNow.Core.Application.DTOs.PropertyType;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PropertyNow.Core.Application.Features.PropertyTypes.Commands.Create
{
    /// <summary>
    /// Comando para crear un nuevo tipo de propiedad.
    /// </summary>
    public class CreatePropertyTypeCommand : IRequest<int>
    {
        /// <summary>
        /// Nombre del tipo de propiedad.
        /// </summary>
        [SwaggerSchema(Description = "Nombre del tipo de propiedad", Nullable = false)]
        public required string Name { get; set; }

        /// <summary>
        /// Descripción del tipo de propiedad.
        /// </summary>
        [SwaggerSchema(Description = "Descripción del tipo de propiedad", Nullable = false)]
        public required string Description { get; set; }
    }

    public class CreatePropertyTypeCommandHandler : IRequestHandler<CreatePropertyTypeCommand, int>
    {
        private readonly IPropertyTypeRepository _repository;
        private readonly IMapper _mapper;

        public CreatePropertyTypeCommandHandler(IPropertyTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PropertyType>(request);
            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
