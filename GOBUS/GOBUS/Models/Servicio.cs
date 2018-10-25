using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GOBUS.Models
{
    public class Servicio
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  NombreServicio")]
        [StringLength(50, ErrorMessage = ("La cantidad maxima de caracteres es de 50"))]
        public String NombreServicio { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Descripcion")]
        [StringLength(100, ErrorMessage = ("La cantidad maxima de caracteres es de 100"))]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Costo")]
        public Double Costo { get; set; }

    }
}