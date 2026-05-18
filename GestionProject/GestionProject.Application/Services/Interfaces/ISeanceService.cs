using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface ISeanceService
    {
        Task<IEnumerable<SeanceDto>> GetAllSeancesAsync();
        Task<SeanceDto?> GetSeanceByIdAsync(int id);
        Task<IEnumerable<SeanceDto>> GetSeancesByProjetAsync(int projetId);
        Task<IEnumerable<SeanceDto>> GetSeancesByEncadrantAsync(int encadrantId);
        Task<SeanceDto> CreateSeanceAsync(CreateSeanceDto dto);
        Task UpdateSeanceAsync(UpdateSeanceDto dto);
        Task DeleteSeanceAsync(int id);
    }
}
