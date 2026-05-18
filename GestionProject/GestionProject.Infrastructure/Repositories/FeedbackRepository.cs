using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(GestionDbContext context) : base(context) { }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByRapportAsync(int rapportId)
        {
            return await _dbSet
                .Include(f => f.Encadrant)
                .Where(f => f.RapportId == rapportId)
                .OrderByDescending(f => f.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByEncadrantAsync(int encadrantId)
        {
            return await _dbSet
                .Include(f => f.Rapport)
                    .ThenInclude(r => r.Projet)
                .Where(f => f.EncadrantId == encadrantId)
                .OrderByDescending(f => f.Date)
                .ToListAsync();
        }
    }
}
