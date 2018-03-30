using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class TipoEstudianteModel
    {
        [Key]
        public int TipoEstudianteId { get; set; }
        public string TipoEstudiante { get; set; }
    }
}