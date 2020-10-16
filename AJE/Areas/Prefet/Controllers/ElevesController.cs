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
    public class ElevesController : Controller
    {
        private readonly AppDbContextEcole db;
        public ElevesController(AppDbContextEcole _db)
        {
            db = _db;
        }

        private void ClasseList()
        {
            List<SelectListItem> Options = (from o in db.Options orderby o.Nom ascending select new SelectListItem() { Text = o.Nom, Value = o.Nom }).ToList();
            ViewBag.Options = Options;
        }

        public IActionResult Create(int idecole)
        {
            Ecole model = db.Ecoles.Include(c => c.Classes).AsNoTracking().FirstOrDefault(e => e.EcoleID == idecole);
            ViewData["cl"] = new SelectList(model.Classes, "ClasseID", "Nomcomplet");
            ViewData["idecole"] = idecole;
            ViewData["PrefetID"] = model.PrefetID;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int idclasse, int idecole, Eleve model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
                db.SaveChanges();
                
            }
            if(ModelState.IsValid)
            {
                var mod = new Inscription
                {
                    ClasseID = idclasse,
                    AnneeScolaire = DateTime.Now,
                    EleveID = model.EleveID
                };
                db.Add(mod);
                db.SaveChanges();
                return RedirectToAction("Detail", "Classe", new { id = idclasse });
            }
            Ecole mode = db.Ecoles.Include(c => c.Classes).AsNoTracking().FirstOrDefault(e => e.EcoleID == idecole);
            ViewData["cl"] = new SelectList(mode.Classes, "ClasseID", "Nomcomplet");
            ViewData["PrefetID"] = db.Ecoles.Find(idecole).PrefetID;
            return View(model);
        }

        public IActionResult Detail(int id, int idclasse)
        {
            //Eleve eleve = ecole.Classes
            var model = from c in db.Classes
                        join i in db.Inscriptions on c.ClasseID equals i.ClasseID
                        join el in db.Eleves on i.EleveID equals el.EleveID
                        where c.ClasseID == idclasse &&
                                el.EleveID == id
                        select el;
            return View(model);
        }
    }
}
