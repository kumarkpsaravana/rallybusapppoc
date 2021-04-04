using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RBWebAPI.Controllers
{

    [Authorize(Roles = "Administrator,Clerk")]
    public class ClerkController : ApiController
    {
        public string Get()
        {
            return "clerical/Common Data";
        }
    }
}
