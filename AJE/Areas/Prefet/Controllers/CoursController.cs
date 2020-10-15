using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AJE.Areas.Prefet.Controllers
{
    [Area("Prefet")]
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

        public IActionResult Update(int id)
        {
            FillCategories();
            ViewData["ClasseID"] = id;
            Cours model = db.Cours.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, int idcours, Cours model)
        {
             if(ModelState.IsValid)
            {
                model.ClasseID = id;
                model.CoursID = idcours;
                db.Cours.Update(model);
                db.SaveChanges();
                return RedirectToAction("Detail", "Classe", new { id = id });
            }
            FillCategories();
            ViewData["ClasseID"] = id;
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult Supprimer(int id, int idcours)
        {
            ViewData["ClasseID"] = id;
            Cours model = db.Cours.Find(idcours);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, int idcours)
        {
            Cours model = db.Cours.Find(idcours);
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Detail", "Classe", new { id = id });
        }

        public IActionResult Detail(int id)
        {
            var model = db.Cours.Include(c => c.Classe)
                .Include(e => e.Epreuves)
                .ThenInclude(el => el.Eleve)
                .Include(l => l.Lecons)
                .AsNoTracking()
                .FirstOrDefault(o => o.CoursID == id);
            return View(model);
        }
    }
}
