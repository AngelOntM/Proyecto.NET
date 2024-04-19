using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Contacts> listaContacts = _context.contacts;
            return View(listaContacts);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(_context.customers, "Customer_id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                _context.contacts.Add(contact);
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
            ViewBag.CustomerList = new SelectList(_context.customers, "Customer_id", "Name");
            var contact = _context.contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                _context.contacts.Update(contact);
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
            var contacts = _context.contacts.Find(id);
            _context.contacts.Remove(contacts);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.contacts.Find(id);
            return View(contact);
        }
    }
}
