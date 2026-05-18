using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository _etudiantRepository;
        private readonly IMapper _mapper;

        public EtudiantService(IEtudiantRepository etudiantRepository, IMapper mapper)
        {
            _etudiantRepository = etudiantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EtudiantDto>> GetAllEtudiantsAsync()
        {
            var etudiants = await _etudiantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EtudiantDto>>(etudiants);
        }

        public async Task<EtudiantDto?> GetEtudiantByIdAsync(int id)
        {
            var etudiant = await _etudiantRepository.GetByIdAsync(id);
            return etudiant == null ? null : _mapper.Map<EtudiantDto>(etudiant);
        }

        public async Task<EtudiantDto> CreateEtudiantAsync(CreateEtudiantDto dto)
        {
            var etudiant = _mapper.Map<Etudiant>(dto);
            await _etudiantRepository.AddAsync(etudiant);
            await _etudiantRepository.SaveChangesAsync();
            return _mapper.Map<EtudiantDto>(etudiant);
        }

        public async Task UpdateEtudiantAsync(UpdateEtudiantDto dto)
        {
            var etudiant = await _etudiantRepository.GetByIdAsync(dto.Id);
            if (etudiant == null) throw new KeyNotFoundException($"Etudiant with Id {dto.Id} not found.");
            _mapper.Map(dto, etudiant);
            _etudiantRepository.Update(etudiant);
            await _etudiantRepository.SaveChangesAsync();
        }

        public async Task DeleteEtudiantAsync(int id)
        {
            var etudiant = await _etudiantRepository.GetByIdAsync(id);
            if (etudiant == null) throw new KeyNotFoundException($"Etudiant with Id {id} not found.");
            _etudiantRepository.Delete(etudiant);
            await _etudiantRepository.SaveChangesAsync();
        }
    }
}
