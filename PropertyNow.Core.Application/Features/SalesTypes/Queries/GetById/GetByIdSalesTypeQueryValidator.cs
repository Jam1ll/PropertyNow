using FluentValidation;
using PropertyNow.Core.Application.Features.SalesTypes.Queries.GetById;

namespace PropertyNow.Core.Application.Features.SalesType.Queries.GetById
{
    public class GetByIdSalesTypeQueryValidator : AbstractValidator<GetByIdSalesTypeQuery>
    {
        public GetByIdSalesTypeQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("El Id debe ser mayor que 0.");
        }
    }
}
