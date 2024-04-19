using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WarehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Warehouses> listaWarehouses = _context.warehouses.Include(w => w.Locations);
            return View(listaWarehouses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Warehouses warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.warehouses.Add(warehouse);
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
            var warehouse = _context.warehouses.Find(id);
            ViewBag.Location_id = new SelectList(_context.locations, "Location_id", "Address", warehouse.Location_id);
            return View(warehouse);
        }

        [HttpPost]
        public ActionResult Edit(Warehouses warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.warehouses.Update(warehouse);
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
            var warehouse = _context.warehouses.Find(id);
            _context.warehouses.Remove(warehouse);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var warehouse = _context.warehouses.Include(w => w.Locations).FirstOrDefault(w => w.Warehouse_id == id);
            return View(warehouse);
        }
    }
}
