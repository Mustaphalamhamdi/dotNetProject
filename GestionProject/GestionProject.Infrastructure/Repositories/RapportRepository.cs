using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class RapportRepository : Repository<Rapport>, IRapportRepository
    {
        public RapportRepository(GestionDbContext context) : base(context) { }

        public async Task<IEnumerable<Rapport>> GetRapportsByProjetAsync(int projetId)
        {
            return await _dbSet
                .Include(r => r.Feedbacks)
                .Where(r => r.ProjetId == projetId)
                .OrderByDescending(r => r.DateSoumission)
                .ToListAsync();
        }

        public async Task<Rapport?> GetRapportWithFeedbacksAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Feedbacks)
                    .ThenInclude(f => f.Encadrant)
                .Include(r => r.Projet)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
