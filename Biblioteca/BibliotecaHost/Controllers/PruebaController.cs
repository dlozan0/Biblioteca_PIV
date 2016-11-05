﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BibliotecaHost.Controllers
{
    //En clase nuevo atributo 
    
    public class PruebaController : ApiController
    {
        [Route("api/Prueba/Buscar/{nombre}")]
        [HttpGet]
        public IEnumerable<String> BuscarcarPorNombre(string nombre)
        {
            return new string[] { "Nombre1", "Nombre2", nombre };
        } 

        //fin 

        // GET: api/Prueba
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prueba/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prueba
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prueba/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prueba/5
        public string Delete(int id)
        {
            return "Eliminado";
        }
    }
}
