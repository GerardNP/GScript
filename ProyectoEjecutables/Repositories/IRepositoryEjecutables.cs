using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoEjecutables.Models;

namespace ProyectoEjecutables.Repositories
{
    public interface IRepositoryEjecutables
    {
        #region APPS
        List<App> GetApps();
        List<App> GetApps(List<int> ids);
        App GetApp(int id);
        
        // ADMIN
        void PostApp(String nombre, String accesowindows,
            String accesolinux, String accesomac, String icono);
        void PutApp(int id, String nombre, String accesowindows,
            String accesolinux, String accesomac, String icono);

        void PutApp(int id, String nombre, String accesowindows,
            String accesolinux, String accesomac);
        void DeleteApp(int id);
        #endregion


        #region EJECTUABLES
        String CreateEjecutableApps(List<int> ids, String usuario);
        String CreateEjecutableShut(String mensaje, int tiempo);
        #endregion


        #region USUARIOS
        public void Signup(String nombre, String correo, String password);
        public bool ExistsUser(String correo);
        public Usuario LogIn(String correo, String password);
        public Usuario GetUser(int id);
        #endregion
    }
}
