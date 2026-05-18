using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<IEnumerable<Feedback>> GetFeedbacksByRapportAsync(int rapportId);
        Task<IEnumerable<Feedback>> GetFeedbacksByEncadrantAsync(int encadrantId);
    }
}
