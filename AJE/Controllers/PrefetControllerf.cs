using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJE.Controllers
{
    public class PrefetControllerf : Controller
    {
        private readonly AppDbContextEcole db;
        public PrefetControllerf(AppDbContextEcole _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            List<Prefet> model = (from p in db.Prefets orderby p.PrefetID select p).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Prefet model)
        {
            if (ModelState.IsValid)
            {
                db.Prefets.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            Prefet model = db.Prefets.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Prefet model)
        {
            if(ModelState.IsValid)
            {
                db.Prefets.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult Supprimer(int id)
        {
            Prefet model = db.Prefets.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Prefet model = db.Prefets.Find(id);
            db.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Prefet model = db.Prefets.Find(id);
            return View(model);
        }
    }
}
