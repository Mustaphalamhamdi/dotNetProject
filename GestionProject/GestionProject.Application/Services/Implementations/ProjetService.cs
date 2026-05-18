using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class ProjetService : IProjetService
    {
        private readonly IProjetRepository _projetRepository;
        private readonly IMapper _mapper;

        public ProjetService(IProjetRepository projetRepository, IMapper mapper)
        {
            _projetRepository = projetRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjetDto>> GetAllProjetsAsync()
        {
            var projets = await _projetRepository.GetProjetsWithDetailsAsync();
            return _mapper.Map<IEnumerable<ProjetDto>>(projets);
        }

        public async Task<ProjetDto?> GetProjetByIdAsync(int id)
        {
            var projet = await _projetRepository.GetProjetWithDetailsAsync(id);
            return projet == null ? null : _mapper.Map<ProjetDto>(projet);
        }

        public async Task<IEnumerable<ProjetDto>> GetProjetsByEtudiantAsync(int etudiantId)
        {
            var projets = await _projetRepository.GetProjetsByEtudiantAsync(etudiantId);
            return _mapper.Map<IEnumerable<ProjetDto>>(projets);
        }

        public async Task<IEnumerable<ProjetDto>> GetProjetsByEncadrantAsync(int encadrantId)
        {
            var projets = await _projetRepository.GetProjetsByEncadrantAsync(encadrantId);
            return _mapper.Map<IEnumerable<ProjetDto>>(projets);
        }

        public async Task<ProjetDto> CreateProjetAsync(CreateProjetDto dto)
        {
            var projet = _mapper.Map<Projet>(dto);
            projet.Statut = "Proposé";
            await _projetRepository.AddAsync(projet);
            await _projetRepository.SaveChangesAsync();
            return _mapper.Map<ProjetDto>(projet);
        }

        public async Task UpdateProjetAsync(UpdateProjetDto dto)
        {
            var projet = await _projetRepository.GetByIdAsync(dto.Id);
            if (projet == null) throw new KeyNotFoundException($"Projet with Id {dto.Id} not found.");
            _mapper.Map(dto, projet);
            _projetRepository.Update(projet);
            await _projetRepository.SaveChangesAsync();
        }

        public async Task DeleteProjetAsync(int id)
        {
            var projet = await _projetRepository.GetByIdAsync(id);
            if (projet == null) throw new KeyNotFoundException($"Projet with Id {id} not found.");
            _projetRepository.Delete(projet);
            await _projetRepository.SaveChangesAsync();
        }
    }
}
