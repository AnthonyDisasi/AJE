using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJE.Data;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create(int )

        public IActionResult Index()
        {
            return View();
        }
    }
}
