using PropertyNow.Core.Domain.Common.Enums;

namespace PropertyNow.Core.Application.ViewModels.Client
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ClientId { get; set; }
        public string ClientUsername { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public OfferStatus Status { get; set; }
    }

}
