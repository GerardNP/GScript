using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoEjecutables.Repositories;
using ProyectoEjecutables.Filters;
using System.Security.Claims;
using ProyectoEjecutables.Models;

namespace ProyectoEjecutables.Controllers
{
    [AuthorizeUsuarios]
    public class UsuariosController : Controller
    {
        private IRepositoryEjecutables repo;

        public UsuariosController(IRepositoryEjecutables repo)
        {
            this.repo = repo;
        }

        public IActionResult Perfil()
        {
            String dato = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            int id = int.Parse(dato);

            Usuario user = this.repo.GetUser(id);
            return View(user);
        }
    }
}
