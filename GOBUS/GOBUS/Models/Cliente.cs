using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GOBUS.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  Nombre")]
        [StringLength(50, ErrorMessage = ("La cantidad maxima de caracteres es de 50"))]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  Apellidos")]
        [StringLength(100, ErrorMessage = ("La cantidad maxima de caracteres es de 100"))]
        public String Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  Direccion")]
        [StringLength(200, ErrorMessage = ("La cantidad maxima de caracteres es de 200"))]
        public String Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  Telefono")]
        [StringLength(20, ErrorMessage = ("La cantidad maxima de caracteres es de 20"))]
        public String Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese el campo  Email")]
        [StringLength(20, ErrorMessage = ("La cantidad maxima de caracteres es de 20"))]
        public String Email { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }

    }
}