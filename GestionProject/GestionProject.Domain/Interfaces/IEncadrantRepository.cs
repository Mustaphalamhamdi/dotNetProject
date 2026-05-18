using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IEncadrantRepository : IRepository<Encadrant>
    {
        Task<Encadrant?> GetEncadrantWithProjetsAsync(int id);
        Task<IEnumerable<Encadrant>> GetEncadrantsByTypeAsync(string type);
    }
}
