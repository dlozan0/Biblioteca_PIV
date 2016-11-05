using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;


namespace Biblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BibliotecaContext("BibliotecaMaestro"))
            {
                //>semana 3
                var nuevoLibro = new Libro();
            
                nuevoLibro.Nombre = "Libro de Nacho2";
                nuevoLibro.Año = 2009;
                context.Libros.Add(nuevoLibro);
                context.SaveChanges();
                //<


                Console.WriteLine("Hola mundo");
                Console.ReadKey();

            }
            
        }
    }
}
