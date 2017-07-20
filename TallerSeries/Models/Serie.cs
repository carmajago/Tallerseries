using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TallerSeries.Models
{
    public class Serie
    {  

       
        [Key]
        public long serieID {get;set;}
        public string nombre { get; set; }
        public generos genero  { get; set; }
        public string foto { get; set; }
        public string video { get; set; }
        
        public List<Temporada> temporada { get; set; }

        public enum generos
        { comedia,
          terror,
          ficcion,
          accion,
          adultos }
    }
}