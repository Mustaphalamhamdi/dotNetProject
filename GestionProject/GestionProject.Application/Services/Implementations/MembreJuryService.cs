using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class MembreJuryService : IMembreJuryService
    {
        private readonly IMembreJuryRepository _membreJuryRepository;
        private readonly IMapper _mapper;

        public MembreJuryService(IMembreJuryRepository membreJuryRepository, IMapper mapper)
        {
            _membreJuryRepository = membreJuryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MembreJuryDto>> GetAllMembresJuryAsync()
        {
            var membres = await _membreJuryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MembreJuryDto>>(membres);
        }

        public async Task<MembreJuryDto?> GetMembreJuryByIdAsync(int id)
        {
            var membre = await _membreJuryRepository.GetByIdAsync(id);
            return membre == null ? null : _mapper.Map<MembreJuryDto>(membre);
        }

        public async Task<MembreJuryDto> CreateMembreJuryAsync(CreateMembreJuryDto dto)
        {
            var membre = _mapper.Map<MembreJury>(dto);
            await _membreJuryRepository.AddAsync(membre);
            await _membreJuryRepository.SaveChangesAsync();
            return _mapper.Map<MembreJuryDto>(membre);
        }

        public async Task UpdateMembreJuryAsync(UpdateMembreJuryDto dto)
        {
            var membre = await _membreJuryRepository.GetByIdAsync(dto.Id);
            if (membre == null) throw new KeyNotFoundException($"MembreJury with Id {dto.Id} not found.");
            _mapper.Map(dto, membre);
            _membreJuryRepository.Update(membre);
            await _membreJuryRepository.SaveChangesAsync();
        }

        public async Task DeleteMembreJuryAsync(int id)
        {
            var membre = await _membreJuryRepository.GetByIdAsync(id);
            if (membre == null) throw new KeyNotFoundException($"MembreJury with Id {id} not found.");
            _membreJuryRepository.Delete(membre);
            await _membreJuryRepository.SaveChangesAsync();
        }
    }
}
