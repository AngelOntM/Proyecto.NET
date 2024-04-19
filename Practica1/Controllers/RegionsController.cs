using Microsoft.AspNetCore.Mvc;
using Practica1.Data;
using Practica1.Models;
using System.Drawing;

namespace Practica1.Controllers
{
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Regions> listaRegions = _context.regions;
            return View(listaRegions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Regions region)
        {
            if (ModelState.IsValid)
            {
                _context.regions.Add(region);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var region = _context.regions.Find(id);
            return View(region);
        }

        [HttpPost]
        public ActionResult Edit(Regions region)
        {
            if (ModelState.IsValid)
            {
                _context.regions.Update(region);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var regions = _context.regions.Find(id);
            _context.regions.Remove(regions);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var region = _context.regions.Find(id);
            return View(region);
        }
    }
}
