using GestionProject.Application.DTOs;
using GestionProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProject.Web.Controllers
{
    public class EncadrantsController : Controller
    {
        private readonly IEncadrantService _encadrantService;

        public EncadrantsController(IEncadrantService encadrantService)
        {
            _encadrantService = encadrantService;
        }

        public async Task<IActionResult> Index()
        {
            var encadrants = await _encadrantService.GetAllEncadrantsAsync();
            return View(encadrants);
        }

        public async Task<IActionResult> Details(int id)
        {
            var encadrant = await _encadrantService.GetEncadrantByIdAsync(id);
            if (encadrant == null) return NotFound();
            return View(encadrant);
        }

        public IActionResult Create()
        {
            ViewBag.Types = new SelectList(new[] { "Academique", "Professionnel" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEncadrantDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Types = new SelectList(new[] { "Academique", "Professionnel" });
                return View(dto);
            }

            await _encadrantService.CreateEncadrantAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var encadrant = await _encadrantService.GetEncadrantByIdAsync(id);
            if (encadrant == null) return NotFound();

            var updateDto = new UpdateEncadrantDto
            {
                Id = encadrant.Id,
                Nom = encadrant.Nom,
                Prenom = encadrant.Prenom,
                Email = encadrant.Email,
                Type = encadrant.Type
            };

            ViewBag.Types = new SelectList(new[] { "Academique", "Professionnel" });
            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateEncadrantDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Types = new SelectList(new[] { "Academique", "Professionnel" });
                return View(dto);
            }

            await _encadrantService.UpdateEncadrantAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var encadrant = await _encadrantService.GetEncadrantByIdAsync(id);
            if (encadrant == null) return NotFound();
            return View(encadrant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _encadrantService.DeleteEncadrantAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
