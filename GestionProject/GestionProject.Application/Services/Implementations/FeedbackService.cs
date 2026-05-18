using AutoMapper;
using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using GestionProject.Domain.Entities;
using GestionProject.Domain.Interfaces;

namespace GestionProject.Application.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task<FeedbackDto?> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            return feedback == null ? null : _mapper.Map<FeedbackDto>(feedback);
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbacksByRapportAsync(int rapportId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksByRapportAsync(rapportId);
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbacksByEncadrantAsync(int encadrantId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksByEncadrantAsync(encadrantId);
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task<FeedbackDto> CreateFeedbackAsync(CreateFeedbackDto dto)
        {
            var feedback = _mapper.Map<Feedback>(dto);
            feedback.Date = DateTime.UtcNow;
            await _feedbackRepository.AddAsync(feedback);
            await _feedbackRepository.SaveChangesAsync();
            return _mapper.Map<FeedbackDto>(feedback);
        }

        public async Task UpdateFeedbackAsync(UpdateFeedbackDto dto)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(dto.Id);
            if (feedback == null) throw new KeyNotFoundException($"Feedback with Id {dto.Id} not found.");
            _mapper.Map(dto, feedback);
            _feedbackRepository.Update(feedback);
            await _feedbackRepository.SaveChangesAsync();
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) throw new KeyNotFoundException($"Feedback with Id {id} not found.");
            _feedbackRepository.Delete(feedback);
            await _feedbackRepository.SaveChangesAsync();
        }
    }
}
