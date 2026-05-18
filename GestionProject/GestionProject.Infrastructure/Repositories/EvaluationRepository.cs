using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository
    {
        public EvaluationRepository(GestionDbContext context) : base(context) { }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsBySoutenanceAsync(int soutenanceId)
        {
            return await _dbSet
                .Include(e => e.MembreJury)
                .Where(e => e.SoutenanceId == soutenanceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsByMembreJuryAsync(int membreJuryId)
        {
            return await _dbSet
                .Include(e => e.Soutenance)
                    .ThenInclude(s => s.Projet)
                .Where(e => e.MembreJuryId == membreJuryId)
                .ToListAsync();
        }
    }
}
