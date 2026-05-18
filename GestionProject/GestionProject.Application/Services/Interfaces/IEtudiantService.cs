using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IEtudiantService
    {
        Task<IEnumerable<EtudiantDto>> GetAllEtudiantsAsync();
        Task<EtudiantDto?> GetEtudiantByIdAsync(int id);
        Task<EtudiantDto> CreateEtudiantAsync(CreateEtudiantDto dto);
        Task UpdateEtudiantAsync(UpdateEtudiantDto dto);
        Task DeleteEtudiantAsync(int id);
    }
}
