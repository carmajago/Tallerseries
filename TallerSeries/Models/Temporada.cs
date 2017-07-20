using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TallerSeries.Models
{
    public class Temporada
    {
        [Key]
        public long temporadaID { get; set; }
        public int numero { get; set; }
        public string nombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_estreno { get; set; }
        public  bool terminada { get; set; }
        [ForeignKey("serie")]
        public long serieFK { get; set; }


        public List<Capitulo> capitulo { get; set;}
        public virtual Serie serie { get; set; }
    }
}