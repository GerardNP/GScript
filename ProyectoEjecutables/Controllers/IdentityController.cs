using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoEjecutables.Filters;
using ProyectoEjecutables.Models;
using ProyectoEjecutables.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Controllers
{
    public class IdentityController : Controller
    {
        private IRepositoryEjecutables repo;

        public IdentityController(IRepositoryEjecutables repo) {
            this.repo = repo;
        }


        //[AuthorizeGuest]
        public IActionResult Signup()
        {
            return View();
        }
        
        //[AuthorizeGuest]
        [HttpPost]
        public IActionResult Signup(String nombre, String correo, String password)
        {
            this.repo.Signup(nombre, correo, password);
            return RedirectToAction("Login", "Identity");
        }

        //[AuthorizeGuest]
        public IActionResult Login()
        {
            return View();
        }

        //[AuthorizeGuest]
        [HttpPost]
        public async Task<IActionResult> Login(String correo, String password)
        {
            bool exist = this.repo.ExistsUser(correo);
            if(!exist)
            {
                ViewData["mensaje"] = "El correo que has introducido no pertenece a ningún usuario.";
                return View();
            } 
            else
            {
                Usuario user = this.repo.LogIn(correo, password);
                if(user != null) // USUARIO LOGUEADO
                {
                    ClaimsIdentity identidad = new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                    identidad.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    identidad.AddClaim(new Claim(ClaimTypes.Name, user.Nombre));
                    identidad.AddClaim(new Claim(ClaimTypes.Role, user.Rol));

                    ClaimsPrincipal principal = new ClaimsPrincipal(identidad);

                    await HttpContext.SignInAsync
                        (CookieAuthenticationDefaults.AuthenticationScheme, principal
                        , new AuthenticationProperties
                        {
                           IsPersistent = true,
                           ExpiresUtc = DateTime.Now.AddMinutes(15)
                        });

                    return RedirectToAction("Index", "Home");
                } 
                else
                {
                    ViewData["mensaje"] = "Tu contraseña no es correcta. Vuelve a comprobarla.";
                    return View();
                }
            }
        }

        [AuthorizeUsuarios]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

    }
}
