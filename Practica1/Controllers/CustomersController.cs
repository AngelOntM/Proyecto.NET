using Microsoft.AspNetCore.Mvc;
using Practica1.Models;
using System.Diagnostics;
using Practica1.Data;

namespace Practica1.Controllers
{
    public class CustomersController: Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Customers> listaCustomers = _context.customers;
            return View(listaCustomers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            var customer = _context.customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Update(customer);
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
            var customers = _context.customers.Find(id);
            _context.customers.Remove(customers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customer = _context.customers.Find(id);
            return View(customer);
        }

    }
}
