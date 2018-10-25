using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GOBUS.Models
{
    public class Cita
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el campo PlacaNumero")]
        [StringLength(10, ErrorMessage = ("La cantidad maxima de caracteres es de 10"))]
        public String PlacaNumero { get; set; }

        [Required(ErrorMessage = "Ingrese el campo FechaCita")]
        public DateTime FechaCita { get; set; }

        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Ingrese el campo IdCliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Sucursale")]
        [Required(ErrorMessage = "Ingrese el campo IdSucursal")]
        public int IdSucursal { get; set; }
        public Sucursale Sucursale { get; set; }

    }
}