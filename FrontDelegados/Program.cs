using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDelegados
{
    class Program
    {
        delegate void Reference(string Mensaje);
        delegate double Operacion(double num1,double num2);
        static void Sumar(double valor1,double valor2)
        {
            double resultado = valor1 + valor2;
            Console.WriteLine(string.Format("El resultado es {0}",resultado));
        }
        static double Multiplicar(double valor1, double valor2)
        {
            return valor1 * valor2;
        }

        

        //-------------------------Simil JavaScrip

        static void Main(string[] args)
        {
            //Creacion del objeto del tipo delegado
            Reference obj = Console.WriteLine;
            obj("Hola Mundo");
            //Delegados con Lambda
            Reference msg = (m) => Console.WriteLine(m);
            msg("Hola Lambda");

            double num1 = 8;
            double num2 = 6;

            //Otra forma de crear utilizar delegados es con Action<T> nombre = funcion;
            Action<double, double> MyFuncion = Sumar;
            MyFuncion(num1, num2);

            //Otra Forma de crear una delegado que RETORNE
            //Los primeros 2 parametros son de INPUT/ el tercero es de OUTPUT
            Func<double,double,double> MyFuncion2=Multiplicar;
            double resultado = MyFuncion2(num1, num2);
            Console.WriteLine(string.Format("Resultado {0}", resultado));

            Operacion MyFuncion3 = (x, y) => (x + y);
            double resultado2 = MyFuncion3(num1, num2);
            Operacion MyFuncion4 = (x, y) => (x * y);
            double resultado3 = MyFuncion4(num1, num2);
            Operacion MyFuncion5 = (a, b) => (a + b);
            double resultado4 = MyFuncion5(num1, num2);



            Console.ReadKey();
        }
    }
}
