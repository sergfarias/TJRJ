using Works.DeveloperEvaluation.Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Livro = Works.DeveloperEvaluation.Frontend.Models.Livro;

namespace Works.DeveloperEvaluation.Frontend.Controllers
{
    public class LivrosController: Controller
    {
        readonly ILivroServices _livroService;

        public LivrosController(ILivroServices livroService)
        {
            _livroService = livroService;
        }

        // GET: Livros
        public async Task<ViewResult> Index()
        {
            try
            {
                var livros = await _livroService.GetAllAsync();

                //iew("_TurmaList", "_Modal", modelClass)
                return View(livros);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar livros: {ex.Message}";
                return View();
            }
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var produto = await _livroService.GetByIdAsync(id);
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
        public async Task<ActionResult> Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _livroService.CreateAsync(livro);
                    TempData["Success"] = "Livro criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao criar livro: {ex.Message}");
                }
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var produto = await _livroService.GetByIdAsync(id);
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
        public async Task<ActionResult> Edit(int id, Livro livro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _livroService.UpdateAsync(id, livro);
                    TempData["Success"] = "Livro atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar produto: {ex.Message}");
                }
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _livroService.DeleteAsync(id);
                TempData["Success"] = "Livro atualizado com sucesso!";
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
                await _livroService.DeleteAsync(id);
                TempData["Success"] = "Produto excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao excluir produto: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

