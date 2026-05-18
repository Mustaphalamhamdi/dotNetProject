using GestionProject.Domain.Entities;

namespace GestionProject.Domain.Interfaces
{
    public interface IMembreJuryRepository : IRepository<MembreJury>
    {
        Task<MembreJury?> GetMembreJuryWithSoutenancesAsync(int id);
    }
}
