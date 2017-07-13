using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi2_RESTfull_ADONet.Models;

namespace WebApi2_RESTfull_ADONet.Controllers
{
    public class UserController : ApiController
    {

        // GET: http://localhost:3366/User
        [HttpGet]
        [Route("User/GetAll")]
        [ResponseType(typeof(List<User>))]
        public IEnumerable<User> GetAll()
        {
            UserRepository db = new UserRepository();
            return db.GetAllUsers().ToList();
        }

        // GET: http://localhost:3366/User/5
        [HttpGet]
        [Route("User/{id:int}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            UserRepository db = new UserRepository();

            User user = db.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET: http://localhost:3366/User?UserId=1212345
        [HttpGet]
        [Route("User")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Get(string UserId)
        {
            UserRepository db = new UserRepository();
            Boolean stat = db.GetUserId(UserId);
            return StatusCode(stat ? HttpStatusCode.Found : HttpStatusCode.NotFound);
        }

        // POST: http://localhost:3366/User
        [HttpPost]
        [Route("User")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(User user)
        {
            UserRepository db = new UserRepository();
            Boolean stat = db.AddUser(user);
            return StatusCode(stat ? HttpStatusCode.Created : HttpStatusCode.BadRequest);
        }

        // PUT: http://localhost:3366/User
        [HttpPut]
        [Route("User")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(User user)
        {
            UserRepository db = new UserRepository();
            Boolean stat = db.UpdateUser(user);
            return StatusCode(stat ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        // DELETE: http://localhost:3366/User/5
        [HttpDelete]
        [Route("User/{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            UserRepository db = new UserRepository();
            User user = db.GetUser(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            Boolean stat = db.DeleteUser(id);
            return StatusCode(stat ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

    }
}
