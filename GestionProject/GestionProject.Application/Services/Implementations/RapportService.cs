using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class RapportService : IRapportService
    {
        private readonly IRapportRepository _rapportRepository;
        private readonly IMapper _mapper;

        public RapportService(IRapportRepository rapportRepository, IMapper mapper)
        {
            _rapportRepository = rapportRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RapportDto>> GetAllRapportsAsync()
        {
            var rapports = await _rapportRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RapportDto>>(rapports);
        }

        public async Task<RapportDto?> GetRapportByIdAsync(int id)
        {
            var rapport = await _rapportRepository.GetRapportWithFeedbacksAsync(id);
            return rapport == null ? null : _mapper.Map<RapportDto>(rapport);
        }

        public async Task<IEnumerable<RapportDto>> GetRapportsByProjetAsync(int projetId)
        {
            var rapports = await _rapportRepository.GetRapportsByProjetAsync(projetId);
            return _mapper.Map<IEnumerable<RapportDto>>(rapports);
        }

        public async Task<RapportDto> CreateRapportAsync(CreateRapportDto dto)
        {
            var rapport = _mapper.Map<Rapport>(dto);
            rapport.DateSoumission = DateTime.UtcNow;
            await _rapportRepository.AddAsync(rapport);
            await _rapportRepository.SaveChangesAsync();
            return _mapper.Map<RapportDto>(rapport);
        }

        public async Task UpdateRapportAsync(UpdateRapportDto dto)
        {
            var rapport = await _rapportRepository.GetByIdAsync(dto.Id);
            if (rapport == null) throw new KeyNotFoundException($"Rapport with Id {dto.Id} not found.");
            _mapper.Map(dto, rapport);
            _rapportRepository.Update(rapport);
            await _rapportRepository.SaveChangesAsync();
        }

        public async Task DeleteRapportAsync(int id)
        {
            var rapport = await _rapportRepository.GetByIdAsync(id);
            if (rapport == null) throw new KeyNotFoundException($"Rapport with Id {id} not found.");
            _rapportRepository.Delete(rapport);
            await _rapportRepository.SaveChangesAsync();
        }
    }
}
