using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1.Data;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var employees = _context.employees.ToList();

            // Crear un diccionario para almacenar los nombres de los gerentes
            var managerNames = new Dictionary<int, string>();

            foreach (var employee in employees)
            {
                if (employee.Manager_id != null)
                {
                    var manager = _context.employees.Find(employee.Manager_id);
                    if (manager != null)
                    {
                        managerNames.Add(employee.Employee_id, $"{manager.First_name} {manager.Last_name}");
                    }
                }
                else
                {
                    managerNames.Add(employee.Employee_id, "No manager");
                }
            }

            ViewBag.ManagerNames = managerNames;

            return View(employees);
        }

        public ActionResult Create()
        {
            ViewBag.ManagerList = new SelectList(_context.employees, "Employee_id", "First_name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.employees.Add(employee);
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
            var employee = _context.employees.Find(id);
            ViewBag.ManagerList = new SelectList(_context.employees, "Employee_id", "First_name");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.employees.Update(employee);
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
            var employees = _context.employees.Find(id);
            _context.employees.Remove(employees);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Verificar si hay un gerente
            string managerName = "No manager";
            if (employee.Manager_id != null)
            {
                var manager = _context.employees.Find(employee.Manager_id);
                if (manager != null)
                {
                    managerName = $"{manager.First_name} {manager.Last_name}";
                }
            }

            ViewBag.ManagerName = managerName;

            return View(employee);
        }
    }
}
