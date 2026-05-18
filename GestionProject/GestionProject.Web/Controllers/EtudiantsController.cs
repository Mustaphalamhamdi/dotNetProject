using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionProject.Web.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly IEtudiantService _etudiantService;

        public EtudiantsController(IEtudiantService etudiantService)
        {
            _etudiantService = etudiantService;
        }

        public async Task<IActionResult> Index()
        {
            var etudiants = await _etudiantService.GetAllEtudiantsAsync();
            return View(etudiants);
        }

        public async Task<IActionResult> Details(int id)
        {
            var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);
            if (etudiant == null) return NotFound();
            return View(etudiant);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEtudiantDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _etudiantService.CreateEtudiantAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);
            if (etudiant == null) return NotFound();

            var updateDto = new UpdateEtudiantDto
            {
                Id = etudiant.Id,
                Nom = etudiant.Nom,
                Prenom = etudiant.Prenom,
                Email = etudiant.Email
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateEtudiantDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            await _etudiantService.UpdateEtudiantAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);
            if (etudiant == null) return NotFound();
            return View(etudiant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _etudiantService.DeleteEtudiantAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
