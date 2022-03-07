using CoreIOC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AbstractTestController : ControllerBase
    {

        [HttpGet("getInfo")]
        public ActionResult GetInfo()
        {
            PhoneGeneric p = new PhoneGeneric();

            Honor h = new Honor ();
            p.PlayGenericPhone(h);

            Mi m = new Mi();
            p.PlayGenericPhone(m);

            Vivo v = new Vivo();
            p.PlayGenericPhone(v);

            return Ok();
        }
    }
}
