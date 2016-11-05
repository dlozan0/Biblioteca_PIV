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
    public class EditorialController : ApiController
    {
        BibliotecaContext bibliotecaContext = 
            new BibliotecaContext("BibliotecaMaestro");

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }

            base.Dispose(disposing);
        }
        // GET: api/Editorial
        public IEnumerable<Editorial> Get()
        {
            return bibliotecaContext.Editorial;

            
        }

        // GET: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Get(int id)
        {
            var editoriales = bibliotecaContext.Editorial.Find(id);
            if (editoriales == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(editoriales);
            }
           
        }

        // POST: api/Editorial
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Post(Editorial nuevoEditorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            bibliotecaContext.Editorial.Add(nuevoEditorial);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoEditorial);
        }

        // PUT: api/Editorial/5
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest(ModelState);
            }
            bibliotecaContext.Entry(editorial).State =
                System.Data.Entity.EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(editorial);
        }

        // DELETE: api/Editorial/5
        public IHttpActionResult Delete(int id)
        {
            var editorial = bibliotecaContext.Editorial.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }
            bibliotecaContext.Editorial.Remove(editorial);
            bibliotecaContext.SaveChanges();
            return Ok();
        }
    }
}
