using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using ProyectoEjecutables.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Filters
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute,
        IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if( !user.Identity.IsAuthenticated )
            {
                context.Result = ToolkitService.GetRoute("Login", "Identity");
            }
            else if( !user.IsInRole("admin") )
            {
                context.Result = ToolkitService.GetRoute("AccesoDenegado", "Identity");
            }
        }
    }
}
