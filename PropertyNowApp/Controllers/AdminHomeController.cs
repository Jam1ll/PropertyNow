using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyNow.Core.Application.Interfaces;
using PropertyNow.Core.Application.ViewModels.Admin;
using PropertyNow.Core.Application.ViewModels.Property;
using PropertyNow.Core.Application.ViewModels.User;
using PropertyNow.Core.Domain.Common.Enums;

namespace PropertyNow.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly IAccountServiceForWebApp _accountServiceForWebApp;
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public AdminHomeController(IAccountServiceForWebApp accountServiceForWebApp, IPropertyService propertyService, IMapper mapper)
        {
            _mapper = mapper;
            _propertyService = propertyService;
            _accountServiceForWebApp = accountServiceForWebApp;
        }

        public async Task<IActionResult> Index()
        {
            var properties = _mapper.Map<List<PropertyViewModel>>(await _propertyService.GetAllWithInclude());
            var agents = _mapper.Map<List<UserViewModel>>(await _accountServiceForWebApp.GetAllUserByRole(Roles.Agent.ToString()));
            var clients = _mapper.Map<List<UserViewModel>>(await _accountServiceForWebApp.GetAllUserByRole(Roles.Client.ToString()));
            var developers = _mapper.Map<List<UserViewModel>>(await _accountServiceForWebApp.GetAllUserByRole(Roles.Developer.ToString()));

            var dashboard = new AdminDashboardViewModel
            {
                Properties = properties,
                Agents = agents,
                Clients = clients,
                Developers = developers
            };

            return View(dashboard);  
        }
    }
}