using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class SoutenanceService : ISoutenanceService
    {
        private readonly ISoutenanceRepository _soutenanceRepository;
        private readonly IMembreJuryRepository _membreJuryRepository;
        private readonly IMapper _mapper;

        public SoutenanceService(ISoutenanceRepository soutenanceRepository, IMembreJuryRepository membreJuryRepository, IMapper mapper)
        {
            _soutenanceRepository = soutenanceRepository;
            _membreJuryRepository = membreJuryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SoutenanceDto>> GetAllSoutenancesAsync()
        {
            var soutenances = await _soutenanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SoutenanceDto>>(soutenances);
        }

        public async Task<SoutenanceDto?> GetSoutenanceByIdAsync(int id)
        {
            var soutenance = await _soutenanceRepository.GetSoutenanceWithDetailsAsync(id);
            return soutenance == null ? null : _mapper.Map<SoutenanceDto>(soutenance);
        }

        public async Task<SoutenanceDto?> GetSoutenanceByProjetAsync(int projetId)
        {
            var soutenance = await _soutenanceRepository.GetSoutenanceByProjetAsync(projetId);
            return soutenance == null ? null : _mapper.Map<SoutenanceDto>(soutenance);
        }

        public async Task<SoutenanceDto> CreateSoutenanceAsync(CreateSoutenanceDto dto)
        {
            var soutenance = new Soutenance
            {
                Date = dto.Date,
                Lieu = dto.Lieu,
                ProjetId = dto.ProjetId,
                MembresJury = new List<MembreJury>()
            };

            foreach (var juryId in dto.MembresJuryIds)
            {
                var jury = await _membreJuryRepository.GetByIdAsync(juryId);
                if (jury != null)
                    soutenance.MembresJury.Add(jury);
            }

            await _soutenanceRepository.AddAsync(soutenance);
            await _soutenanceRepository.SaveChangesAsync();
            return _mapper.Map<SoutenanceDto>(soutenance);
        }

        public async Task UpdateSoutenanceAsync(UpdateSoutenanceDto dto)
        {
            var soutenance = await _soutenanceRepository.GetSoutenanceWithDetailsAsync(dto.Id);
            if (soutenance == null) throw new KeyNotFoundException($"Soutenance with Id {dto.Id} not found.");

            soutenance.Date = dto.Date;
            soutenance.Lieu = dto.Lieu;
            soutenance.NoteFinale = dto.NoteFinale;
            soutenance.ProjetId = dto.ProjetId;

            soutenance.MembresJury.Clear();
            foreach (var juryId in dto.MembresJuryIds)
            {
                var jury = await _membreJuryRepository.GetByIdAsync(juryId);
                if (jury != null)
                    soutenance.MembresJury.Add(jury);
            }

            _soutenanceRepository.Update(soutenance);
            await _soutenanceRepository.SaveChangesAsync();
        }

        public async Task DeleteSoutenanceAsync(int id)
        {
            var soutenance = await _soutenanceRepository.GetByIdAsync(id);
            if (soutenance == null) throw new KeyNotFoundException($"Soutenance with Id {id} not found.");
            _soutenanceRepository.Delete(soutenance);
            await _soutenanceRepository.SaveChangesAsync();
        }
    }
}
