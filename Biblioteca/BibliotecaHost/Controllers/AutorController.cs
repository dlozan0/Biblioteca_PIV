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
    public class AutorController : ApiController
    {
        BibliotecaContext bibliotecaContext =
            new BibliotecaContext("BibliotecaMaestro");

        [Route("api/autor/{idautor}/libro")]
        [HttpPut]

        public IHttpActionResult AgregarLibro(int idautor, Libro nuevoLibro)
        {
            autor autor = bibliotecaContext.Autores.Find(idautor);
            if (autor==null)
            {
                return NotFound();
            }
            autor.AgregarLibros(nuevoLibro);
            bibliotecaContext.SaveChanges();
            return Ok(autor);
             
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Autor
        public IQueryable <autor> Get()
        {
            return bibliotecaContext.Autores;
        }

        // GET: api/Autor/5
        [ResponseType(typeof(autor))]
        public IHttpActionResult  Get(int id)
        {
            var autor = bibliotecaContext.Autores
                .Include("Libros")
                .First(a => a.Id == id);

                if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        // POST: api/Autor
        [ResponseType(typeof(autor))]
        public IHttpActionResult post(autor nuevoAutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bibliotecaContext.Autores.Add(nuevoAutor);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoAutor);
        }

        // PUT: api/Autor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Autor/5
        public void Delete(int id)
        {
        }
    }
}
