using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly IProjetService _projetService;
        private readonly IEtudiantService _etudiantService;
        private readonly IEncadrantService _encadrantService;

        public ProjetsController(IProjetService projetService, IEtudiantService etudiantService, IEncadrantService encadrantService)
        {
            _projetService = projetService;
            _etudiantService = etudiantService;
            _encadrantService = encadrantService;
        }

        public async Task<IActionResult> Index()
        {
            var projets = await _projetService.GetAllProjetsAsync();
            return View(projets);
        }

        public async Task<IActionResult> Details(int id)
        {
            var projet = await _projetService.GetProjetByIdAsync(id);
            if (projet == null) return NotFound();
            return View(projet);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjetDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _projetService.CreateProjetAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var projet = await _projetService.GetProjetByIdAsync(id);
            if (projet == null) return NotFound();

            var updateDto = new UpdateProjetDto
            {
                Id = projet.Id,
                Titre = projet.Titre,
                Type = projet.Type,
                Statut = projet.Statut,
                EtudiantId = projet.EtudiantId,
                EncadrantAcademiqueId = projet.EncadrantAcademiqueId,
                EncadrantProfessionnelId = projet.EncadrantProfessionnelId
            };

            await PopulateDropdowns();
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProjetDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _projetService.UpdateProjetAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projet = await _projetService.GetProjetByIdAsync(id);
            if (projet == null) return NotFound();
            return View(projet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projetService.DeleteProjetAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var etudiants = await _etudiantService.GetAllEtudiantsAsync();
            var encadrants = await _encadrantService.GetAllEncadrantsAsync();

            ViewBag.Etudiants = new SelectList(etudiants, "Id", "Nom");
            ViewBag.EncadrantsAcademiques = new SelectList(encadrants.Where(e => e.Type == "Academique"), "Id", "Nom");
            ViewBag.EncadrantsProfessionnels = new SelectList(encadrants.Where(e => e.Type == "Professionnel"), "Id", "Nom");
            ViewBag.Types = new SelectList(new[] { "PFE", "PFA" });
            ViewBag.Statuts = new SelectList(new[] { "Proposé", "En cours", "Soutenu" });
        }
    }
}
