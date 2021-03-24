using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoEjecutables.Models;
using ProyectoEjecutables.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ProyectoEjecutables.Helpers;

namespace ProyectoEjecutables.Repositories
{
    public class RepositoryEjecutablesSQL : IRepositoryEjecutables
    {
        private EjecutablesContext context;

        public RepositoryEjecutablesSQL(EjecutablesContext context)
        {
            this.context = context;
        }


        #region USUARIOS
        private int GetMaxIdUsers()
        {
            int numusers = this.context.Usuarios.Count();
            if (numusers == 0)
            {
                return numusers;

            } else
            {
                String sql = "getmaxid_usuarios @maxid out";
                SqlParameter pamid = new SqlParameter("@maxid", -1);
                pamid.Direction = ParameterDirection.Output;
                this.context.Database.ExecuteSqlRaw(sql, pamid);

                int maxid = Convert.ToInt32(pamid.Value);
                return maxid;
            }
        }
        public void Signup(String nombre, String correo, String password)
        {
            Usuario user = new Usuario();
            user.Id = this.GetMaxIdUsers() + 1;
            user.Nombre = nombre;
            user.Correo = correo;
            String salt = "";
            byte[] respuesta = CypherService.CifrarContenido(password, ref salt);
            user.Salt = salt;
            user.Password = respuesta;
            user.Rol = "user";
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public bool ExistsUser(String correo)
        {
            Usuario user = this.context.Usuarios.Where(x => x.Correo == correo).FirstOrDefault();
            bool exist = (user != null) ? true : false;
            return exist;
        }

        public Usuario LogIn(String correo, String password)
        {
            Usuario user = this.context.Usuarios.Where(x => x.Correo == correo).First();

            String salt = user.Salt;
            byte[] passtemporal = CypherService.CifrarContenido(password, salt);
            byte[] passbbdd = user.Password;

            bool respuesta = ToolkitService.CompararArrayBytes(passbbdd, passtemporal);
            if ( !respuesta ) 
            {
                return null;
            } 
            else // USUARIO LOGUEADO
            {
                return user;
            }
        }

        public Usuario GetUser(int id)
        {
            return this.context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        #endregion


        #region APPS
        // USER
        public List<App> GetApps()
        {
            return this.context.Apps.ToList();
        }

        public List<App> GetApps(List<int> ids)
        {
            var consulta = from datos in this.context.Apps
                           where ids.Contains(datos.Id)
                           select datos;
            return consulta.ToList();
        }

        public App GetApp(int id)
        {
            return this.context.Apps.Where(x => x.Id == id).FirstOrDefault();
        }

        // ADMIN
        public void PostApp(String nombre, String accesowindows,
            String accesolinux, String accesomac, String icono)
        {
            App app = new App();
            app.Id = this.GetMaxIdApps() + 1;
            app.Nombre = nombre;
            app.AccesoWindows = accesowindows;
            app.AccesoLinux = accesolinux;
            app.AccesoMac = accesomac;
            app.Icono = icono;

            this.context.Apps.Add(app);
            this.context.SaveChanges();
        }


        private int GetMaxIdApps()
        {
            int numapps = this.context.Apps.Count();
            if (numapps == 0)
            {
                return numapps;

            }
            else
            {
                String sql = "getmaxid_apps @maxid out";
                SqlParameter pamid = new SqlParameter("@maxid", -1);
                pamid.Direction = ParameterDirection.Output;
                this.context.Database.ExecuteSqlRaw(sql, pamid);
                int maxid = Convert.ToInt32(pamid.Value);
                return maxid;
            }
        }

        public void PutApp(int id, String nombre, String accesowindows,
            String accesolinux, String accesomac, String icono)
        {
            App app = this.GetApp(id);
            // if(app != null) {
            app.Nombre = nombre;
            app.AccesoWindows = accesowindows;
            app.AccesoLinux = accesolinux;
            app.AccesoMac = accesomac;
            app.Icono = icono;

            this.context.SaveChanges();
            // }
        }

        public void PutApp(int id, String nombre, String accesowindows,
            String accesolinux, String accesomac)
        {
            App app = this.GetApp(id);
            // if(app != null) {
            app.Nombre = nombre;
            app.AccesoWindows = accesowindows;
            app.AccesoLinux = accesolinux;
            app.AccesoMac = accesomac;

            this.context.SaveChanges();
            // }
        }

        public void DeleteApp(int id)
        {
            App app = this.GetApp(id);
            // if(app != null) {
            this.context.Apps.Remove(app);
            this.context.SaveChanges();
            // }
        }
        #endregion


        #region EJECUTABLES
        public String CreateEjecutableApps(List<int> ids, String usuario)
        {
            String txtexe = "";

            List<App> apps = this.GetApps(ids);
            foreach(App app in apps)
            {
                if(app.AccesoWindows.Contains("INSERTAR_USUARIO"))
                {
                    String aux = app.AccesoWindows.Replace("INSERTAR_USUARIO", usuario);
                    txtexe += "start " + aux + Environment.NewLine;
                }
                else
                {
                    txtexe += "start " + app.AccesoWindows + Environment.NewLine;
                }
            }
            return txtexe;
        }

        public String CreateEjecutableShut(String mensaje, int tiempo)
        {
            String txtexe = "shutdown ";
            if (mensaje != null)
            {
                txtexe += "-c \"" + mensaje + "\" ";
            }
            if(tiempo != 0)
            {
                txtexe += "-t " + tiempo + " ";
            }
            
            txtexe += "-s";
            return txtexe;
        }

        #endregion
    }
}
