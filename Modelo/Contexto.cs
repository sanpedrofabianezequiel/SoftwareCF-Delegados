using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Contexto:DbContext
    {
        //Utilizamos el constructor para Apuntar a la base Correcta
        public Contexto():base("MiCadena")
        {

        }

        //Esta es la manipulacion sobre la informacion en memoria no el BASEDATO eso es en SaveChanges
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
