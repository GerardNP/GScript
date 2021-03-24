using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEjecutables.Models
{
    [Table("APPS")]
    public class App
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }

        [Column("ICONO")]
        public String Icono { get; set; }

        [Column("ACCESO_W")]
        public String AccesoWindows { get; set; }

        [Column("ACCESO_L")]
        public String AccesoLinux { get; set; }

        [Column("ACCESO_M")]
        public String AccesoMac { get; set; }
    }
}
