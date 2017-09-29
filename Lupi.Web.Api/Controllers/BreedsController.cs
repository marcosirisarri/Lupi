﻿using Lupi.BusinessLogic;
using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lupi.Web.Api.Controllers
{
    public class BreedsController : ApiController
    {
        private BreedsBusinessLogic breedsBusinessLogic;

        public BreedsController()
        {
            breedsBusinessLogic = new BreedsBusinessLogic();
        }

        // GET: api/Breeds
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Breed> breeds = breedsBusinessLogic.GetAllBreeds();
                if (breeds == null)
                {
                    return NotFound();
                }
                return Ok(breeds);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Breeds/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                Breed breed = breedsBusinessLogic.GetByID(id);
                if (breed == null)
                {
                    return NotFound();
                }
                return Ok(breed);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Breeds
        public HttpResponseMessage Post([FromBody]Breed breed)
        {
            try
            {
                breedsBusinessLogic.Add(breed);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Breeds/5
        public HttpResponseMessage Put(Guid id, [FromBody]Breed breed)
        {
            try
            {
                bool updateResult = breedsBusinessLogic.Update(id, breed);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Breeds/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = breedsBusinessLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
