using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBI
{
    public class Autor
    {
        Datos.Autor obj = new Datos.Autor();
        public void Agregar(Modelo.Autor autor)
        {
            //Validaciones de negocio
            //la logica le pega a los datos
            
            obj.Agregar(autor);

        }
        public void Modificar(Modelo.Autor autor)
        {
            obj.Modificar(autor);
        }
        public List<Modelo.Autor> TraerTodos()
        {
            return obj.TraerTodos();
        }
        public void Borrar(int id)
        {
            obj.Borrar(id);
        }
        public List<Modelo.Autor> TraerTodos(string Letras)
        {
           return obj.TraerTodos(Letras);
        }
    }
}
