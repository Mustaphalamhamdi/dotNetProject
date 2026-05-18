using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IRapportService _rapportService;
        private readonly IEncadrantService _encadrantService;

        public FeedbacksController(IFeedbackService feedbackService, IRapportService rapportService, IEncadrantService encadrantService)
        {
            _feedbackService = feedbackService;
            _rapportService = rapportService;
            _encadrantService = encadrantService;
        }

        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return View(feedbacks);
        }

        public async Task<IActionResult> Details(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFeedbackDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _feedbackService.CreateFeedbackAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();

            var updateDto = new UpdateFeedbackDto
            {
                Id = feedback.Id,
                Contenu = feedback.Contenu,
                RapportId = feedback.RapportId,
                EncadrantId = feedback.EncadrantId
            };

            await PopulateDropdowns();
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateFeedbackDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _feedbackService.UpdateFeedbackAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _feedbackService.DeleteFeedbackAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var rapports = await _rapportService.GetAllRapportsAsync();
            var encadrants = await _encadrantService.GetAllEncadrantsAsync();
            ViewBag.Rapports = new SelectList(rapports, "Id", "Version");
            ViewBag.Encadrants = new SelectList(encadrants, "Id", "Nom");
        }
    }
}
