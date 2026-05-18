using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionProject.Web.Controllers
{
    public class MembresJuryController : Controller
    {
        private readonly IMembreJuryService _membreJuryService;

        public MembresJuryController(IMembreJuryService membreJuryService)
        {
            _membreJuryService = membreJuryService;
        }

        public async Task<IActionResult> Index()
        {
            var membres = await _membreJuryService.GetAllMembresJuryAsync();
            return View(membres);
        }

        public async Task<IActionResult> Details(int id)
        {
            var membre = await _membreJuryService.GetMembreJuryByIdAsync(id);
            if (membre == null) return NotFound();
            return View(membre);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMembreJuryDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _membreJuryService.CreateMembreJuryAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var membre = await _membreJuryService.GetMembreJuryByIdAsync(id);
            if (membre == null) return NotFound();

            var updateDto = new UpdateMembreJuryDto
            {
                Id = membre.Id,
                Nom = membre.Nom,
                Prenom = membre.Prenom,
                Email = membre.Email
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateMembreJuryDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            await _membreJuryService.UpdateMembreJuryAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var membre = await _membreJuryService.GetMembreJuryByIdAsync(id);
            if (membre == null) return NotFound();
            return View(membre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _membreJuryService.DeleteMembreJuryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
