using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class SoutenanceRepository : Repository<Soutenance>, ISoutenanceRepository
    {
        public SoutenanceRepository(GestionDbContext context) : base(context) { }

        public async Task<Soutenance?> GetSoutenanceWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Projet)
                    .ThenInclude(p => p.Etudiant)
                .Include(s => s.MembresJury)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Soutenance?> GetSoutenanceByProjetAsync(int projetId)
        {
            return await _dbSet
                .Include(s => s.MembresJury)
                .FirstOrDefaultAsync(s => s.ProjetId == projetId);
        }
    }
}
