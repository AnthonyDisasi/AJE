using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJE.Controllers
{
    public class ClasseController : Controller
    {
        private readonly AppDbContextEcole db;
        public ClasseController(AppDbContextEcole _db)
        {
            this.db = _db;
        }

        private void FillSection()
        {
            List<SelectListItem> Sections = (from s in db.Sections orderby s.Nom ascending select new SelectListItem() { Text = s.Nom, Value = s.Nom }).ToList();
            ViewBag.Sections = Sections;
        }

        private void FillOption()
        {
            List<SelectListItem> Options = (from o in db.Options orderby o.Nom ascending select new SelectListItem() { Text = o.Nom, Value = o.Nom }).ToList();
            ViewBag.Options = Options;
        }

        public IActionResult Detail(int id)
        {
            var model = db.Classes.Include(e => e.Ecole)
                .Include(c => c.Cours)
                .Include(i => i.Inscriptions)
                .ThenInclude(e => e.Eleve)
                .AsNoTracking()
                .FirstOrDefault(cl => cl.ClasseID == id);
            return View(model);
        }

        public IActionResult Create(int id)
        {
            FillSection();
            FillOption();
            ViewData["EcoleID"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, Classe model)
        {
            if (ModelState.IsValid)
            {
                model.EcoleID = id;
                db.Classes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Detail", "Ecole", new { id = id });
            }
            FillSection();
            FillOption();
            ViewData["EcoleID"] = id;
            return View(model);
        }

        public IActionResult Update(int id)
        {
            FillSection();
            FillOption();
            Classe model = db.Classes.Find(id);
            ViewData["EcoleID"] = model.EcoleID;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, int classeId, Classe model)
        {
            FillSection();
            FillOption();
            if (ModelState.IsValid)
            {
                model.ClasseID = classeId;
                model.EcoleID = id;
                db.Classes.Update(model);
                db.SaveChanges();
                return RedirectToAction("Detail", "Ecole", new { id = id });
            }
            ViewData["EcoleID"] = id;
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult Supprimer(int id)
        {
            Classe model = db.Classes.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Classe model = db.Classes.Find(id);
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Detail", "Ecole", new { id = model.EcoleID });
        }


    }
}
