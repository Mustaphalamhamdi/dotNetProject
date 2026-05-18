using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IMapper _mapper;

        public EvaluationService(IEvaluationRepository evaluationRepository, IMapper mapper)
        {
            _evaluationRepository = evaluationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EvaluationDto>> GetAllEvaluationsAsync()
        {
            var evaluations = await _evaluationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EvaluationDto>>(evaluations);
        }

        public async Task<EvaluationDto?> GetEvaluationByIdAsync(int id)
        {
            var evaluation = await _evaluationRepository.GetByIdAsync(id);
            return evaluation == null ? null : _mapper.Map<EvaluationDto>(evaluation);
        }

        public async Task<IEnumerable<EvaluationDto>> GetEvaluationsBySoutenanceAsync(int soutenanceId)
        {
            var evaluations = await _evaluationRepository.GetEvaluationsBySoutenanceAsync(soutenanceId);
            return _mapper.Map<IEnumerable<EvaluationDto>>(evaluations);
        }

        public async Task<IEnumerable<EvaluationDto>> GetEvaluationsByMembreJuryAsync(int membreJuryId)
        {
            var evaluations = await _evaluationRepository.GetEvaluationsByMembreJuryAsync(membreJuryId);
            return _mapper.Map<IEnumerable<EvaluationDto>>(evaluations);
        }

        public async Task<EvaluationDto> CreateEvaluationAsync(CreateEvaluationDto dto)
        {
            var evaluation = _mapper.Map<Evaluation>(dto);
            await _evaluationRepository.AddAsync(evaluation);
            await _evaluationRepository.SaveChangesAsync();
            return _mapper.Map<EvaluationDto>(evaluation);
        }

        public async Task UpdateEvaluationAsync(UpdateEvaluationDto dto)
        {
            var evaluation = await _evaluationRepository.GetByIdAsync(dto.Id);
            if (evaluation == null) throw new KeyNotFoundException($"Evaluation with Id {dto.Id} not found.");
            _mapper.Map(dto, evaluation);
            _evaluationRepository.Update(evaluation);
            await _evaluationRepository.SaveChangesAsync();
        }

        public async Task DeleteEvaluationAsync(int id)
        {
            var evaluation = await _evaluationRepository.GetByIdAsync(id);
            if (evaluation == null) throw new KeyNotFoundException($"Evaluation with Id {id} not found.");
            _evaluationRepository.Delete(evaluation);
            await _evaluationRepository.SaveChangesAsync();
        }
    }
}
