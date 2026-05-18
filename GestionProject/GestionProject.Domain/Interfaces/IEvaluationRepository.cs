using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IEvaluationRepository : IRepository<Evaluation>
    {
        Task<IEnumerable<Evaluation>> GetEvaluationsBySoutenanceAsync(int soutenanceId);
        Task<IEnumerable<Evaluation>> GetEvaluationsByMembreJuryAsync(int membreJuryId);
    }
}
