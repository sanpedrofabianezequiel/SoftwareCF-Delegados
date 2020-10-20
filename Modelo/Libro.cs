using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("Libros")]
    public class Libro
    {
        [Key]
        public int IDAutor { get; set; }
        [MaxLength(200)]
        public string Titulo { get; set; }
        public int Año { get; set; }
        public List<Autor> Autores { get; set; }
    

    }
}
