using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IEtudiantRepository : IRepository<Etudiant>
    {
        Task<Etudiant?> GetEtudiantWithProjetsAsync(int id);
    }
}
