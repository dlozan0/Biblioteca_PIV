using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;


namespace BibliotecaHost.Controllers
{
    public class LibroController : ApiController
    {

        BibliotecaContext bibliotecaContex = 
            new BibliotecaContext("BibliotecaMaestro");

        // GET: api/Libro
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Libro/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/Libro/(idLibro)/editorial/idEditorial")]
        [HttpPut]
        [ResponseType(typeof(Libro))]
        public IHttpActionResult AgregarEditorial(int idLibro, int idEditorial)
        {
            var libro = bibliotecaContex.Libros.Find(idLibro);
            var editorial = bibliotecaContex.Editorial.Find(idEditorial);

            if (libro==null|| editorial == null)
            {
                return NotFound();
            }
            libro.Editorial = editorial;
            bibliotecaContex.Entry(libro).State =
                System.Data.Entity.EntityState.Modified;
            return Ok(libro);
        }

        // POST: api/Libro
        [ResponseType(typeof(Libro))]
        public IHttpActionResult Post(Libro nuevoLibro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            bibliotecaContex.Libros.Add(nuevoLibro);
            bibliotecaContex.SaveChanges();
            return Ok(nuevoLibro);
        }

        // PUT: api/Libro/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Libro/5
        public void Delete(int id)
        {
        }
    }
}
