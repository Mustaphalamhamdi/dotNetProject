using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationService _evaluationService;
        private readonly ISoutenanceService _soutenanceService;
        private readonly IMembreJuryService _membreJuryService;

        public EvaluationsController(IEvaluationService evaluationService, ISoutenanceService soutenanceService, IMembreJuryService membreJuryService)
        {
            _evaluationService = evaluationService;
            _soutenanceService = soutenanceService;
            _membreJuryService = membreJuryService;
        }

        public async Task<IActionResult> Index()
        {
            var evaluations = await _evaluationService.GetAllEvaluationsAsync();
            return View(evaluations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null) return NotFound();
            return View(evaluation);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEvaluationDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _evaluationService.CreateEvaluationAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null) return NotFound();

            var updateDto = new UpdateEvaluationDto
            {
                Id = evaluation.Id,
                Note = evaluation.Note,
                Commentaire = evaluation.Commentaire,
                SoutenanceId = evaluation.SoutenanceId,
                MembreJuryId = evaluation.MembreJuryId
            };

            await PopulateDropdowns();
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateEvaluationDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _evaluationService.UpdateEvaluationAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null) return NotFound();
            return View(evaluation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _evaluationService.DeleteEvaluationAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var soutenances = await _soutenanceService.GetAllSoutenancesAsync();
            var membres = await _membreJuryService.GetAllMembresJuryAsync();
            ViewBag.Soutenances = new SelectList(soutenances, "Id", "ProjetTitre");
            ViewBag.MembresJury = new SelectList(membres, "Id", "Nom");
        }
    }
}
