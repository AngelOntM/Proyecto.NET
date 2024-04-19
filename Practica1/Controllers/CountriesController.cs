using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Countries> listaCountries = _context.countries;
            return View(listaCountries);
        }

        public ActionResult Create()
        {
            ViewBag.RegionsList = new SelectList(_context.regions, "Region_id", "Region_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Countries country)
        {
            if (country.Country_id.Length > 2)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _context.countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.RegionsList = new SelectList(_context.regions, "Region_id", "Region_name");
            var country = _context.countries.Find(id);
            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(Countries country)
        {
            if (country.Country_id.Length > 2)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _context.countries.Update(country);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {

            var countries = _context.countries.Find(id);
            _context.countries.Remove(countries);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _context.countries.Find(id);
            return View(country);
        }
    }
}
