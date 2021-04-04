using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RBWebAPI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : ApiController
    {
        public string Get()
        {
            return "Sensitive Data";
        }
    }
}
