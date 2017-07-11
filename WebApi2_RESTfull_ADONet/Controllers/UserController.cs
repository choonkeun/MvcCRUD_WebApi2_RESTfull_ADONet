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
        [Route("User")]
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            UserRepository db = new UserRepository();
            return db.GetAllUsers().ToList();
        }

        // GET: http://localhost:3366/User/5
        [ResponseType(typeof(User))]
        [HttpGet]
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

        // POST: http://localhost:3366/User
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            UserRepository db = new UserRepository();
            Boolean stat = db.AddUser(user);
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: http://localhost:3366/User
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(User user)
        {
            UserRepository db = new UserRepository();
            Boolean stat = db.UpdateUser(user);
            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: http://localhost:3366/User/5
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            UserRepository db = new UserRepository();
            User user = db.GetUser(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            Boolean stat = db.DeleteUser(id);
            return StatusCode(HttpStatusCode.OK);
        }

    }
}
