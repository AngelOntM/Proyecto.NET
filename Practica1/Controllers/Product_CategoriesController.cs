using Microsoft.AspNetCore.Mvc;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class Product_CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Product_CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Product_Categories> listaProducts_categories = _context.product_categories;
            return View(listaProducts_categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product_Categories products_categorie)
        {
            if (ModelState.IsValid)
            {
                _context.product_categories.Add(products_categorie);
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
            var products_categorie = _context.product_categories.Find(id);
            return View(products_categorie);
        }

        [HttpPost]
        public ActionResult Edit(Product_Categories products_categorie)
        {
            if (ModelState.IsValid)
            {
                _context.product_categories.Update(products_categorie);
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
            var product_categories = _context.product_categories.Find(id);
            _context.product_categories.Remove(product_categories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var products_categorie = _context.product_categories.Find(id);
            return View(products_categorie);
        }
    }
}
