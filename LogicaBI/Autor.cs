using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBI
{
    public class Autor
    {
        public void Agregar(Modelo.Autor autor)
        {
            //Validaciones de negocio
            //la logica le pega a los datos
            Datos.Autor obj = new Datos.Autor();
            obj.Agregar(autor);

        }
    }
}
