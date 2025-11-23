using Microsoft.AspNetCore.Mvc;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Frontend.Services;
using Autor = Works.DeveloperEvaluation.Frontend.Models.Autor;

namespace Works.DeveloperEvaluation.Frontend.Controllers
{
    public class AutoresController : Controller
    {
        readonly IAutorServices _autorService;

        public AutoresController(IAutorServices autorService)
        {
            _autorService = autorService;
        }

        // GET: Livros
        public async Task<ViewResult> Index()
        {
            try
            {
                var livros = await _autorService.GetAllAsync();
                return View(livros);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar autores: {ex.Message}";
                return View();
            }
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var produto = await _autorService.GetByIdAsync(id);
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
        public async Task<ActionResult> Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.CreateAsync(autor);
                    TempData["Success"] = "Autor criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar livro: {ex.Message}");
                }
            }
            return View(autor);
        }

        // GET: Livros/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var produto = await _autorService.GetByIdAsync(id);
                return View(produto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Autor autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.UpdateAsync(id, autor);
                    TempData["Success"] = "Autor atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar produto: {ex.Message}");
                }
            }
            return View(autor);
        }

        // GET: Livros/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _autorService.DeleteAsync(id);
                TempData["Success"] = "Autor atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao deletar livro: {ex.Message}");
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
                await _autorService.DeleteAsync(id);
                TempData["Success"] = "Autor excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao excluir autor: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

