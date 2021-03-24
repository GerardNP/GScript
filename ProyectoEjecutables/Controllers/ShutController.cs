using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProyectoEjecutables.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Controllers
{
    public class ShutController : Controller
    {
        private IRepositoryEjecutables repo;
        private IMemoryCache MemoryCache;

        public ShutController(IRepositoryEjecutables repo, IMemoryCache memorycache)
        {
            this.repo = repo;
            this.MemoryCache = memorycache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(String mensaje, int tiempo)
        {
            if(mensaje != null)
            {
                this.MemoryCache.Set("mensaje", mensaje + "w");
            }
            this.MemoryCache.Set("tiempo", tiempo);

            return View();
        }

        public IActionResult ResultOptions()
        {
            String mensaje = null;
            if(this.MemoryCache.Get("mensaje") != null)
            {
                mensaje = this.MemoryCache.Get("mensaje").ToString();
            }
            int tiempo = int.Parse(this.MemoryCache.Get("tiempo").ToString());

            String txtexe = this.repo.CreateEjecutableShut(mensaje, tiempo);
            ViewData["txtexe"] = txtexe;
            return PartialView("_PartialResultShut");
        }

        public FileResult Download(String txtexe)
        {
            String text = txtexe;
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(text));

            return File(stream, "text/plain", "ejecutable.bat");
        }
    }
}
