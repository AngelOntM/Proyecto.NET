using Microsoft.AspNetCore.Mvc;
using Practica1.Data;
using Practica1.Models;
using static NuGet.Packaging.PackagingConstants;

namespace Practica1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Orders> listaOrders = _context.orders;
            return View(listaOrders);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Orders order)
        {
            if (ModelState.IsValid)
            {
                _context.orders.Add(order);
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
            var order = _context.orders.Find(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            if (ModelState.IsValid)
            {
                _context.orders.Update(order);
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
            var orders = _context.orders.Find(id);
            _context.orders.Remove(orders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var order = _context.orders.Find(id);
            return View(order);
        }
    }
}
