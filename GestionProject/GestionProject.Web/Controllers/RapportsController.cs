using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class RapportsController : Controller
    {
        private readonly IRapportService _rapportService;
        private readonly IProjetService _projetService;

        public RapportsController(IRapportService rapportService, IProjetService projetService)
        {
            _rapportService = rapportService;
            _projetService = projetService;
        }

        public async Task<IActionResult> Index()
        {
            var rapports = await _rapportService.GetAllRapportsAsync();
            return View(rapports);
        }

        public async Task<IActionResult> Details(int id)
        {
            var rapport = await _rapportService.GetRapportByIdAsync(id);
            if (rapport == null) return NotFound();
            return View(rapport);
        }

        public async Task<IActionResult> Create()
        {
            var projets = await _projetService.GetAllProjetsAsync();
            ViewBag.Projets = new SelectList(projets, "Id", "Titre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRapportDto dto)
        {
            if (!ModelState.IsValid)
            {
                var projets = await _projetService.GetAllProjetsAsync();
                ViewBag.Projets = new SelectList(projets, "Id", "Titre");
                return View(dto);
            }

            await _rapportService.CreateRapportAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var rapport = await _rapportService.GetRapportByIdAsync(id);
            if (rapport == null) return NotFound();

            var updateDto = new UpdateRapportDto
            {
                Id = rapport.Id,
                Version = rapport.Version,
                CheminFichier = rapport.CheminFichier,
                ProjetId = rapport.ProjetId
            };

            var projets = await _projetService.GetAllProjetsAsync();
            ViewBag.Projets = new SelectList(projets, "Id", "Titre");
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateRapportDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                var projets = await _projetService.GetAllProjetsAsync();
                ViewBag.Projets = new SelectList(projets, "Id", "Titre");
                return View(dto);
            }

            await _rapportService.UpdateRapportAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var rapport = await _rapportService.GetRapportByIdAsync(id);
            if (rapport == null) return NotFound();
            return View(rapport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rapportService.DeleteRapportAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
