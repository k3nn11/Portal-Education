using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.ArticleService;
using Data.Models;
using Services.MaterialService;

namespace PL_Portal.Controllers
{
    public class ArticlesController : Controller
{
        private readonly IArticleService _articleService;

    public ArticlesController(IArticleService articleService)
    {
            //IArticleService articleService1 = new ArticleService();
            _articleService = articleService;
        }

    // GET: Articles
    public async Task<IActionResult> Index()
        {
            return _articleService.GetArticleList != null ?
                        View(await _articleService.GetArticleList().ConfigureAwait(false)) :
                        //RedirectToAction(nameof(Create));
                        Problem(nameof(Index));
            //var list = _articleService.GetArticleList();
            //    return View(list);
        }

    // GET: Articles/Details
    public async Task<IActionResult> Details(int id)
    {
        if (id == null || _articleService.GetArticleList == null)
        {
            return NotFound();
        }

            var article = _articleService.GetArticleById(id);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // GET: Articles/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Description,DateOfPublication,Resource,IsDeleted,Id")] Article article)
    {
        if (ModelState.IsValid)
        {
                await _articleService.Create(article);
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    // GET: Articles/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (id == null || _articleService.GetArticleList == null)
        {
            return NotFound();
        }

            var article = await _articleService.GetArticleById(id);
            return article == null ? NotFound() : View(article);
        }

        [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Title,Description,DateOfPublication,Resource,States,IsDeleted,Id")] Article article)
    {
        if (article == null || id == null || id != article.Id )
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                    await _articleService.Update(article);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArticleExists(article.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    // GET: Articles/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null || _articleService.GetArticleList == null)
        {
            return NotFound();
        }

            var article = await _articleService.GetArticleById(id);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // POST: Articles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_articleService.GetArticleList == null)
        {
            return Problem("Entity set 'PortalContext.Article'  is null.");
        }
            var article = await _articleService.GetArticleById(id);
        if (article != null)
        {
                await _articleService.Delete(id);
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ArticleExists(int? id)
    {
            return await _articleService.GetArticleById(id) != null;
    }
}
}
