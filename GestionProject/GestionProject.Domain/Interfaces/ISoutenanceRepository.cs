using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface ISoutenanceRepository : IRepository<Soutenance>
    {
        Task<Soutenance?> GetSoutenanceWithDetailsAsync(int id);
        Task<Soutenance?> GetSoutenanceByProjetAsync(int projetId);
    }
}
