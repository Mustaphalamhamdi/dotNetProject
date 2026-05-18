using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface ISeanceRepository : IRepository<Seance>
    {
        Task<IEnumerable<Seance>> GetSeancesByProjetAsync(int projetId);
        Task<IEnumerable<Seance>> GetSeancesByEncadrantAsync(int encadrantId);
    }
}
