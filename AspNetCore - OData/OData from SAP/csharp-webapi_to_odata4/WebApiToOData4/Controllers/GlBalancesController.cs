using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiToOData4.Services;

namespace WebApiToOData4.Controllers {

    public class GlBalancesController : ODataController {
        [HttpGet, EnableQuery()]
        [ODataRoute("glbalances({Cocd},{Year},{Period})")]
        public IActionResult Get([FromODataUri] String Cocd, [FromODataUri] String Year, String Period)
        {
            var sapGl = new SapGLService();
            return Ok(sapGl.GetGlBalances(Cocd,Year, Period));
        }
    }
}
