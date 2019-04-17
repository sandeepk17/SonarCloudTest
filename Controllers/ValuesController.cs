using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SonarCloudTest.Controllers {
    [Route ("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public ActionResult<decimal> Calculate (decimal amount, int type, int years) {
            decimal result = 0;
            decimal disc = (years > 5) ? (decimal) 5 / 100 : (decimal) years / 100;
            if (type == 1) {
                result = amount;
            } else if (type == 2) {
                result = (amount - (0.1m * amount)) - disc * (amount - (0.1m * amount));
            } else if (type == 3) {
                result = (0.7m * amount) - disc * (0.7m * amount);
            } else if (type == 4) {
                result = (amount - (0.5m * amount)) - disc * (amount - (0.5m * amount));
            }
            return result;
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}