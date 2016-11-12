using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Biblioteca.Data.Modelos;

namespace Biblioteca.Data
{
    public class BibliotecaContext: DbContext
    {
       public BibliotecaContext() { }
        public BibliotecaContext(string connectionName):base(connectionName)
        {
            
        }
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Editorial> Editorial { get; set; } 

        public DbSet<autor> Autores { get; set; }

    }
}
