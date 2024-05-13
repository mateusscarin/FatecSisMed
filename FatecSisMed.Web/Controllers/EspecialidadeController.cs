using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FatecSisMed.Web.Models;
using FatecSisMed.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FatecSisMed.Web.Controllers
{
    public class EspecialidadeController : Controller
    {
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadeViewModel>>> Index()
        {
            var result = await _especialidadeService.GetAllEspecialidades();
            if (result is null) return View("Error");
            return View(result);
        }

        // criar a view CreateEspecialidade
        [HttpGet]
        public async Task<IActionResult> CreateEspecialidade()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>
            CreateEspecialidade(EspecialidadeViewModel especialidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await
                    _especialidadeService.CreateEspecialidade(especialidadeViewModel);
                if (result is not null) return RedirectToAction(nameof(Index));
            }
            else
                return BadRequest("Error");

            return View(especialidadeViewModel);
        }

        // Criar a view UpdateEspecialidade
        [HttpGet]
        public async Task<IActionResult> UpdateEspecialidade(int id)
        {
            var result = await _especialidadeService.FindEspecialidadeById(id);
            if (result is null) return View("Error");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult>
            UpdateEspecialidade(EspecialidadeViewModel especialidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await
                    _especialidadeService.UpdateEspecialidade(especialidadeViewModel);
                if (result is not null) return RedirectToAction(nameof(Index));
            }

            return View(especialidadeViewModel);
        }

        // criar a view delete especialidade
        [HttpGet]
        public async Task<ActionResult<EspecialidadeViewModel>>
            DeleteEspecialidade(int id)
        {
            var result = await _especialidadeService.FindEspecialidadeById(id);
            if (result is null) return View("Error");
            return View(result);
        }

        [HttpPost(), ActionName("DeleteEspecialidade")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _especialidadeService.DeleteEspecialidadeById(id);
            if (!result) return View("Error");
            return RedirectToAction("Index");
        }
    }
}

