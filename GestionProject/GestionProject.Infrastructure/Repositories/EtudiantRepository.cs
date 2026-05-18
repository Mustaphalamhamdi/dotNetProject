using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;
using GestionProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProject.Infrastructure.Repositories
{
    public class EtudiantRepository : Repository<Etudiant>, IEtudiantRepository
    {
        public EtudiantRepository(GestionDbContext context) : base(context) { }

        public async Task<Etudiant?> GetEtudiantWithProjetsAsync(int id)
        {
            return await _dbSet
                .Include(e => e.Projets)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
