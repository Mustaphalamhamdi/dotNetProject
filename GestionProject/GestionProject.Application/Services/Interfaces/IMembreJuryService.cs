using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IMembreJuryService
    {
        Task<IEnumerable<MembreJuryDto>> GetAllMembresJuryAsync();
        Task<MembreJuryDto?> GetMembreJuryByIdAsync(int id);
        Task<MembreJuryDto> CreateMembreJuryAsync(CreateMembreJuryDto dto);
        Task UpdateMembreJuryAsync(UpdateMembreJuryDto dto);
        Task DeleteMembreJuryAsync(int id);
    }
}
