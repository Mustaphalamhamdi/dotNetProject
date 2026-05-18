using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class MembreJuryRepository : Repository<MembreJury>, IMembreJuryRepository
    {
        public MembreJuryRepository(GestionDbContext context) : base(context) { }

        public async Task<MembreJury?> GetMembreJuryWithSoutenancesAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Soutenances)
                    .ThenInclude(s => s.Projet)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
