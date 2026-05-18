using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class ProjetRepository : Repository<Projet>, IProjetRepository
    {
        public ProjetRepository(GestionDbContext context) : base(context) { }

        public async Task<IEnumerable<Projet>> GetProjetsWithDetailsAsync()
        {
            return await _dbSet
                .Include(p => p.Etudiant)
                .Include(p => p.EncadrantAcademique)
                .Include(p => p.EncadrantProfessionnel)
                .Include(p => p.Rapports)
                .Include(p => p.Seances)
                .Include(p => p.Soutenance)
                .ToListAsync();
        }

        public async Task<Projet?> GetProjetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Etudiant)
                .Include(p => p.EncadrantAcademique)
                .Include(p => p.EncadrantProfessionnel)
                .Include(p => p.Rapports)
                .Include(p => p.Seances)
                .Include(p => p.Soutenance)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Projet>> GetProjetsByEtudiantAsync(int etudiantId)
        {
            return await _dbSet
                .Include(p => p.EncadrantAcademique)
                .Where(p => p.EtudiantId == etudiantId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Projet>> GetProjetsByEncadrantAsync(int encadrantId)
        {
            return await _dbSet
                .Include(p => p.Etudiant)
                .Where(p => p.EncadrantAcademiqueId == encadrantId || p.EncadrantProfessionnelId == encadrantId)
                .ToListAsync();
        }
    }
}
