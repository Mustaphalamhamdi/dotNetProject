using GestionProject.Application.DTOs;

namespace GestionProject.Application.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync();
        Task<FeedbackDto?> GetFeedbackByIdAsync(int id);
        Task<IEnumerable<FeedbackDto>> GetFeedbacksByRapportAsync(int rapportId);
        Task<IEnumerable<FeedbackDto>> GetFeedbacksByEncadrantAsync(int encadrantId);
        Task<FeedbackDto> CreateFeedbackAsync(CreateFeedbackDto dto);
        Task UpdateFeedbackAsync(UpdateFeedbackDto dto);
        Task DeleteFeedbackAsync(int id);
    }
}
