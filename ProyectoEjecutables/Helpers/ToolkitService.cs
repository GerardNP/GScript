using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Helpers
{
    public class ToolkitService
    {
        #region JSON
        public static String SerializeJsonObject(object objeto)
        {
            String respuesta = JsonConvert.SerializeObject(objeto);
            return respuesta;
        }

        public static T DeserializeJsonObject<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        #region BYTES
        public static bool CompararArrayBytes(byte[] a, byte[] b)
        {
            bool iguales = true;
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if ( !a[i].Equals(b[i]) )
                {
                    iguales = false;
                    break;
                }
            }

            return iguales;
        }
        #endregion


        #region ROUTE
        public static RedirectToRouteResult GetRoute(String action, String controller)
        {
            RouteValueDictionary ruta = new RouteValueDictionary(
                new { 
                    action = action, controller = controller
                });
            //RedirectToRouteResult result = new RedirectToRouteResult(ruta);
            //return result;
            return new RedirectToRouteResult(ruta);
        }
        #endregion

    }
}
