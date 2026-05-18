using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IRapportRepository : IRepository<Rapport>
    {
        Task<IEnumerable<Rapport>> GetRapportsByProjetAsync(int projetId);
        Task<Rapport?> GetRapportWithFeedbacksAsync(int id);
    }
}
