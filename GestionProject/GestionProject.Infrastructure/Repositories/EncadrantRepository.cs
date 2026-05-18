using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class EncadrantRepository : Repository<Encadrant>, IEncadrantRepository
    {
        public EncadrantRepository(GestionDbContext context) : base(context) { }

        public async Task<Encadrant?> GetEncadrantWithProjetsAsync(int id)
        {
            return await _dbSet
                .Include(e => e.ProjetsEncadres)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Encadrant>> GetEncadrantsByTypeAsync(string type)
        {
            return await _dbSet
                .Where(e => e.Type == type)
                .ToListAsync();
        }
    }
}
