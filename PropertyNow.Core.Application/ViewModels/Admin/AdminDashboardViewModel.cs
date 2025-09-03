using PropertyNow.Core.Application.ViewModels.Agent;
using PropertyNow.Core.Application.ViewModels.Property;
using PropertyNow.Core.Application.ViewModels.User;

namespace PropertyNow.Core.Application.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public List<PropertyViewModel>? Properties { get; set; }
        public List<UserViewModel>? Agents { get; set; }
        public List<UserViewModel>? Clients { get; set; }
        public List<UserViewModel>? Developers { get; set; }
    }
}
