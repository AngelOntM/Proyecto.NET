using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Locations> listalocations = _context.locations;
            return View(listalocations);
        }

        public ActionResult Create()
        {
            ViewBag.CountriesList = new SelectList(_context.countries, "Country_id", "Country_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Locations location)
        {
            if (ModelState.IsValid)
            {
                _context.locations.Add(location);
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
            ViewBag.CountriesList = new SelectList(_context.countries, "Country_id", "Country_name");
            var location = _context.locations.Find(id);
            return View(location);
        }

        [HttpPost]
        public ActionResult Edit(Locations location)
        {
            if (ModelState.IsValid)
            {
                _context.locations.Update(location);
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
            var locations = _context.locations.Find(id);
            _context.locations.Remove(locations);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var location = _context.locations.Find(id);
            return View(location);
        }
    }
}
