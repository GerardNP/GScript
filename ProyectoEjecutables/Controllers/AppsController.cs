using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoEjecutables.Repositories;
using ProyectoEjecutables.Models;
using ProyectoEjecutables.Extensions;
using System.IO;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace ProyectoEjecutables.Controllers
{
    public class AppsController : Controller
    {
        IRepositoryEjecutables repo;
        private IMemoryCache MemoryCache;

        public AppsController(IRepositoryEjecutables repo, IMemoryCache memorycache) {
            this.repo = repo;
            this.MemoryCache = memorycache;
        }

        public IActionResult Index()
        {
            List<App> apps = this.repo.GetApps();
            return View(apps);
        }

        [HttpPost]
        public IActionResult Result(List<int> ids, String usuario)
        {
            HttpContext.Session.SetObject("idapps", ids);
            this.MemoryCache.Set("usuario", usuario);
            return View();
        }

        public IActionResult ResultApps()
        {
            List<int> idapps = HttpContext.Session.GetObject<List<int>>("idapps");
            String usuario = this.MemoryCache.Get("usuario").ToString();
            String txtexe = this.repo.CreateEjecutableApps(idapps, usuario);
            ViewData["txtexe"] = txtexe;
            return PartialView("_PartialResultApps");
        }

        public FileResult Download(String txtexe)
        {
            String text = txtexe;
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(text));

            return File(stream, "text/plain", "ejecutable.bat");
        }
    }
}
