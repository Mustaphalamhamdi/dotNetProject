using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class EncadrantService : IEncadrantService
    {
        private readonly IEncadrantRepository _encadrantRepository;
        private readonly IMapper _mapper;

        public EncadrantService(IEncadrantRepository encadrantRepository, IMapper mapper)
        {
            _encadrantRepository = encadrantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EncadrantDto>> GetAllEncadrantsAsync()
        {
            var encadrants = await _encadrantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EncadrantDto>>(encadrants);
        }

        public async Task<EncadrantDto?> GetEncadrantByIdAsync(int id)
        {
            var encadrant = await _encadrantRepository.GetByIdAsync(id);
            return encadrant == null ? null : _mapper.Map<EncadrantDto>(encadrant);
        }

        public async Task<IEnumerable<EncadrantDto>> GetEncadrantsByTypeAsync(string type)
        {
            var encadrants = await _encadrantRepository.GetEncadrantsByTypeAsync(type);
            return _mapper.Map<IEnumerable<EncadrantDto>>(encadrants);
        }

        public async Task<EncadrantDto> CreateEncadrantAsync(CreateEncadrantDto dto)
        {
            var encadrant = _mapper.Map<Encadrant>(dto);
            await _encadrantRepository.AddAsync(encadrant);
            await _encadrantRepository.SaveChangesAsync();
            return _mapper.Map<EncadrantDto>(encadrant);
        }

        public async Task UpdateEncadrantAsync(UpdateEncadrantDto dto)
        {
            var encadrant = await _encadrantRepository.GetByIdAsync(dto.Id);
            if (encadrant == null) throw new KeyNotFoundException($"Encadrant with Id {dto.Id} not found.");
            _mapper.Map(dto, encadrant);
            _encadrantRepository.Update(encadrant);
            await _encadrantRepository.SaveChangesAsync();
        }

        public async Task DeleteEncadrantAsync(int id)
        {
            var encadrant = await _encadrantRepository.GetByIdAsync(id);
            if (encadrant == null) throw new KeyNotFoundException($"Encadrant with Id {id} not found.");
            _encadrantRepository.Delete(encadrant);
            await _encadrantRepository.SaveChangesAsync();
        }
    }
}
