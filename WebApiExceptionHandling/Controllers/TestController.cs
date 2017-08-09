using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExceptionHandling.HelperClasses.Filters;
using WebApiExceptionHandling.Lib.Services;

namespace WebApiExceptionHandling.Controllers
{
    [RoutePrefix("Test")]
    public class TestController : ApiController
    {
        CustomExceptionService _service;

        public TestController()
        {
            _service = new CustomExceptionService();
        }

        [Route("NotImplemented")]
        [HttpGet]
        public IHttpActionResult NotImplemented()
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        [Route("CheckId/{id}")]
        [HttpGet]
        public IHttpActionResult CheckId(int id)
        {
            if (id > 100)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("We cannot use IDs greater than 100.")
                };
                throw new HttpResponseException(message);
            }
            return Ok(id);
        }

        [Route("BadRequest/{id}")]
        [HttpGet]
        public IHttpActionResult BadRequest(int id)
        {
            if (id > 100)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("We cannot use IDs greater than 100.")
                };
                throw new HttpResponseException(message);
            }
            return Ok(id);
        }


        [Route("ArgumentNull/{id}")]
        [HttpPost]
        public IHttpActionResult ArgumentNull(int id)
        {
            _service.ThrowArgumentNullException();
            return Ok();
        }

        [Route("ItemNotFound/{id}")]
        [HttpPost]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult ItemNotFound(int id)
        {
            _service.ThrowItemNotFoundException();
            return Ok();
        }

        [Route("InvalidOperation")]
        [HttpGet]
        public IHttpActionResult InvalidOperation()
        {
            _service.ThrowInvalidOperationException();
            return Ok();
        }

        [Route("HttpError")]
        [HttpGet]
        public HttpResponseMessage HttpError()
        {
            return Request.CreateResponse(HttpStatusCode.Forbidden, "You cannot access this method at this time.");
        }

        [Route("Forbidden")]
        [HttpGet]
        public IHttpActionResult Forbidden()
        {
            return Forbidden();
        }

        [Route("OK")]
        [HttpGet]
        public IHttpActionResult OK()
        {
            return Ok();
        }


        [Route("NotFound")]
        [HttpGet]
        public IHttpActionResult NotFoundAction()
        {
            return NotFound();
        }
    }
}
