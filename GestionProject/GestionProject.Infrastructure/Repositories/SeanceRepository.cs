using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class SeanceRepository : Repository<Seance>, ISeanceRepository
    {
        public SeanceRepository(GestionDbContext context) : base(context) { }

        public async Task<IEnumerable<Seance>> GetSeancesByProjetAsync(int projetId)
        {
            return await _dbSet
                .Include(s => s.Encadrant)
                .Where(s => s.ProjetId == projetId)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Seance>> GetSeancesByEncadrantAsync(int encadrantId)
        {
            return await _dbSet
                .Include(s => s.Projet)
                .Where(s => s.EncadrantId == encadrantId)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }
    }
}
