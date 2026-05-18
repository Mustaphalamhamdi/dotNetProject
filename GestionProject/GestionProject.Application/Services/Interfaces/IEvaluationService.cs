using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IEvaluationService
    {
        Task<IEnumerable<EvaluationDto>> GetAllEvaluationsAsync();
        Task<EvaluationDto?> GetEvaluationByIdAsync(int id);
        Task<IEnumerable<EvaluationDto>> GetEvaluationsBySoutenanceAsync(int soutenanceId);
        Task<IEnumerable<EvaluationDto>> GetEvaluationsByMembreJuryAsync(int membreJuryId);
        Task<EvaluationDto> CreateEvaluationAsync(CreateEvaluationDto dto);
        Task UpdateEvaluationAsync(UpdateEvaluationDto dto);
        Task DeleteEvaluationAsync(int id);
    }
}
