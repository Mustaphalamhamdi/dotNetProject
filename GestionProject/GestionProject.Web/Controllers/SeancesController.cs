using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class SeancesController : Controller
    {
        private readonly ISeanceService _seanceService;
        private readonly IProjetService _projetService;
        private readonly IEncadrantService _encadrantService;

        public SeancesController(ISeanceService seanceService, IProjetService projetService, IEncadrantService encadrantService)
        {
            _seanceService = seanceService;
            _projetService = projetService;
            _encadrantService = encadrantService;
        }

        public async Task<IActionResult> Index()
        {
            var seances = await _seanceService.GetAllSeancesAsync();
            return View(seances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var seance = await _seanceService.GetSeanceByIdAsync(id);
            if (seance == null) return NotFound();
            return View(seance);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSeanceDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _seanceService.CreateSeanceAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var seance = await _seanceService.GetSeanceByIdAsync(id);
            if (seance == null) return NotFound();

            var updateDto = new UpdateSeanceDto
            {
                Id = seance.Id,
                Date = seance.Date,
                Type = seance.Type,
                Notes = seance.Notes,
                Commentaires = seance.Commentaires,
                ProjetId = seance.ProjetId,
                EncadrantId = seance.EncadrantId
            };

            await PopulateDropdowns();
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSeanceDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _seanceService.UpdateSeanceAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var seance = await _seanceService.GetSeanceByIdAsync(id);
            if (seance == null) return NotFound();
            return View(seance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _seanceService.DeleteSeanceAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var projets = await _projetService.GetAllProjetsAsync();
            var encadrants = await _encadrantService.GetAllEncadrantsAsync();
            ViewBag.Projets = new SelectList(projets, "Id", "Titre");
            ViewBag.Encadrants = new SelectList(encadrants, "Id", "Nom");
            ViewBag.Types = new SelectList(new[] { "Presentielle", "Distancielle" });
        }
    }
}
