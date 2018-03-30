using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class AlumnoModel
    {
        [Key]
        public int AlmunoId { get; set; }
        public int TipoEstudianteId { get; set; }
        public string TipoEstudiante { get; set; }
        public string AlumnoNombre { get; set; }
        public string AlumnoApaterno { get; set; }
        public string AlumnoAmaterno { get; set; }
        public string Timestamp { get; set; }
    }
}