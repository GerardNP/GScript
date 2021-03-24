using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoEjecutables.Models;
using ProyectoEjecutables.Repositories;
using Microsoft.AspNetCore.Http;
using ProyectoEjecutables.Helpers;
using System.IO;
using ProyectoEjecutables.Filters;

namespace ProyectoEjecutables.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        IRepositoryEjecutables repo;
        PathProvider pathprovider;

        public AdminController(IRepositoryEjecutables repo,
            PathProvider pathprovider)
        {
            this.repo = repo;
            this.pathprovider = pathprovider;
        }

        public IActionResult Index()
        {
            List<App> apps = this.repo.GetApps();
            return View(apps);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(App app, IFormFile imagen)
        {
            // GUARDAMOS LA IMAGEN
            String filename = imagen.FileName;
            String path = this.pathprovider.MapPath(filename, PathProvider.Folders.Icons);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            this.repo.PostApp(app.Nombre, app.AccesoWindows,
                app.AccesoLinux, app.AccesoMac, filename);
            return RedirectToAction("Create", "Admin");
        }

        // UPDATE
        public IActionResult Update(int id)
        {
            // Controlar que existe
            App app = this.repo.GetApp(id);
            return View(app);
        }

        [HttpPost]
        public async Task<IActionResult> Update(App app, IFormFile imagen)
        {
            // GUARDAMOS LA IMAGEN
            if(imagen != null) {
                String filename = imagen.FileName;
                String path = this.pathprovider.MapPath(filename, PathProvider.Folders.Icons);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                this.repo.PutApp(app.Id, app.Nombre, app.AccesoWindows,
                    app.AccesoLinux, app.AccesoMac, filename);
            } else
            {
                this.repo.PutApp(app.Id, app.Nombre, app.AccesoWindows,
                    app.AccesoLinux, app.AccesoMac);
            }
            
            return RedirectToAction("Update", app.Id);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.repo.DeleteApp(id);
            return RedirectToAction("Index");
        }
    }
}
