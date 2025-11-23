using Works.DeveloperEvaluation.Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Livro = Works.DeveloperEvaluation.Frontend.Models.Livro;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Works.DeveloperEvaluation.Frontend.Controllers
{
    public class LivrosController: Controller
    {
        readonly ILivroServices _livroService;
        readonly IAutorServices _autorService;
        readonly IAssuntoServices _assuntoService;
        public LivrosController(ILivroServices livroService, IAutorServices autorService, IAssuntoServices assuntoService)
        {
            _livroService = livroService;
            _autorService = autorService;
            _assuntoService = assuntoService;
        }

        // GET: Livros
        public async Task<ViewResult> Index()
        {
            try
            {
                var livros = await _livroService.GetAllAsync();
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
        public async Task<ActionResult> Create()
        {
            ViewBag.Autores = await _autorService.GetAllAsync();
            ViewBag.Assuntos = await _assuntoService.GetAllAsync();
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
                    ViewBag.Autores = await _autorService.GetAllAsync();
                    ViewBag.Assuntos = await _assuntoService.GetAllAsync();
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
                    ViewBag.Autores = _autorService.GetAllAsync();
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


        // GET: Relatorio
        public async Task<ViewResult> Relatorio()
        {
            try
            {
                var livros = await _livroService.Relatorio();
                return View(livros);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar livros: {ex.Message}";
                return View();
            }
        }


    }
}

