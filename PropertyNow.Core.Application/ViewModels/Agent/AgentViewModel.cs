using PropertyNow.Core.Application.DTOs.Property;
using PropertyNow.Core.Application.ViewModels.Property;

namespace PropertyNow.Core.Application.ViewModels.Agent
{
    public class AgentViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required string Email { get; set; }
        public List<PropertyViewModel>? Properties { get; set; }
    }
}
