using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJE.Controllers
{
    public class CoursController : Controller
    {
        public AppDbContextEcole db;
        public CoursController(AppDbContextEcole _db)
        {
            db = _db;
        }

        private void FillCategories()
        {
            List<SelectListItem> Categories = (from c in db.Categories orderby c.Nom ascending select new SelectListItem() { Text = c.Nom, Value = c.Nom }).ToList();
            ViewBag.Categories = Categories;
        }

        public IActionResult Create(int id_classe)
        {
            FillCategories();
            ViewData["ClasseID"] = id_classe;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id_classe, Cours model)
        {
            model.ClasseID = id_classe;
            if (ModelState.IsValid)
            {
                db.Cours.Add(model);
                db.SaveChanges();
                return RedirectToAction("Detail", "Classe", new { id = id_classe });
            }
            FillCategories();
            ViewData["ClasseID"] = id_classe;
            return View(model);
        }

    }
}
