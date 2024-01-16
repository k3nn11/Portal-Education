using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.VideoService;
using Data.Models;

namespace WebApplication1.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
              return _videoService.GetVideoList != null ? 
                          View(await _videoService.GetVideoList()) :
                          Problem("Entity set 'PortalContext.Video'  is null.");
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _videoService.GetVideoList == null)
            {
                return NotFound();
            }

            var video = await _videoService.GetVideoById(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Duration,Quality,IsDeleted,Id")] Video video)
        {
            if (ModelState.IsValid)
            {
                await _videoService.Create(video);
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _videoService.GetVideoList == null)
            {
                return NotFound();
            }

            var video = await _videoService.GetVideoById(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Duration,Quality,IsDeleted,Id")] Video video)
        {
            if (video == null || id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _videoService.Update(video);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await VideoExists(video.Id))
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
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _videoService.GetVideoList == null)
            {
                return NotFound();
            }

            var video = await _videoService.GetVideoById(id);
                
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_videoService.GetVideoList == null)
            {
                return Problem("Entity set 'WebApplication1Context.Video'  is null.");
            }
            var video = await _videoService.GetVideoById(id);
            if (video != null)
            {
                await _videoService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VideoExists(int? id)
        {
            return await _videoService.GetVideoById(id) != null ? true : false;
        }
    }
}
