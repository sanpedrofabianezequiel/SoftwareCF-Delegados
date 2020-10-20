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
        public void Modificar(Modelo.Autor autor)
        {
            //Determinar simpre con un IF SI NO ES NULL EN EL FRONTEND


            //ESTA ES UNA FORMA DE HACER EL UPDATE
            //Buscamos el Autor actual que retorna un Objeto de ese TIPO
            Modelo.Autor autorLinqActual= _context.Autores.Find(autor.ID);
            //Hacemos el reemplazo
            autorLinqActual.ID = autor.ID;
            autorLinqActual.Apellido = autor.Apellido;
            autorLinqActual.Nombre = autor.Nombre;
            #region Otro Metodo con Linq Seria
            var autores = (from x in _context.Autores
                           where x.ID.Equals(autor.ID)
                           select x).Single();//Devuelve un solo elemento la funcion Single()
            //Realizamos la misma comparacion o reemplazo
            //autores.ID=autor.ID
            #endregion
            _context.SaveChanges();

        }
        public List<Modelo.Autor> TraerTodos()
        {
            List<Modelo.Autor> lista = new List<Modelo.Autor>();
            lista = (
                        from x in _context.Autores
                        select x
                     ).ToList();
            #region Otra forma
            //var lista2 = from r in _context.Autores
            //             select r;
            //return lista2.ToList();
            #endregion
            return lista;
        }

        public List<Modelo.Autor> TraerTodos(string Letras)
        {
            //Buscando por Linq
            //Creamos este mismo metodo en la capa de BI para que puedan acceder todos los FRONTEND
            var lista = from x in _context.Autores
                        where x.Apellido.Contains(Letras)
                        select x;

            return lista.ToList();

        }



        public void Borrar(int id)
        {

            _context.Autores.Remove( _context.Autores.Find(  id  ));
            _context.SaveChanges();

        }

    }
}
