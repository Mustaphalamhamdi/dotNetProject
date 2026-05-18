using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class SeanceService : ISeanceService
    {
        private readonly ISeanceRepository _seanceRepository;
        private readonly IMapper _mapper;

        public SeanceService(ISeanceRepository seanceRepository, IMapper mapper)
        {
            _seanceRepository = seanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeanceDto>> GetAllSeancesAsync()
        {
            var seances = await _seanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SeanceDto>>(seances);
        }

        public async Task<SeanceDto?> GetSeanceByIdAsync(int id)
        {
            var seance = await _seanceRepository.GetByIdAsync(id);
            return seance == null ? null : _mapper.Map<SeanceDto>(seance);
        }

        public async Task<IEnumerable<SeanceDto>> GetSeancesByProjetAsync(int projetId)
        {
            var seances = await _seanceRepository.GetSeancesByProjetAsync(projetId);
            return _mapper.Map<IEnumerable<SeanceDto>>(seances);
        }

        public async Task<IEnumerable<SeanceDto>> GetSeancesByEncadrantAsync(int encadrantId)
        {
            var seances = await _seanceRepository.GetSeancesByEncadrantAsync(encadrantId);
            return _mapper.Map<IEnumerable<SeanceDto>>(seances);
        }

        public async Task<SeanceDto> CreateSeanceAsync(CreateSeanceDto dto)
        {
            var seance = _mapper.Map<Seance>(dto);
            await _seanceRepository.AddAsync(seance);
            await _seanceRepository.SaveChangesAsync();
            return _mapper.Map<SeanceDto>(seance);
        }

        public async Task UpdateSeanceAsync(UpdateSeanceDto dto)
        {
            var seance = await _seanceRepository.GetByIdAsync(dto.Id);
            if (seance == null) throw new KeyNotFoundException($"Seance with Id {dto.Id} not found.");
            _mapper.Map(dto, seance);
            _seanceRepository.Update(seance);
            await _seanceRepository.SaveChangesAsync();
        }

        public async Task DeleteSeanceAsync(int id)
        {
            var seance = await _seanceRepository.GetByIdAsync(id);
            if (seance == null) throw new KeyNotFoundException($"Seance with Id {id} not found.");
            _seanceRepository.Delete(seance);
            await _seanceRepository.SaveChangesAsync();
        }
    }
}
