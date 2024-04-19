using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Inventories> listainventories = _context.inventories;
            return View(listainventories);
        }

        public ActionResult Create()
        {
            ViewBag.ProductsList = new SelectList(_context.products, "Product_id", "Product_name");
            ViewBag.WarehousesList = new SelectList(_context.warehouses, "Warehouse_id", "Warehouse_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Inventories inventorie)
        {
            if (ModelState.IsValid)
            {
                _context.inventories.Add(inventorie);
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
            ViewBag.ProductsList = new SelectList(_context.products, "Product_id", "Product_name");
            ViewBag.WarehousesList = new SelectList(_context.warehouses, "Warehouse_id", "Warehouse_name");
            var inventorie = _context.inventories.Find(id);
            return View(inventorie);
        }

        [HttpPost]
        public ActionResult Edit(Inventories inventorie)
        {
            if (ModelState.IsValid)
            {
                _context.inventories.Update(inventorie);
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
            var inventories = _context.inventories.Find(id);
            _context.inventories.Remove(inventories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var inventorie = _context.inventories.Find(id);
            return View(inventorie);
        }
    }
}
