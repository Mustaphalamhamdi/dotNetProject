using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IRapportService
    {
        Task<IEnumerable<RapportDto>> GetAllRapportsAsync();
        Task<RapportDto?> GetRapportByIdAsync(int id);
        Task<IEnumerable<RapportDto>> GetRapportsByProjetAsync(int projetId);
        Task<RapportDto> CreateRapportAsync(CreateRapportDto dto);
        Task UpdateRapportAsync(UpdateRapportDto dto);
        Task DeleteRapportAsync(int id);
    }
}
