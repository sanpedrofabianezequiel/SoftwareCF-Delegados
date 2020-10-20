using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Autor
    {
        //Metodos CRUD ABM que consumen el ENTITY/LINQ/=>DbContex

        Modelo.Contexto _context = new Modelo.Contexto();
        public void Agregar(Modelo.Autor autor)
        {
            //Primero se agrega a la coleccion Mapiada a memoria
            _context.Autores.Add(autor);
            //Segundo la agregamos/Persistimos los datos
            _context.SaveChanges();
        }


    }
}
