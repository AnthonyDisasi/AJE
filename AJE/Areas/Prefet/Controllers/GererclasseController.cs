using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJE.Data;
using AJE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJE.Areas.Prefet.Controllers
{
    [Area("Gererclasse")]
    [Route("PrefetClasse")]
    public class GererclasseController : Controller
    {
        private readonly AppDbContextEcole db;
        public GererclasseController(AppDbContextEcole _db)
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
                .FirstOrDefault(ec => ec.EcoleID == id);
            return View(model);
        }
    }
}
