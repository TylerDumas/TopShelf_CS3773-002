using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// UserController:
    /// 
    /// 
    /// </summary>
    public class UserController : ApiController {

        public List<User> users = new List<User>();

        public UserController () {
            users.Add( new Models.User {
                Id = 1,
                FullName = "Jackson Dumas",
                EmailAddress = "tylerdumas3@hotmail.com", 
                PhoneNumber = "210-464-3176", 
                StreetAddress = "6676 UTSA Boulevard", 
                StoreName = "HEB DeZavala"
            } );
        }

        // GET: api/User
        public IEnumerable<string> Get() {
            List<string> ret = new List<string>();
            foreach( User user in users ) {
                ret.Add( JsonConvert.SerializeObject( user ) );
            }
            return ret;
        }

        // GET: api/User/5
        public string Get( int id ) {
            return "value";
        }

        // POST: api/User
        public void Post( [FromBody]string value ) {

        }

        // PUT: api/User/5
        public void Put( int id, [FromBody]string value ) {

        }

        // DELETE: api/User/5
        public void Delete( int id ) {

        }
    }
}
