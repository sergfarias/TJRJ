using Microsoft.AspNetCore.Mvc;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Frontend.Services;
using Assunto = Works.DeveloperEvaluation.Frontend.Models.Assunto;

namespace Works.DeveloperEvaluation.Frontend.Controllers
{
    public class AssuntosController : Controller
    {
        readonly IAssuntoServices _assuntoService;

        public AssuntosController(IAssuntoServices assuntoService)
        {
            _assuntoService = assuntoService;
        }

        // GET: Livros
        public async Task<ViewResult> Index()
        {
            try
            {
                var livros = await _assuntoService.GetAllAsync();
                return View(livros);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar assuntos: {ex.Message}";
                return View();
            }
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var produto = await _assuntoService.GetByIdAsync(id);
                return View(produto);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _assuntoService.CreateAsync(assunto);
                    TempData["Success"] = "Assunto criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar assunto: {ex.Message}");
                }
            }
            return View(assunto);
        }

        // GET: Livros/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var produto = await _assuntoService.GetByIdAsync(id);
                return View(produto);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _assuntoService.UpdateAsync(id, assunto);
                    TempData["Success"] = "Assunto atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar assunto: {ex.Message}");
                }
            }
            return View(assunto);
        }

        // GET: Livros/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _assuntoService.DeleteAsync(id);
                TempData["Success"] = "Assunto atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao deletar assunto: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _assuntoService.DeleteAsync(id);
                TempData["Success"] = "Assunto excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao excluir assunto: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

