using System.Collections.Generic;
using System.Linq;
using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AJE.Areas.Prefet.Controllers
{
    [Area("Prefet")]
    public class ClasseController : Controller
    {
        private readonly AppDbContextEcole db;
        public ClasseController(AppDbContextEcole _db)
        {
            db = _db;
        }

        public IActionResult Index(int id)
        {
            var model = db.Ecoles.Include(p => p.Prefet)
                .Include(c => c.Classes)
                .ThenInclude(i => i.Inscriptions)
                .ThenInclude(e => e.Eleve)
                .Include(cl => cl.Classes)
                .ThenInclude(co => co.Cours)
                .AsNoTracking()
                .FirstOrDefault(ec => ec.PrefetID == id);
            return View(model);
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
                int idPrefet = db.Ecoles.FirstOrDefault(p => p.EcoleID == id).PrefetID;
                db.Classes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Classe", new { id = idPrefet });
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
                int idPrefet = db.Ecoles.FirstOrDefault(p => p.EcoleID == id).PrefetID;
                return RedirectToAction("Index", "Classe", new { id = idPrefet });
            }
            ViewData["EcoleID"] = id;
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult Supprimer(int id, int idPrefet)
        {
            ViewData["idPrefet"] = idPrefet;
            Classe model = db.Classes.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, int idPrefet)
        {
            Classe model = db.Classes.Find(id);
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Classe", new { id = idPrefet });
        }

    }
}
