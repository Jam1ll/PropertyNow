using PropertyNow.Core.Application.DTOs.Client;
using System;

namespace PropertyNow.Core.Application.DTOs.Offer
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public string ClientId { get; set; } = null!;
        public int PropertyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;

        // Opcional: Datos del cliente para mostrar en la vista si se desea
        public ClientDTO? Client { get; set; }
    }
}
