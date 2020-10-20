using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Modelo.Autor objAutor= new Modelo.Autor();//Modelo conceptual
            LogicaBI.Autor obj = new LogicaBI.Autor();//BI
                //objAutor.Apellido= "San Pedro";
                //objAutor.Nombre = "Ezequiel";
                //     obj.Agregar(objAutor); //Le enviamos la data a LOGICA
                //        Console.WriteLine("Autor ingresado en la Base de Datos con Exito");
             

            //Ver todos los autores
            Console.WriteLine("Lista de Autores");

            foreach (var item in obj.TraerTodos())
            {
                Console.WriteLine(string.Format("Autor {0} , {1}",item.Nombre,item.Apellido));
            }

                            
             Console.ReadKey();
             
            

        }
    }
}
