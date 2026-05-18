using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface ISoutenanceService
    {
        Task<IEnumerable<SoutenanceDto>> GetAllSoutenancesAsync();
        Task<SoutenanceDto?> GetSoutenanceByIdAsync(int id);
        Task<SoutenanceDto?> GetSoutenanceByProjetAsync(int projetId);
        Task<SoutenanceDto> CreateSoutenanceAsync(CreateSoutenanceDto dto);
        Task UpdateSoutenanceAsync(UpdateSoutenanceDto dto);
        Task DeleteSoutenanceAsync(int id);
    }
}
