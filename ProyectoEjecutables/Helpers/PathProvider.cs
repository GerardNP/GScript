using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ProyectoEjecutables.Helpers
{
    public class PathProvider
    {
        IWebHostEnvironment environment;
        public enum Folders {
            Images = 0, 
            Content = 1,
            Icons = 2,
            Users = 3,
        }
        public PathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public String MapPath(String filename, Folders folder)
        {
            String carpeta = folder.ToString();
            String path = "";

            if( folder == Folders.Images )
            {
                carpeta = "images";
                path = Path.Combine(this.environment.WebRootPath, carpeta, filename);

            } else if(folder == Folders.Content )
            {
                carpeta = "content";
                path = Path.Combine(this.environment.WebRootPath, "images", carpeta, filename);
            }
            else if (folder == Folders.Icons)
            {
                carpeta = "icons";
                path = Path.Combine(this.environment.WebRootPath, "images", carpeta, filename);

            }
            else if (folder == Folders.Users)
            {
                carpeta = "users";
                path = Path.Combine(this.environment.WebRootPath, "images", carpeta, filename);
            }

            return path;
        }

    }
}
