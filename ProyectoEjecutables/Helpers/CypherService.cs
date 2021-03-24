using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Helpers
{
    public class CypherService
    {
        public static String GetSalt()
        {
            Random random = new Random();
            String salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int aleat = random.Next(0, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }

        public static byte[] CifrarContenido(String contenido, ref String salt)
        {
            salt = CypherService.GetSalt();
            String contenidosalt = contenido + salt;

            SHA256Managed sha = new SHA256Managed();
            byte[] salida = Encoding.UTF8.GetBytes(contenidosalt);
            for (int i = 1; i <= 100; i++)
            {
                salida = sha.ComputeHash(salida);
            }
            sha.Clear();

            return salida;
        }

        public static byte[] CifrarContenido(String contenido, String salt)
        {
            String contenidosalt = contenido + salt;

            SHA256Managed sha = new SHA256Managed();
            byte[] salida = Encoding.UTF8.GetBytes(contenidosalt);
            for (int i = 1; i <= 100; i++)
            {
                salida = sha.ComputeHash(salida);
            }
            sha.Clear();

            return salida;
        }
    }

}
