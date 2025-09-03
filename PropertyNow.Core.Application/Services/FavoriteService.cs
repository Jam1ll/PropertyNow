using AutoMapper;
using PropertyNow.Core.Application.DTOs.Property;
using PropertyNow.Core.Application.ViewModels.Client;
using PropertyNow.Core.Application.ViewModels.Property;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Domain.Interfaces;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoritePropertyRepository _favoriteRepo;
    private readonly IMapper _mapper;
    private readonly IPropertyRepository _propertyRepo;

    public FavoriteService(IFavoritePropertyRepository favoriteRepo, IPropertyRepository propertyRepo, IMapper mapper)
    {
        _favoriteRepo = favoriteRepo;
        _propertyRepo = propertyRepo;
        _mapper = mapper;
    }

    public async Task ToggleFavoriteAsync(string userId, int propertyId)
    {
        var favorite = await _favoriteRepo.GetByUserAndPropertyAsync(userId, propertyId);
        if (favorite != null)
        {
            await _favoriteRepo.DeleteAsync(favorite);
        }
        else
        {
            await _favoriteRepo.AddAsync(new FavoriteProperty
            {
                ClientId = userId,
                PropertyId = propertyId
            });
        }
    }

    public async Task<List<PropertyViewModel>> GetFavoritePropertiesByUserAsync(string userId)
    {
        var favorites = await _favoriteRepo.GetAllByUserIdAsync(userId);
        var properties = favorites.Select(f => f.Property).ToList();
        var dtos = _mapper.Map<List<PropertyDTO>>(properties);
        return _mapper.Map<List<PropertyViewModel>>(dtos);
    }

    public async Task<bool> IsFavoriteAsync(string userId, int propertyId)
    {
        var favorite = await _favoriteRepo.GetByUserAndPropertyAsync(userId, propertyId);
        return favorite != null;
    }
}

