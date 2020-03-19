using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvShowWebApp.Data;
using TvShowWebApp.Models;
using TvShowWebApp.Services;

namespace TvShowWebApp.Controllers
{
    public class TvShowController : Controller
    {
        private readonly ITvShowService _services;
        public TvShowController(ITvShowService services)
        {
            _services = services;
        }

        // GET: TvShow
        public IActionResult Index()
        {
            return View(_services.GetAllList());
        }

        // GET: TvShow/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = _services.GetDetailsById(Convert.ToInt32(id));
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }

        // GET: TvShow/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: TvShow/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShow tvShow)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateEntry(tvShow);
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }

        // GET: TvShow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = _services.GetDetailsById(Convert.ToInt32(id));
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);

           
        }

        // POST: TvShow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShow tvShow)
        {
            if (id != tvShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _services.CreateEntry(tvShow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var checking = _services.GetDetailsById(Convert.ToInt32(id));
                    if (checking == null)
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
            return View(tvShow);
        }

        // GET: TvShow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = _services.GetDetailsById(Convert.ToInt32(id));
           
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }

        // POST: TvShow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShow = _services.GetDetailsById(Convert.ToInt32(id));

            await _services.Delete(tvShow);
            return RedirectToAction(nameof(Index));

        }

       
    }
}
