using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IProjetService
    {
        Task<IEnumerable<ProjetDto>> GetAllProjetsAsync();
        Task<ProjetDto?> GetProjetByIdAsync(int id);
        Task<IEnumerable<ProjetDto>> GetProjetsByEtudiantAsync(int etudiantId);
        Task<IEnumerable<ProjetDto>> GetProjetsByEncadrantAsync(int encadrantId);
        Task<ProjetDto> CreateProjetAsync(CreateProjetDto dto);
        Task UpdateProjetAsync(UpdateProjetDto dto);
        Task DeleteProjetAsync(int id);
    }
}
