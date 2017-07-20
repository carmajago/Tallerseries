using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TallerSeries.Models
{
    public class Capitulo
    {
        [Key]
        public long ID { get; set; }
        [Required(ErrorMessage = "Se requiere el nombre")]
        public string nombre { get; set; }
        public int numero_cap { get; set; }
        [DisplayFormat(DataFormatString ="0:C", ApplyFormatInEditMode = true)]
        public double valor { get; set; }
        public string imagen { get; set; }
        public string video { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_publicacion { get; set; }
        [Range(0,5)]
        public int valoracion { get; set; }
        [ForeignKey("temporada")]
        public long temporadaFK { get; set; }

        public virtual Temporada temporada { get; set; }
    }
}