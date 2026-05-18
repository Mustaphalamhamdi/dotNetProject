using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IProjetRepository : IRepository<Projet>
    {
        Task<IEnumerable<Projet>> GetProjetsWithDetailsAsync();
        Task<Projet?> GetProjetWithDetailsAsync(int id);
        Task<IEnumerable<Projet>> GetProjetsByEtudiantAsync(int etudiantId);
        Task<IEnumerable<Projet>> GetProjetsByEncadrantAsync(int encadrantId);
    }
}
