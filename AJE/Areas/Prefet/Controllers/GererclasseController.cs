using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJE.Data;
using Microsoft.AspNetCore.Mvc;

namespace AJE.Areas.Prefet.Controllers
{
    public class GererclasseController : Controller
    {
        private readonly AppDbContextEcole db;
        public GererclasseController(AppDbContextEcole _db)
        {
            db = _db;
        }

        public IActionResult Index(int id)
        {
            Ecole model = db.
            return View();
        }
    }
}
