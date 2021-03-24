using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjecutables.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }

        [Column("CORREO")]
        public String Correo { get; set; }

        [Column("PASSWORD")]
        public byte[] Password { get; set; }

        [Column("SALT")]
        public String Salt { get; set; }

        [Column("ROL")]
        public String Rol { get; set; }
    }
}
