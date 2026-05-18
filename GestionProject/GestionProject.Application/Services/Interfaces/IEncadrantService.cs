using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IEncadrantService
    {
        Task<IEnumerable<EncadrantDto>> GetAllEncadrantsAsync();
        Task<EncadrantDto?> GetEncadrantByIdAsync(int id);
        Task<IEnumerable<EncadrantDto>> GetEncadrantsByTypeAsync(string type);
        Task<EncadrantDto> CreateEncadrantAsync(CreateEncadrantDto dto);
        Task UpdateEncadrantAsync(UpdateEncadrantDto dto);
        Task DeleteEncadrantAsync(int id);
    }
}
