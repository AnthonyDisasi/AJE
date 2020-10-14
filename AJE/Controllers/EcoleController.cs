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
    public class EcoleController : Controller
    {
        private readonly AppDbContextEcole db;
        public EcoleController(AppDbContextEcole _db)
        {
            db = _db;
        }

        private void FillSousDivisions()
        {
            List<SelectListItem> SousDivisions = (from s in db.SousDivisions orderby s.Nom ascending select new SelectListItem() { Text = s.Nom, Value = s.Nom }).ToList();
            ViewBag.SousDivisions = SousDivisions;
        }

        public IActionResult Index()
        {
            var model = db.Ecoles.Include(p => p.Prefet).ToList();
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = db.Ecoles.Include(c => c.Classes).Include(p => p.Prefet).AsNoTracking().FirstOrDefault(e => e.EcoleID == id);
            return View(model);
        }

        public IActionResult Create()
        {
            FillSousDivisions();
            ViewData["PrefetID"] = new SelectList(db.Prefets, "PrefetID", "Nom");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ecole model)
        {
            FillSousDivisions();
            if (ModelState.IsValid)
            {
                db.Ecoles.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PrefetID"] = new SelectList(db.Prefets, "PrefetID", "Nom", model.PrefetID);
            return View(model);
        }

        public IActionResult Update(int id)
        {
            FillSousDivisions();
            Ecole model = db.Ecoles.Find(id);
            ViewData["PrefetID"] = new SelectList(db.Prefets, "PrefetID", "Nom");
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Ecole model)
        {
            FillSousDivisions();

            if (ModelState.IsValid)
            {
                db.Ecoles.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PerfetID"] = new SelectList(db.Prefets, "PerfetID", "Nom", model.PrefetID);
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult Supprimer(int id)
        {
            Ecole model = db.Ecoles.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Ecole model = db.Ecoles.Find(id);
            db.Ecoles.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
