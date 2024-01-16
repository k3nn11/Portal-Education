using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.SkillService;
using Data.Models;
namespace WebApplication1.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
              return _skillService.GetSkillList != null ? 
                          View(await _skillService.GetSkillList()) :
                          Problem("Entity set 'WebApplication1Context.Skill'  is null.");
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _skillService.GetSkillList == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetSkillById(id);
                
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Level,Id")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.Create(skill);
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _skillService.GetSkillList == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Level,Id")] Skill skill)
        {
            if (skill == null || id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _skillService.Update(skill);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SkillExists(skill.Id))
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
            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _skillService.GetSkillList == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_skillService.GetSkillList == null)
            {
                return Problem("Entity set 'WebApplication1Context.Skill'  is null.");
            }
            var skill = await _skillService.GetSkillById(id);
            if (skill != null)
            {
                await _skillService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SkillExists(int? id)
        {
            return await _skillService.GetSkillById(id) != null;
        }
    }
}
