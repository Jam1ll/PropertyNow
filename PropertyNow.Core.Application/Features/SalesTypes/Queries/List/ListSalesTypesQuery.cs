using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Application.DTOs.SalesType;
using PropertyNow.Core.Application.Exceptions;
using PropertyNow.Core.Domain.Interfaces;
using System.Net;

namespace PropertyNow.Core.Application.Features.SalesType.Queries.List
{
    public class ListSalesTypesQuery : IRequest<IList<SalesTypeDTO>> { }

    public class ListSalesTypesQueryHandler : IRequestHandler<ListSalesTypesQuery, IList<SalesTypeDTO>>
    {
        private readonly ISalesTypeRepository _repository;
        private readonly IMapper _mapper;

        public ListSalesTypesQueryHandler(ISalesTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<SalesTypeDTO>> Handle(ListSalesTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllQuery().ToListAsync(cancellationToken);
            if (list == null || !list.Any())
                throw new ApiException("No sales types found", (int)HttpStatusCode.NotFound);

            return _mapper.Map<List<SalesTypeDTO>>(list);
        }
    }
}
