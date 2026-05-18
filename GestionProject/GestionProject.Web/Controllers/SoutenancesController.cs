using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class SoutenancesController : Controller
    {
        private readonly ISoutenanceService _soutenanceService;
        private readonly IProjetService _projetService;
        private readonly IMembreJuryService _membreJuryService;

        public SoutenancesController(ISoutenanceService soutenanceService, IProjetService projetService, IMembreJuryService membreJuryService)
        {
            _soutenanceService = soutenanceService;
            _projetService = projetService;
            _membreJuryService = membreJuryService;
        }

        public async Task<IActionResult> Index()
        {
            var soutenances = await _soutenanceService.GetAllSoutenancesAsync();
            return View(soutenances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var soutenance = await _soutenanceService.GetSoutenanceByIdAsync(id);
            if (soutenance == null) return NotFound();
            return View(soutenance);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSoutenanceDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _soutenanceService.CreateSoutenanceAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var soutenance = await _soutenanceService.GetSoutenanceByIdAsync(id);
            if (soutenance == null) return NotFound();

            var updateDto = new UpdateSoutenanceDto
            {
                Id = soutenance.Id,
                Date = soutenance.Date,
                Lieu = soutenance.Lieu,
                NoteFinale = soutenance.NoteFinale,
                ProjetId = soutenance.ProjetId,
                MembresJuryIds = soutenance.MembresJury.Select(m => m.Id).ToList()
            };

            await PopulateDropdowns();
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSoutenanceDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _soutenanceService.UpdateSoutenanceAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var soutenance = await _soutenanceService.GetSoutenanceByIdAsync(id);
            if (soutenance == null) return NotFound();
            return View(soutenance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _soutenanceService.DeleteSoutenanceAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var projets = await _projetService.GetAllProjetsAsync();
            var membres = await _membreJuryService.GetAllMembresJuryAsync();
            ViewBag.Projets = new SelectList(projets, "Id", "Titre");
            ViewBag.MembresJury = new MultiSelectList(membres, "Id", "Nom");
        }
    }
}
